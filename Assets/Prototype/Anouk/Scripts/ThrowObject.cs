using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public float speed = 40f;
    public GameObject obj;
    private Rigidbody rb;
    public Transform throwpoint;

    public void Throw()
    {
        GameObject objClone = Instantiate(obj, throwpoint);
        rb = objClone.GetComponent<Rigidbody>();
        rb.AddForce(-transform.right * speed, ForceMode.Impulse);
    }
}
