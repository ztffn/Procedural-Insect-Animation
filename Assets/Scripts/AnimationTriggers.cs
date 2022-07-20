using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggers : MonoBehaviour
{
    Animator m_Animator;
public bool isWalking;
public bool isDead;
public bool isWorking;
public bool isEating;
public bool isIdle;

    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //Press the up arrow button to reset the trigger and set another one
        if (Input.GetKeyDown(KeyCode.X))
        {
            //Send the message to the Animator to activate the trigger parameter named "Attack"
            m_Animator.SetTrigger("Attack");
            m_Animator.ResetTrigger("Damage");
            
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Send the message to the Animator to activate the trigger parameter named "Attack"
            m_Animator.SetTrigger("Damage");
            m_Animator.ResetTrigger("Attack");
        }
        //Start animation for eating
        if (isEating)
        { m_Animator.SetBool("Eat", true); }
        else { m_Animator.SetBool("Eat", false); }
       
        if (isDead)
        { m_Animator.SetBool("Dead", true); }
        else { m_Animator.SetBool("Dead", false); }
        
        if (isWorking)
        { m_Animator.SetBool("Work", true); }
        else { m_Animator.SetBool("Work", false); }
        
        if (isIdle)
        { m_Animator.SetBool("Idle", true); }
        else { m_Animator.SetBool("Idle", false); }
        
        if (isWalking)
        { m_Animator.SetBool("Walk", true); }
        else { m_Animator.SetBool("Walk", false); }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            //Reset the other triggers
            m_Animator.ResetTrigger("Attack");
            m_Animator.ResetTrigger("Work");
            m_Animator.ResetTrigger("Damage");
            m_Animator.ResetTrigger("Eat");
            m_Animator.ResetTrigger("Dead");    
        }
    }
}

