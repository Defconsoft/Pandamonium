using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocAttack : MonoBehaviour
{
    public float startY = -1;
    public float endY = 2;
    public float lerpDuration = 0.8f;
    private float tempY;
    private float elapsedTime = 0;

    // Update is called once per frame
    void OnEnable()
    {
        startY = transform.position.y - 2f;
        endY = transform.position.y + 1f;
        StartCoroutine(LerpCroc(Time.deltaTime));
    }

    public IEnumerator LerpCroc(float timeStep)
    {
        elapsedTime = 0;
        Vector3 currentPos = transform.position;
        
        while (elapsedTime < lerpDuration)
        {
            tempY = Mathf.Lerp(startY, endY, elapsedTime / lerpDuration);
            transform.position = new Vector3(currentPos.x, tempY, currentPos.z);
            yield return new WaitForSeconds(timeStep);
            elapsedTime += timeStep;
        }
        tempY = endY;
        transform.position = new Vector3(currentPos.x, tempY, currentPos.z);

        yield return new WaitForSeconds(1);
        
        tempY = startY;
        transform.position = new Vector3(currentPos.x, tempY, currentPos.z);
        Destroy(gameObject);
    }
}
