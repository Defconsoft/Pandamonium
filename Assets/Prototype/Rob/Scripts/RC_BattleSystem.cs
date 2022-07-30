using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }


public class RC_BattleSystem : MonoBehaviour
{

    public BattleState state;


    public GameObject playerPrefab;
    private GameObject enemyPrefab;
    RC_BattleUnit playerUnit;
    RC_BattleUnit enemyUnit;

    public RC_BattleHUD playerHUD;
    public RC_BattleHUD enemyHUD;

    public TMPro.TMP_Text dialogueText, playerChat, enemyChat;
    public GameObject PlayerChatbox, EnemyChatbox;
    public string[] ChatString;


    public GameObject attack1,attack2,attack3, enemyAttack;
    private GameObject tempAttackFX;

    [Header("Anouk's crap")]
    public GameObject gameOverDialogue;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        PlayerChatbox.SetActive (false);
        EnemyChatbox.SetActive (false);
    }

    private IEnumerator SetupBattle()
    {
                
        //Grab the players
        playerPrefab = GameObject.FindWithTag ("Player");
        playerUnit = playerPrefab.GetComponent<RC_BattleUnit>();
        enemyPrefab = GameObject.FindWithTag ("Enemy");
        enemyUnit = enemyPrefab.GetComponent<RC_BattleUnit>();

        dialogueText.text = "A wild" + enemyUnit.unitName + " approaches.";

        //set up the huds
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();
                        
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "You got him!";

        if (tempAttackFX != null)
        {
            Instantiate (tempAttackFX, enemyPrefab.transform);
        }
        
        yield return new WaitForSeconds (2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        } else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = "Enemy Attack";
        PlayerChatbox.SetActive(false);
        EnemyChatbox.SetActive(true);
        enemyChat.text = "ROAR!";
        // Instantiate (enemyAttack, playerPrefab.transform);
        int randNum = Random.Range(0, 3);
        enemyUnit.Attack(randNum);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(3f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        } else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }


    }

    private void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "YOU WIN!!!";
        } else if (state == BattleState.LOST)
        {
            dialogueText.text = "YOU SUCK GO PLAY FORTNITEZ OR SUMMIT";
            AD_EventManager.LostLife();
            gameOverDialogue.SetActive(true);            
        }
    }

    private void PlayerTurn()
    {
        dialogueText.text = "Choose an attack";
        PlayerChatbox.SetActive(true);
        EnemyChatbox.SetActive(false);
        playerChat.text = ChatString[Random.Range(0, ChatString.Length)];
    }

    public void OnAttackButton(int attackNo)
    {
        if (state != BattleState.PLAYERTURN)
            return;

        if (attackNo == 1) {
            playerUnit.damage = 0.5f;
            tempAttackFX = null;
        } else if (attackNo == 2) {
            playerUnit.damage = 0.2f;
            tempAttackFX = attack2;
        } else if (attackNo == 3) {
            playerUnit.damage = 0.3f;
            tempAttackFX = attack3;
        }
        string attackTrigger = "Attack" + attackNo.ToString();
        anim.SetTrigger(attackTrigger);

        StartCoroutine(PlayerAttack());
    }

}
