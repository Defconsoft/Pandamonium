using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CollisionPoof : MonoBehaviour
{
    public VisualEffect poofVFX;
    
    // Start is called before the first frame update
    void Start()
    {
        if (poofVFX != null)
        {
            poofVFX.Stop();
            poofVFX.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if (other.tag == "Enemy")
        // {
        //     StartCoroutine(PoofEffect());
        // }
        StartCoroutine(PoofEffect());
    }

    IEnumerator PoofEffect()
    {

        if (poofVFX != null)
        {
            poofVFX.gameObject.SetActive(true);
            poofVFX.Play();
        }

        yield return new WaitForSeconds(2);

        if (poofVFX != null)
        {
            poofVFX.Stop();
            poofVFX.gameObject.SetActive(false);
        }
    }
}
