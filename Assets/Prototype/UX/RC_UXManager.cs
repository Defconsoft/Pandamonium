using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class RC_UXManager : MonoBehaviour
{

    public Canvas TitleScreen, ShopScreen, QuestsScreen, CustomiseScreen;


    [Header("QuestScreen")]
    public GameObject Daily;
    public GameObject Weekly;
    public GameObject Highlight1, Highlight2;
    public Button DailyBtn;

    [Header("ShopScreen")]
    public GameObject [] Sidebars;
    public GameObject [] Headers;
    public GameObject [] Content;
    public GameObject [] Buttons;
    public Button CrittersBtn;

    public Image Overlay;
    public GameObject[] Cards;
    private int currentSelected;


    [Header("CustomiseScreen")]  
    public Animator anim;
    public GameObject wizardhat, crown, staff;
    public GameObject StarEffect;
    public Image powerfill;
    public Image stealthfill;
    public TMPro.TMP_Text powerText, stealthText;


    // Start is called before the first frame update
    void Start()
    {
        
        TitleScreen.enabled = true;
        ShopScreen.enabled = false;
        QuestsScreen.enabled = false;
        CustomiseScreen.enabled = false;

    }


    public void TitleBtns (int newMenu) {

        switch (newMenu)
		{
		case 0: // Loads the game
            SceneManager.LoadScene("CombinedRC");
        break;

		case 1: // Loads quest screen
            TitleScreen.enabled = false;
            ShopScreen.enabled = false;
            QuestsScreen.enabled = true;
            CustomiseScreen.enabled = false;
            Daily.SetActive (true);
            Weekly.SetActive(false);
            Highlight1.SetActive (true);
            Highlight2.SetActive (false);
            DailyBtn.Select();
        break;

		case 2: // Loads Customise screen
            TitleScreen.enabled = false;
            ShopScreen.enabled = false;
            QuestsScreen.enabled = false;
            CustomiseScreen.enabled = true;
        break;

        case 3: // Loads Shop screen
            TitleScreen.enabled = false;
            ShopScreen.enabled = true;
            QuestsScreen.enabled = false;
            CustomiseScreen.enabled = false;
            CrittersBtn.Select();
            SetShopArrays (0);
        break;

        }
    }

    public void QuestBtns (int questState){

        switch (questState)
		{
		case 0: // Daily
            Daily.SetActive (true);
            Weekly.SetActive (false);
            Highlight1.SetActive (true);
            Highlight2.SetActive (false);
        break;

		case 1: // Monthly
            Daily.SetActive (false);
            Weekly.SetActive (true);
            Highlight1.SetActive (false);
            Highlight2.SetActive (true);
        break;

        } 
    }

    public void BackBtn(){
        TitleScreen.enabled = true;
        ShopScreen.enabled = false;
        QuestsScreen.enabled = false;
    }


    public void ShopTabButton (int tabSelected){
        switch (tabSelected)
		{
		case 0: // Critters
            SetShopArrays (0);
        break;

		case 1: // Items
            SetShopArrays (1);
        break;

		case 2: // Items
            SetShopArrays (2);
        break;

		case 3: // Items
            SetShopArrays (3);
        break;
        }         
    }    



    public void SetShopArrays(int currentTab){
        
        for (int i = 0; i < Sidebars.Length; i++)
        {
            if (i == currentTab){
                Sidebars[i].SetActive(true);
            } else {
                Sidebars[i].SetActive(false);
            }
        }

        for (int i = 0; i < Headers.Length; i++)
        {
            if (i == currentTab){
                Headers[i].SetActive(true);
            } else {
                Headers[i].SetActive(false);
            }
        }

        for (int i = 0; i < Content.Length; i++)
        {
            if (i == currentTab){
                Content[i].SetActive(true);
            } else {
                Content[i].SetActive(false);
            }
        }

        for (int i = 0; i < Buttons.Length; i++)
        {
            if (i == currentTab){
                Buttons[i].SetActive(true);
            } else {
                Buttons[i].SetActive(false);
            }
        }


    }

    public void ShopItemBtn (int selectedItem){

            currentSelected = selectedItem;
        switch (selectedItem)
		{
		case 0: // Critters
            Overlay.DOFade (1, 0.5f);
            Cards[selectedItem].SetActive (true);
            Cards[selectedItem].transform.DOPunchScale(new Vector3(.3f, .3f, .3f), 1f, 10, 1f);
        break;

		case 1: // Items
            Overlay.DOFade (1, 0.5f);
            Cards[selectedItem].SetActive (true);
            Cards[selectedItem].transform.DOPunchScale(new Vector3(.3f, .3f, .3f), 1f, 10, 1f);           
        break;

		case 2: // Items
            Overlay.DOFade (1, 0.5f);
            Cards[selectedItem].SetActive (true);
            Cards[selectedItem].transform.DOPunchScale(new Vector3(.3f, .3f, .3f), 1f, 10, 1f);          
        break;

		case 3: // Items
            Overlay.DOFade (1, 0.5f);
            Cards[selectedItem].SetActive (true);
            Cards[selectedItem].transform.DOPunchScale(new Vector3(.3f, .3f, .3f), 1f, 10, 1f);          
        break;
        }    


    }

    public void CloseCard(){
        Overlay.DOFade (0, 0.5f);
        Cards[currentSelected].SetActive (false);
    }




    public void Wizardhat() {
        wizardhat.SetActive(true);
        crown.SetActive(false);
        anim.SetTrigger("attract1");
        powerfill.fillAmount = 0.5f;
        powerText.text = "50%";
    }

    public void Crownhat() {
        wizardhat.SetActive(false);
        crown.SetActive(true);
        anim.SetTrigger("attract1");
        powerfill.fillAmount = 0.8f;
        powerText.text = "80%";
    }


    public void Staff() {
        staff.SetActive(true);
        stealthfill.fillAmount = 0.6f;
        anim.SetTrigger("attract0");
        stealthText.text = "60%";
    }







}

