using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_HillPrefab_AD_edit : MonoBehaviour
{
    private GameObject Player;
    public GameObject spawnOrigin;
    public float zmove;
    public float ymove;

    public GameObject[] HillParts;

    [Header("Fruit spawn settings")]
    private List<Transform> spawnPoints = new List<Transform>();
    private int nrToSpawn = 0; // How many fruits to spawn
    public float spawnPercentage = 0.5f; // What percentage of the available positions needs to be filled
    public GameObject[] fruitPrefabs; // Holds the fruit prefabs
    public GameObject fruitContainer;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        
        //Decide which hill part we are using
        int tempNum = Random.Range (0, HillParts.Length);
        HillParts[tempNum].SetActive (true);
        SpawnFruit(HillParts[tempNum]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.z - transform.position.z > 30f) {
            spawnOrigin.GetComponent<RC_HillGenerator_AD_edit>().currentSegments--;
            Destroy(this.gameObject);
        }
    }

    private void SpawnFruit(GameObject go)
    {
        // spawnPoints = new List<Transform>(go.transform.GetChild(0).GetComponentsInChildren<Transform>());
        foreach (Transform tr in go.transform.GetChild(0)) spawnPoints.Add(tr);
        nrToSpawn = (int)Mathf.Floor(spawnPoints.Count * spawnPercentage);
        for (int i = 0; i < nrToSpawn; i++)
        {
            int fruitIndex = Random.Range(0, fruitPrefabs.Length);
            int spawnIndex = Random.Range(0, spawnPoints.Count);
            Instantiate(fruitPrefabs[fruitIndex], spawnPoints[spawnIndex].position, Quaternion.identity, fruitContainer.transform);
            // Now remove the used point from the points list as it is no longer available
            spawnPoints.RemoveAt(spawnIndex);
        }
    }
}


