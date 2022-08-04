using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RC_GameManager : MonoBehaviour
{


    public int[] Scores = {0,0,0,0,0,0,0}; // 0 = Cherry, 1 = Pear, 2 = Apple, 3 = Orange, 4 = Poison, 5 = BigSurf, 6 = Parley;
    public TMP_Text[] ScoreElements;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
     

    }


    public void AddNumber(int itemType){

        for (int i = 0; i < Scores.Length; i++)
        {
            if (i == itemType) {
                Scores[i] ++;
            } 
        }

        UpdateScoreUI();
 
    }

    private void UpdateScoreUI()
    {
        for (int i = 0; i < ScoreElements.Length; i++)
        {
            ScoreElements[i].text = Scores[i].ToString();
        }
    }
}
