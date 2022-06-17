using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillDestroyer : MonoBehaviour
{
    private GameObject Player;
    public GameObject spawnOrigin;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.z - transform.position.z > 10f) {
            spawnOrigin.GetComponent<HillGenerator>().currentSegments--;
            Destroy(this.gameObject);
        }
    }
}
