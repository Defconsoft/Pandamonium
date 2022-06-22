using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : Interactable
{

    [SerializeField]
    private float sinSpeed = 0.8f;
    // Update is called once per frame
    void Update()
    {
        Scale();
    }

    private void Scale()
    {
        float sinValue = (Mathf.Sin(Time.time * sinSpeed) + 3)/4;
        Vector3 scaleVec = new Vector3(sinValue, sinValue, sinValue);
        transform.localScale = scaleVec;
    }

}
