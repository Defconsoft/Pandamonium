using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_Collectible : MonoBehaviour
{

    public enum CollectibleType  {Cherry, Pear, Apple, Orange, Poison, BigSurf, Parley};

    public CollectibleType collectibleType;
    public RC_GameManager rC_GameManager;
    public float sinSpeed = 1.5f;



    private void Start() {
        rC_GameManager = GameObject.Find("GameManager").GetComponent<RC_GameManager>();
    }

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


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"){
		    switch(collectibleType){
			
                case CollectibleType.Cherry:			rC_GameManager.AddNumber(0); break;
                case CollectibleType.Pear:			    rC_GameManager.AddNumber(1); break;
                case CollectibleType.Apple:			    rC_GameManager.AddNumber(2); break;	
                case CollectibleType.Orange:		    rC_GameManager.AddNumber(3); break;
                case CollectibleType.Poison:		    rC_GameManager.AddNumber(4); break;		
                case CollectibleType.BigSurf:		    rC_GameManager.AddNumber(5); break;	
                case CollectibleType.Parley:		    rC_GameManager.AddNumber(6); break;		
		    }
        }

        Destroy(gameObject);
    }


}
