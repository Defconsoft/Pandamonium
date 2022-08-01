using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
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
    public CinemachineVirtualCamera StartCut, StartCam, RollingCam, CityCam, CutsceneCam, CutsceneCam2;
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

    float desiredAlphaIn = 1;
    float desiredAlphaOut = 0;
    float currentAlpha;
    float currentFade = 1f;
    bool CamIn, CamOut, FadeOut;
    public CanvasGroup cutsceneCanvas;
    GameObject CollectContainer;
    public GameObject ParticleContainer;
    public Image JuiceFill;
    bool FillJuice;
    float JuiceAmount;
    public GameObject FruitSlider;

    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine (StartGame());
        CollectContainer = GameObject.Find("Collectibles");
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


        if (CamIn){
            currentAlpha = Mathf.MoveTowards( currentAlpha, desiredAlphaIn, 2.0f * Time.deltaTime);
        }

        if (CamOut){
            currentAlpha = Mathf.MoveTowards( currentAlpha, desiredAlphaOut, 2.0f * Time.deltaTime);
        }

        if (FadeOut){
            currentFade = Mathf.MoveTowards( currentFade, 0, 0.5f * Time.deltaTime);
        }

        if (FillJuice){
            JuiceAmount = Mathf.MoveTowards( JuiceAmount, 1, 0.5f * Time.deltaTime);
        }
        gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_Progress", currentFade);
        cutsceneCanvas.alpha = currentAlpha;
        JuiceFill.fillAmount = JuiceAmount;
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
        Debug.Log ("StartCutscene");
        camBrain.m_DefaultBlend.m_Time = 0;
        CutsceneCam.m_Priority = 2;
        Vector3 jumpPoint = new Vector3 (0, transform.position.y, transform.position.z + 50f);
        GetComponent<Transform>().DOLocalJump (jumpPoint, 4f, 1, 1f);
        
        StartCoroutine(SwitchToCity());
    }

    IEnumerator SwitchToCity(){
                    
        yield return new WaitForSeconds(2f); //This is the jump pause
        anim.SetBool("IsRunning", false);
        anim.SetTrigger("Attack2");
        CamIn = true;
        camBrain.m_DefaultBlend.m_Time = 2;
        CutsceneCam.m_Priority = 1;
        CutsceneCam2.m_Priority = 2;
        Destroy(GameObject.Find("Hill"), 2f); //This is the camera zoom pause
        foreach (Transform child in CollectContainer.transform) {
            Destroy(child.gameObject);
        }
        yield return new WaitForSeconds(1f);  //Wait for the fade
        FadeOut = true;
        foreach (Transform child in ParticleContainer.transform) {
            child.GetComponent<ParticleSystem>().Play();
        }
        FruitSlider.SetActive (true);
        FillJuice = true;
        yield return new WaitForSeconds(4f); // Holds him in the air
        foreach (Transform child in ParticleContainer.transform) {
            child.GetComponent<ParticleSystem>().Stop();
        }
        FruitSlider.SetActive (false);
        FillJuice = false;
        // GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Transform>().DOLocalMove (lerpEndPoint.position, 2f);
        camBrain.m_DefaultBlend.m_Time = 2;
        CutsceneCam2.m_Priority = 1;
        CityCam.m_Priority = 2;
        
        CamIn = false;
        CamOut = true;
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
