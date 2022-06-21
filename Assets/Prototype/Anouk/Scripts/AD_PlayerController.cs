using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AD_PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float sphereRadius = 1.0f;
    public float jumpSpeed = 18.0f;
    private float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    private Rigidbody rb;
    private Vector3 movement;
    [SerializeField]
    private float sensitivity = 0.2f;
    
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
        if (OnGround())
        {
            rb.AddForce(movement * speed, ForceMode.Acceleration);

            // No input from player
            if (movement.magnitude <= sensitivity && rb.velocity.magnitude > 0.0f)
            {
                rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, speed * 0.1f * Time.deltaTime); // Slow down
            }
        }
    }

    public void OnJump()
    {
        if (OnGround())
        {
            // allow jump only if player is currently grounded
            rb.AddForce(Vector3.up * jumpSpeed , ForceMode.Impulse);
        }
    }

    public bool OnGround()
    {
        return Physics.CheckSphere(transform.position - (Vector3.up * sphereRadius), groundCheckRadius, groundLayer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            other.gameObject.SetActive(false);
        }
    }

    // void OnDrawGizmosSelected()
    // {
    //     // For debugging
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawSphere(transform.position - (Vector3.up * sphereRadius), groundCheckRadius);
    // }
}
