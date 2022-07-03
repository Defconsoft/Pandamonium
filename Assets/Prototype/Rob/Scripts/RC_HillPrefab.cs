using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_HillPrefab : MonoBehaviour
{
    private GameObject Player;
    public GameObject spawnOrigin;
    public float zmove;
    public float ymove;
    public bool Startpiece;

    [Header("SpawningStuff")]
    public Vector3 centre;
    public Vector3 size;
    public int NumberToSpawn;
    public int NumberTreesSpawn;
    private Vector3 spawnPos;
    private Vector3 lastPos;
    private bool spawnable;
    private bool treespawnable;
    public GameObject[] fruitItems;
    private GameObject collectibles;


    public GameObject[] HillParts;
    public GameObject tree;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        collectibles = GameObject.Find("Collectibles");
        if (!Startpiece){
            //Decide which hill part we are using
            int tempNum = Random.Range (0, HillParts.Length);
            HillParts[tempNum].SetActive (true);
        }

        SpawnTrees();
        SpawnItems();

    }

    private void SpawnItems()
    {
        for (int i = 0; i < NumberToSpawn; i++)
        {
            while (!spawnable) {
                spawnPos = (transform.localPosition + centre) + new Vector3 (Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
                
                RaycastHit hit;
                Ray ray = new Ray (spawnPos, Vector3.down);
                Physics.Raycast (ray, out hit);
                if (hit.collider.tag == "HillFloor") {
                    spawnPos = hit.point;
                    spawnable = true;
                }

            }

            GameObject clone = Instantiate (fruitItems[Random.Range(0, fruitItems.Length)], spawnPos, Quaternion.identity);
            clone.transform.parent = collectibles.transform;
            spawnable = false;
        
        }
    }


    private void SpawnTrees()
    {
        for (int i = 0; i < NumberTreesSpawn; i++)
        {
            while (!treespawnable) {
                spawnPos = (transform.localPosition + centre) + new Vector3 (Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
                
                RaycastHit hit;
                Ray ray = new Ray (spawnPos, Vector3.down);
                Physics.Raycast (ray, out hit);
                if (hit.collider.tag == "HillFloor") {
                    lastPos = hit.point;
                    treespawnable = true;
                }

            }

            GameObject clone = Instantiate (tree, lastPos, Quaternion.Euler (new Vector3 (0, Random.Range(0,360), 0)));
            clone.transform.parent = collectibles.transform;
            clone.transform.localScale = new Vector3 (Random.Range (0.75f, 1.5f),Random.Range (0.75f, 1.5f), Random.Range (0.75f, 1.5f));
            treespawnable = false;
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Startpiece)
        {
            if (Player.transform.position.z - transform.position.z > 200f) {
                spawnOrigin.GetComponent<RC_HillGenerator>().currentSegments--;
                Destroy(this.gameObject);
            }
        } 
        else 
        {
            if (Player.transform.position.z - transform.position.z > 200f) {
                Destroy(this.gameObject);
            }
        }
    }


    void OnDrawGizmosSelected() {
        Gizmos.color = new Color (1,0,0,0.5f);
        Gizmos.DrawCube(transform.localPosition + centre, size);   
    }
}


