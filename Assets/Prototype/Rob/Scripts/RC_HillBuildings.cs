using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_HillBuildings : MonoBehaviour
{

    public GameObject[] buildingPrefab;



    // Start is called before the first frame update
    void Start()
    {

        bool coinFlip = (Random.value > 0.7f);
        if (coinFlip){
            GameObject clone = Instantiate (buildingPrefab[Random.Range(0, buildingPrefab.Length)], transform.position, transform.rotation);
            clone.transform.parent = this.transform;
            float offset = Random.Range (0, 1f);
            foreach (Transform child in clone.transform){
                child.GetComponent<Renderer>().material.SetTextureOffset("_BaseMap", new Vector2(offset, 0)); // Changes the color
            }



        }


    }

}
