using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_BuildingCleaner : MonoBehaviour
{

    private bool Shrink;
    public float ShrinkDuration;
    public Vector3 TargetScale = Vector3.one * .5f;
    Vector3 startScale;
    float t = 0;

    private void OnEnable() {
        startScale = transform.localScale;
        t = 0;
    }


    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            StartCoroutine(CleanUp());
        }
    }


    private IEnumerator CleanUp(){
        yield return new WaitForSeconds(1f);
        Shrink = true;
        yield return new WaitForSeconds (4f);
        Destroy (this.gameObject);
    }


    void Update() {
        Debug.Log (Shrink);

        if (Shrink){
            // Divide deltaTime by the duration to stretch out the time it takes for t to go from 0 to 1.
            t += Time.deltaTime / ShrinkDuration;
        
            // Lerp wants the third parameter to go from 0 to 1 over time. 't' will do that for us.
            Vector3 newScale = Vector3.Lerp(startScale, TargetScale, t);
            transform.localScale = newScale;
        
            // We're done! We can disable this component to save resources.
            if (t > 1) {
                Shrink = false;
            }
        }
    }



}
