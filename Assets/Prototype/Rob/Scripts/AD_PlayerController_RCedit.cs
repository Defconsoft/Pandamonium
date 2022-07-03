using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using Cinemachine;

public class AD_PlayerController_RCedit : MonoBehaviour
{
    public float speed = 20.0f;
    public float airspeed;
    public float sphereRadius = 1.0f;
    public float jumpSpeed = 18.0f;
    private float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    private Rigidbody rb;
    private Vector3 movement;
    [SerializeField]
    private float sensitivity = 0.2f;
    public GameObject HillCanvas;
    public Animator anim;

    [Header("Robs Stuff")]
    public bool HillGame = true;
    public bool TransitionGame;
    public float lerpTime;
    float transLerpTime;
    private float perc = 0f;
    Vector3 lerpStartPoint;
    Transform CityStartPoint;
    public CinemachineVirtualCamera StartCam, RollingCam, CityCam;
    public RC_BearController theBear;
    public GameObject BattleCanvas;
    bool isGrounded;
    public float GroundDistance;

    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movement = new Vector3(movementVector.x, 0.0f, movementVector.y);
    }

    void FixedUpdate()
    {
        
        rb.AddForce(Physics.gravity * 9.81f);

        if (HillGame){


            if (isGrounded)
            {
                anim.SetBool("IsRunning", HillGame); // because we just continuously run when its hillgame and otherwise we dont
                rb.AddForce(movement * speed, ForceMode.Acceleration);

                // No input from player
                // if (movement.magnitude <= sensitivity && rb.velocity.magnitude > 0.0f)
                // {
                //     rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, speed * 0.1f * Time.deltaTime); // Slow down
                // }
            } else { //AirSpeed Controller
                rb.AddForce(movement * speed/airspeed, ForceMode.Acceleration);
            }

        }

        if (!HillGame) {
            lerpStartPoint = transform.position;
            if (TransitionGame){
                GetComponent<Rigidbody>().isKinematic = true;
                CityStartPoint = GameObject.Find ("PlayerStartPosition").transform;
                RunTheCutScene();
                TransitionGame = false;
            }
        }

        Color rayColor;
        if (!Physics.Raycast (transform.position, -Vector3.up, GroundDistance)){
            isGrounded = false;
            rayColor = Color.red;
        } else {
            isGrounded = true;
            rayColor = Color.green;
        }
        
    }

    private void RunTheCutScene()
    {
        Vector3 jumpPoint = new Vector3 (0, transform.position.y, transform.position.z + 50f);
        GetComponent<Transform>().DOLocalJump (jumpPoint, 6f, 1, 4f);
        GetComponent<Rigidbody>().isKinematic = false;
        StartCoroutine(SwitchToCity());
    }

    IEnumerator SwitchToCity(){
        anim.SetBool("IsRunning", false);
        yield return new WaitForSeconds(4f);
        CityCam.m_Priority = 2;
        yield return new WaitForSeconds(2f);
        theBear.Move = true;
        yield return new WaitForSeconds (4f);
        BattleCanvas.SetActive (true);
        HillCanvas.SetActive(false);
    }

    public void OnJump()
    {
        if (isGrounded)
        {
            // allow jump only if player is currently grounded
            rb.AddForce(Vector3.up * jumpSpeed , ForceMode.Impulse);
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "CamTrigger"){
            StartCam.m_Priority = 0;
            RollingCam.m_Priority = 1;
        }


        // Check if it is Interactable, if so, call interaction function
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable)
        {
           interactable.Interact();
        }




    }

    // void OnDrawGizmosSelected()
    // {
    //     // For debugging
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawSphere(transform.position - (Vector3.up * sphereRadius), groundCheckRadius);
    // }
}
