using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_HillGenerator_AD_edit : MonoBehaviour
{

    [Header("Hill Part Objects")]
    public GameObject[] HillParts; //array of all the different hill parts in use
    public GameObject HillPartContainer; //stores all the bits
    public GameObject Spawnpoint; //moves to where the next piece will spawn
    public GameObject endTriggerObject;

    [Header("Hill Variables")]
    public int maxSegments; //total number of segments at any one time
    public int currentSegments; // the current number of segments alive
    private int TotalNumberSegments; //counts how many have been spawned
    public int MaxTotalSegments; //Gives the hill its length
    bool canGenerate = true; //Decides if it can generate or not
    bool EndOnce; // stops the end trigger spawning endlessly

    private float MoveZ;
    private float MoveY;

    // Update is called once per frame
    void Update()
    {
        //Generates the hill
        if (canGenerate){
            while (currentSegments < maxSegments)
            {
                GenerateHill();
            }
        }

        //Checks to see if the hill is long enough
        if (TotalNumberSegments >= MaxTotalSegments && EndOnce == false){
            EndOnce = true;
            canGenerate = false;

            //moves the spawnpoint back
            Vector3 endTrigPos = new Vector3 (Spawnpoint.transform.position.x, Spawnpoint.transform.position.y + (MoveY * 2), Spawnpoint.transform.position.z - (MoveZ * 2));
            //adds in the hill end trigger
            GameObject endTrigger = Instantiate(endTriggerObject, endTrigPos, Quaternion.identity);
            endTrigger.GetComponent<RC_StartCity>().spawnOrigin = this.gameObject;
        }



    }   

    void GenerateHill()
    {
        //Spawn a piece and move it around
        GameObject clone = Instantiate(HillParts[Random.Range(0, HillParts.Length)], Spawnpoint.transform);
        clone.transform.parent = HillPartContainer.transform;
        clone.GetComponent<RC_HillPrefab_AD_edit>().spawnOrigin = this.gameObject;
        currentSegments++;
        //Works how how far to move things
        MoveY = clone.GetComponent<RC_HillPrefab_AD_edit>().ymove;
        MoveZ = clone.GetComponent<RC_HillPrefab_AD_edit>().zmove;
        Spawnpoint.transform.position = new Vector3 (Spawnpoint.transform.position.x, Spawnpoint.transform.position.y - (MoveY * 2), Spawnpoint.transform.position.z + (MoveZ * 2));
        TotalNumberSegments ++;
    }
}
