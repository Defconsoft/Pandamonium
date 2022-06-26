using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AD_GameManager : MonoBehaviour
{
    public ScoreManagerUI fruitScoresUI;
    public int lives = 3;

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
        AD_EventManager.LifeLost += LoseLife;
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

    private void LoseLife()
    {
        lives--;
        if (lives == 0)
        {
            // Game over
            Debug.Log("Game over");
        }
    }

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
