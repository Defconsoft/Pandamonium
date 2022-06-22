using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : Collectible
{
    public string fruitType = "Orange";
    
    public override void Interact()
    {
        // Fire collection event
        AD_EventManager.CollectItem(fruitType);
        // Disable/Destroy
        Destroy(gameObject);    
    }

    public override string GetName()
    {
        return fruitType;
    }
}
