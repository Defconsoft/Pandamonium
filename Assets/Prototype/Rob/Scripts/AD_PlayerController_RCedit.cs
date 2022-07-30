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
    public LayerMask groundLayer;
    private Rigidbody rb;
    private Vector3 movement;
    [SerializeField]
    public GameObject HillCanvas;
    public Animator anim;

    [Header("Robs Stuff")]
    public bool HillGame = true;
    public bool TransitionGame;
    public float lerpTime;
    float transLerpTime;
    public Transform lerpEndPoint;
    Transform CityStartPoint;
    public CinemachineVirtualCamera StartCut, StartCam, RollingCam, CityCam, CutsceneCam;
    public CinemachineBrain camBrain;
    // public RC_BearController theBear;
    public AD_EnemyController enemy;
    public GameObject BattleCanvas;
    
    public GameObject StartDialog;
    public GameObject RollingDialog;

    bool isGrounded;
    public float GroundDistance;
    bool Started;
    bool Intro = true;

    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine (StartGame());
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movement = new Vector3(movementVector.x, 0.0f, movementVector.y);
    }


    IEnumerator StartGame() {
        yield return new WaitForSeconds (1f);
        StartCut.m_Priority = 0;
        yield return new WaitForSeconds (4f);
        StartDialog.SetActive (true);
        Intro = false;
        camBrain.m_DefaultBlend.m_Time = 2;
    }



    private void Update() {

        if (!Started && !Intro){
            if (Keyboard.current.wKey.wasPressedThisFrame){
                Started = true;
                StartDialog.SetActive (false);
                HillCanvas.SetActive (true);
                RollingDialog.SetActive (true);

            }
        }



        if (!HillGame) {
            if (TransitionGame){
                TransitionGame = false;
                GetComponent<Rigidbody>().isKinematic = true;
                CityStartPoint = GameObject.Find ("PlayerStartPosition").transform;
                RollingDialog.SetActive (false);
                HillCanvas.SetActive(false);
                RunTheCutScene();
            }
        }
    }

    void FixedUpdate()
    {
        
        rb.AddForce(Physics.gravity * 9.81f);

        if (!Intro){
            if (HillGame){


                if (isGrounded)
                {
                    anim.SetBool("IsRunning", HillGame); // because we just continuously run when its hillgame and otherwise we dont
                    rb.AddForce(movement * speed, ForceMode.Acceleration);
                    rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);

                    // No input from player
                    // if (movement.magnitude <= sensitivity && rb.velocity.magnitude > 0.0f)
                    // {
                    //     rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, speed * 0.1f * Time.deltaTime); // Slow down
                    // }
                } else { //AirSpeed Controller
                    rb.AddForce(movement * speed/airspeed, ForceMode.Acceleration);
                    rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);
                }

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
        camBrain.m_DefaultBlend.m_Time = 0;
        CutsceneCam.m_Priority = 2;
        Vector3 jumpPoint = new Vector3 (0, transform.position.y, transform.position.z + 50f);
        GetComponent<Transform>().DOLocalJump (jumpPoint, 4f, 1, 4f);
        StartCoroutine(SwitchToCity());
    }

    IEnumerator SwitchToCity(){
        anim.SetBool("IsRunning", false);
        yield return new WaitForSeconds(4f);
        // GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Transform>().DOLocalMove (lerpEndPoint.position, 2f);
        camBrain.m_DefaultBlend.m_Time = 2;
        CutsceneCam.m_Priority = 1;
        CityCam.m_Priority = 2;
        Destroy(GameObject.Find("Hill"), 1f);
        yield return new WaitForSeconds(2f);
        // theBear.Move = true;
        enemy.Move = true;
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
