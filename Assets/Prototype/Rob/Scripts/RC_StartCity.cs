using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_StartCity : MonoBehaviour
{

    private GameObject cityObject;
    public GameObject spawnOrigin;
    private RC_HillGenerator hillGen;

    private void Start() {
        cityObject = GameObject.Find("City");
        hillGen = spawnOrigin.GetComponent<RC_HillGenerator>();
    }



    private void OnTriggerEnter(Collider other) {
       if (other.tag == "Player"){

            GameObject.Find("Player").GetComponent<AD_PlayerController_RCedit>().HillGame = false;
            GameObject.Find("Player").GetComponent<AD_PlayerController_RCedit>().TransitionGame = true;
       } 
    }



}
