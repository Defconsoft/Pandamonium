using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_CapsuleCreator : MonoBehaviour
{

    public GameObject[] models;
    // Start is called before the first frame update
    void Start()
    {
        int choice = Random.Range (0, models.Length);
        models[choice].SetActive (true);
    }


}
