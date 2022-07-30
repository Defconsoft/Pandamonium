using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_BattleUnit : MonoBehaviour
{

    public string unitName;
    public int unitLevel;

    public float damage;

    public int maxHP;
    public float currentHP;
    public Animator anim;
    public List<string> ignoreCols = new List<string>();

    public bool TakeDamage(float dmg)
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
        anim.SetTrigger(attackTrigger);
    }

    IEnumerator Die()
    {
        anim.SetBool("Dead", true);
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AttackItem" && !ignoreCols.Contains(other.name))
        {
            AD_EventManager.TookDamage();
            anim.SetTrigger("Ouch");
        }
    }


}
