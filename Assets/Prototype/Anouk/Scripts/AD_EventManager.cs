using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AD_EventManager : MonoBehaviour
{
    public static event Action<string> ItemCollected;

    public static void CollectItem(string name)
    {
        ItemCollected?.Invoke(name);
    }

}
