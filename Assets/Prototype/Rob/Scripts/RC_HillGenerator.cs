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

    // Start is called before the first frame update
    void Start()
    {

    }

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
        clone.GetComponent<RC_HillDestroyer>().spawnOrigin = this.gameObject;
        currentSegments++;
        Spawnpoint.transform.position = new Vector3 (Spawnpoint.transform.position.x, Spawnpoint.transform.position.y - 2.6f, Spawnpoint.transform.position.z + 9.66f);

    }
}
