using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_BattleUnit : MonoBehaviour
{

    public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHP;
    public int currentHP;
    public Animator anim;

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            StartCoroutine(Die());
            return true;
        }
        else 
            return false;
    }

    public void Attack(int attackNumber)
    {
        string attackTrigger = "Attack" + attackNumber.ToString();
        Debug.Log(attackTrigger);
        anim.SetTrigger(attackTrigger);
    }

    IEnumerator Die()
    {
        anim.SetBool("Dead", true);
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }


}
