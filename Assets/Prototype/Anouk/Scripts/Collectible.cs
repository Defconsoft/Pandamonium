using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    [SerializeField]
    private float sinSpeed = 0.8f;
    // Update is called once per frame
    void Update()
    {
        Rotate();
        Scale();
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3 (15, 30, 45) * Time.deltaTime);
    }

    private void Scale()
    {
        float sinValue = (Mathf.Sin(Time.time * sinSpeed) + 3)/4;
        Vector3 scaleVec = new Vector3(sinValue, sinValue, sinValue);
        transform.localScale = scaleVec;
    }

}
