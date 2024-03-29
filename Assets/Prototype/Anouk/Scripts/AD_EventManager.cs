using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AD_EventManager : MonoBehaviour
{
    public static event Action<string> ItemCollected;
    public static event Action<string> AnimalCollected;
    public static event Action LifeLost;
    public static event Action DamageDealt;

    public static void LostLife()
    {
        LifeLost?.Invoke();
    }

    public static void TookDamage()
    {
        DamageDealt?.Invoke();
    }

    public static void CollectItem(string name)
    {
        ItemCollected?.Invoke(name);
    }

    public static void CollectAnimal(string name)
    {
        AnimalCollected?.Invoke(name);
    }

}
