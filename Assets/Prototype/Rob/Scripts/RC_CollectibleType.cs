using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_CollectibleType : MonoBehaviour
{
    public GameObject CollectType;
    public string ResourceType;
    public float sinSpeed = 1.5f;

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
