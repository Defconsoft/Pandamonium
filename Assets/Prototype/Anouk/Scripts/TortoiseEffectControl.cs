using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortoiseEffectControl : MonoBehaviour
{
    public GameObject[] flameObjects;
    public GameObject[] blastObjects;
    public float impactDelayFlame = 0.4f;
    public float impactDelayBlast = 0.5f;
    public Animator playerAnim;
    
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
        StartCoroutine(DelayOuch(impactDelayFlame));
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
        StartCoroutine(DelayOuch(impactDelayBlast));
    }

    public void StopBlastEffect()
    {
        foreach(GameObject go in blastObjects)
        {
            go.SetActive(false);
        }
    }

    IEnumerator DelayOuch(float delay)
    {
        yield return new WaitForSeconds(delay);
        AD_EventManager.TookDamage();
        playerAnim.SetTrigger("Ouch");
    }
}
