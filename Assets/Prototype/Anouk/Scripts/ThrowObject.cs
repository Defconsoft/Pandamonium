using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public float speed = 40f;
    public GameObject obj;
    private Rigidbody rb;
    public Transform throwpoint;
    public Vector3 direction = new Vector3(0,0,0);

    void Start()
    {
        if (direction == new Vector3(0,0,0))
        {
            direction = -transform.right;
        }
    }

    public void Throw()
    {
        GameObject objClone = Instantiate(obj, throwpoint.position, Quaternion.identity);
        rb = objClone.GetComponent<Rigidbody>();
        rb.AddForce(direction * speed, ForceMode.Impulse);
    }
}
