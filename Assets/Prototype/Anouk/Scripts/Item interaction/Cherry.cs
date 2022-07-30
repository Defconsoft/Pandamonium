using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : Collectible
{
    public string fruitType = "Cherry";
    
    public override void Interact()
    {
        // Fire collection event
        AD_EventManager.CollectItem(fruitType);
        // Disable/Destroy
        Destroy(gameObject);    
    }
}
