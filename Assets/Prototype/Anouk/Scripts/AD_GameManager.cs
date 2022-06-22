using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AD_GameManager : MonoBehaviour
{
    public ScoreManagerUI fruitScoresUI;

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
        fruitScoresUI.UpdateScoresUI(type, fruitScores[type]);
        Debug.Log(fruitScores[type]);
    }

    public int GetFruitScore(string type)
    {
        return fruitScores[type];
    }
}
