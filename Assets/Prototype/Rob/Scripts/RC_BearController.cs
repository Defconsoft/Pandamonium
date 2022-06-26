using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_BearController : MonoBehaviour
{
   
    public float speed = 1.0f;
   
    public Transform target;
    public bool Move;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Move){
            // Move our position a step closer to the target.
            var step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                transform.position = target.position;
                Move = false;
            }
        }
    }
}
