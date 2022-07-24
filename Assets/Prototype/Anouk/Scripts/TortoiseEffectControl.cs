using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortoiseEffectControl : MonoBehaviour
{
    public GameObject[] flameObjects;
    public GameObject[] blastObjects;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject go in flameObjects)
        {
            go.SetActive(false);
        }
        foreach(GameObject go in blastObjects)
        {
            go.SetActive(false);
        }
    }

    public void StartFlameThrowerEffect()
    {
        foreach(GameObject go in flameObjects)
        {
            go.SetActive(true);
        }
    }

    public void StopFlameThrowerEffect()
    {
        foreach(GameObject go in flameObjects)
        {
            go.SetActive(false);
        }
    }

    public void StartBlastEffect()
    {
        foreach(GameObject go in blastObjects)
        {
            go.SetActive(true);
        }
    }

    public void StopBlastEffect()
    {
        foreach(GameObject go in blastObjects)
        {
            go.SetActive(false);
        }
    }
}
