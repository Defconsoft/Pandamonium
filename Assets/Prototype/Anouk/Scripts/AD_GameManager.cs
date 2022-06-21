using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AD_GameManager : MonoBehaviour
{
    private IDictionary<string, int> fruitScores = new Dictionary<string, int>(){
        {"Apple", 0},
        {"Pear", 0},
        {"Orange", 0}
    };

    void Start()
    {
        AD_EventManager.ItemCollected += IncreaseItemCounter;
    }

    private void IncreaseItemCounter(string type)
    {
        fruitScores[type]++;
        Debug.Log(fruitScores);
    }
}
