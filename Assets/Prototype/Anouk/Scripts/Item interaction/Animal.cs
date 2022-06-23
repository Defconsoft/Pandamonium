using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : Interactable
{
    public string animalType = "";

    // TODO: add walking around behavior
    
    public override void Interact()
    {
        // Fire collection event
        AD_EventManager.CollectAnimal(animalType);
        // Disable/Destroy
        Destroy(gameObject);    
    }

    public override string GetName()
    {
        return animalType;
    }
}
