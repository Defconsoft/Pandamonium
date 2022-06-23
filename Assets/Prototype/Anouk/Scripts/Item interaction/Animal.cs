using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : Interactable
{
    public string animalType = "";
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        StartCoroutine(WalkAround());
    }

    // TODO: add walking around behavior
    
    public override void Interact()
    {
        // Fire collection event
        AD_EventManager.CollectAnimal(animalType);
        // Disable/Destroy
        Destroy(gameObject);    
    }

    private IEnumerator WalkAround()
    {
        while(gameObject.activeSelf)
        {
            Vector3 randomPoint = Random.insideUnitCircle * 10;
            randomPoint += transform.position;
            UnityEngine.AI.NavMeshHit hit;
            UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 10, 1);
            Vector3 finalPosition = hit.position;
            agent.SetDestination(finalPosition);
            yield return new WaitForSeconds(4);
        }
    }
}
