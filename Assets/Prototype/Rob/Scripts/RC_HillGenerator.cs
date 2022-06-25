using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_HillGenerator : MonoBehaviour
{

    public GameObject[] HillParts; //array of all the different hill parts in use
    public GameObject HillPartContainer; //stores all the bits
    public GameObject Spawnpoint; //moves to where the next piece will spawn
    public int maxSegments; //total number of segments at any one time
    public int currentSegments; // the current number of segments alive

    private float MoveZ;
    private float MoveY;

    // Update is called once per frame
    void Update()
    {
        while (currentSegments < maxSegments)
        {
            GenerateHill();
        }
    }   

    void GenerateHill()
    {
        GameObject clone = Instantiate(HillParts[Random.Range(0, HillParts.Length)], Spawnpoint.transform);
        clone.transform.parent = HillPartContainer.transform;
        clone.GetComponent<RC_HillPrefab>().spawnOrigin = this.gameObject;
        currentSegments++;
        //Works how how far to move things
        MoveY = clone.GetComponent<RC_HillPrefab>().ymove;
        MoveZ = clone.GetComponent<RC_HillPrefab>().zmove;
        Spawnpoint.transform.position = new Vector3 (Spawnpoint.transform.position.x, Spawnpoint.transform.position.y - (MoveY * 2), Spawnpoint.transform.position.z + (MoveZ * 2));

    }
}
