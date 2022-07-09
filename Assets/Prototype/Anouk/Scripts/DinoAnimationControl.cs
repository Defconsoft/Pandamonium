using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoAnimationControl : MonoBehaviour
{
    
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        // StartPukeAnim();
    }

    public void StartPukeAnim()
    {
        anim.SetTrigger("PukeAttack");
    }

    public void StartStompAnim()
    {
        anim.SetTrigger("StompAttack");
    }

    public void StartBattleBeginAnim()
    {
        anim.SetTrigger("BattleStart");
    }

    public void StartDeathAnim()
    {
        anim.SetTrigger("Die");
    }
}
