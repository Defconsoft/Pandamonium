using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RC_BattleHUD : MonoBehaviour
{
    public Image hpSlider;


    public void SetHUD(RC_BattleUnit unit) {
        hpSlider.fillAmount = unit.currentHP;
    }

    public void SetHP (float hp){
        hpSlider.fillAmount = hp;
    }


}
