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

    private List<string> collectedAnimals = new List<string>();

    void Start()
    {
        AD_EventManager.ItemCollected += IncreaseItemCounter;
        AD_EventManager.AnimalCollected += AddAnimalToCollection;
    }

    private void IncreaseItemCounter(string type)
    {
        fruitScores[type]++;
        fruitScoresUI.UpdateScoresUI(type, fruitScores[type]);
    }

    private void AddAnimalToCollection(string animalType)
    {
        collectedAnimals.Add(animalType);
    }

    public int GetFruitScore(string type)
    {
        return fruitScores[type];
    }
}
