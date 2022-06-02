using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : StateMachineBehaviour
{
    [SerializeField]
    private float m_startTime = 50;
    [SerializeField]
    private float m_timeLeft = 0;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_timeLeft = m_startTime;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(m_timeLeft <= 0)
        {
            animator.SetBool("WaitingFinished", true);
        }
        m_timeLeft -= Time.deltaTime;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("WaitingFinished", false);
    }
}
