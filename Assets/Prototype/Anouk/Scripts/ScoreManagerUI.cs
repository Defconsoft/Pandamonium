using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerUI : MonoBehaviour
{
    private IDictionary<string, TMPro.TextMeshProUGUI> fruitScores = new Dictionary<string, TMPro.TextMeshProUGUI>(){};
    
    // Start is called before the first frame update
    void Start()
    {
        // fill dictionary with all fruit text holders
        TMPro.TextMeshProUGUI[] scoreHolders = gameObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>();
        foreach(TMPro.TextMeshProUGUI scoreHolder in scoreHolders)
        {
            fruitScores.Add(scoreHolder.transform.parent.name, scoreHolder);
        }
    }

    public void UpdateScoresUI(string fruitType, int newScore)
    {
        fruitScores[fruitType].text = ": " + newScore.ToString();
    }
}
