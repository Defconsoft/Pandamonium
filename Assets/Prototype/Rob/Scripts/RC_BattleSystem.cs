using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

    public TMPro.TMP_Text dialogueText;


    public GameObject attack1,attack2,attack3, enemyAttack;
    private GameObject tempAttackFX;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    private IEnumerator SetupBattle()
    {
        //Grab the players
        playerPrefab = GameObject.FindWithTag ("Player");
        playerUnit = playerPrefab.GetComponent<RC_BattleUnit>();
        enemyPrefab = GameObject.FindWithTag ("Enemy");
        enemyUnit = enemyPrefab.GetComponent<RC_BattleUnit>();

        dialogueText.text = "A wild" + enemyUnit.unitName + " approaches (probably a made up japanese name).";

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
        dialogueText.text = "You pwned his ass!";

        Instantiate (tempAttackFX, enemyPrefab.transform);

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

        Instantiate (enemyAttack, playerPrefab.transform);
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
            dialogueText.text = "YOU WIN TEH BATTLEZ!!!";
        } else if (state == BattleState.LOST)
        {
            dialogueText.text = "YOU SUCK GO PLAY FORTNITEZ OR SUMMIT";
            AD_EventManager.LostLife();
        }
    }

    private void PlayerTurn()
    {
        dialogueText.text = "Choose an attack";
    }

    public void OnAttackButton(int attackNo)
    {
        if (state != BattleState.PLAYERTURN)
            return;

        if (attackNo == 1) {
            playerUnit.damage = 5;
            tempAttackFX = attack1;
        } else if (attackNo == 2) {
            playerUnit.damage = 20;
            tempAttackFX = attack2;
        } else if (attackNo == 3) {
            playerUnit.damage = 50;
            tempAttackFX = attack3;
        }



        StartCoroutine(PlayerAttack());

        
    }

}
