using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : StateMachineBehaviour
{
    // The Start Time.
    [SerializeField]
    private float m_startTime = 50;
    // The Current Time Left.
    [SerializeField]
    private float m_timeLeft = 0;
    /// <summary>
    /// Sets the current Time to the start Time.
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_timeLeft = m_startTime;
    }
    /// <summary>
    /// Checks, if the current time is up and decreases the current Time.
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(m_timeLeft <= 0)
        {
            animator.SetBool("WaitingFinished", true);
        }
        m_timeLeft -= Time.deltaTime;
    }
    /// <summary>
    /// Called when the State ends. Resets Values.
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("WaitingFinished", false);
    }
}
