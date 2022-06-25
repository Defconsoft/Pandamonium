using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_HillPrefab : MonoBehaviour
{
    private GameObject Player;
    public GameObject spawnOrigin;
    public float zmove;
    public float ymove;


    public GameObject[] HillParts;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        
        //Decide which hill part we are using
        int tempNum = Random.Range (0, HillParts.Length);
        HillParts[tempNum].SetActive (true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.z - transform.position.z > 30f) {
            spawnOrigin.GetComponent<RC_HillGenerator>().currentSegments--;
            Destroy(this.gameObject);
        }
    }
}


