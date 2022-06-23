using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_BuildingGenerator : MonoBehaviour
{
    public GameObject spawnOrigin;
    public float RandomNum;
    // Start is called before the first frame update
    void Start()
    {
        RandomNum = spawnOrigin.GetComponent<RC_CityBuilder>().BldFloorChance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
