using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Collectible
{
    public string fruitType = "Apple";
    
    public override void Interact()
    {
        // Fire collection event
        AD_EventManager.CollectItem(fruitType);
        // Disable/Destroy
        Destroy(gameObject);    
    }
}
