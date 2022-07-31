using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_CollectibleUI : MonoBehaviour
{
    
    public Camera cam;
    public Canvas canvas;
    public Vector2 WorldToScreen;
    public GameObject pickup;
    public GameObject collectible_type;
    public GameObject newCollectionUIImage;
    public Vector2 startingpos;
    public Vector2 endingpos;
    public float speed = 1.0f;
    
      
    private void OnTriggerEnter(Collider other) 
    {

        if (other.tag == "Collectible"){
            pickup = other.gameObject;
            collectible_type = pickup.GetComponent<RC_CollectibleType>().CollectType;

            WorldToScreen = cam.WorldToScreenPoint (other.transform.position);
            newCollectionUIImage = Instantiate (collectible_type, canvas.transform, false);

            string ResourceType = pickup.GetComponent<RC_CollectibleType>().ResourceType;

            newCollectionUIImage.GetComponent<RC_PickUpUIMove>().SetResourceType (ResourceType);

            startingpos = newCollectionUIImage.GetComponent<RectTransform>().anchoredPosition;
            startingpos = WorldToScreen;

            Destroy (other.gameObject);
        }
    }



}
