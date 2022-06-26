using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RC_BattleHUD : MonoBehaviour
{
    public TMPro.TMP_Text nameText, levelText;
    public Slider hpSlider;


    public void SetHUD(RC_BattleUnit unit) {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void SetHP (int hp){
        hpSlider.value = hp;
    }


}
