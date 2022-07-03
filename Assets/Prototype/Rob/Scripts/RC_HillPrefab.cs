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
    private Vector3 spawnPos;
    private Vector3 lastPos;
    private bool spawnable;
    public GameObject[] fruitItems;


    public GameObject[] HillParts;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        
        if (!Startpiece){
            //Decide which hill part we are using
            int tempNum = Random.Range (0, HillParts.Length);
            HillParts[tempNum].SetActive (true);
        }


        SpawnItems();

    }

    private void SpawnItems()
    {
        for (int i = 0; i < NumberToSpawn; i++)
        {
            while (spawnable) {
                spawnPos = (transform.localPosition + centre) + new Vector3 (Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
                
                RaycastHit hit;
                Ray ray = new Ray (spawnPos, Vector3.down);
                Physics.Raycast (ray, out hit);
                if (hit.collider.tag == "HillFloor") {
                    spawnable = false;
                }

            }

            GameObject clone = Instantiate (fruitItems[Random.Range(0, fruitItems.Length)], spawnPos, Quaternion.identity);

            lastPos = spawnPos;
            spawnable = true;
        
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


