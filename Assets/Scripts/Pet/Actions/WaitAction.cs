using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAction : AAction
{
    // The Timer at the Start.
    [SerializeField]
    private float m_startTimer = 5f;
    // The Current Timer.
    [SerializeField]
    private float m_currentTime = 0f;
    /// <summary>
    /// See AAction Start. Sets Animation and resets the current Time to the start Time.
    /// </summary>
    public override void Start()
    {
        base.Start();
        m_currentTime = m_startTimer;
        Handler.ActivateIdle();
    }
    /// <summary>
    /// See AAction Update. Reduces Timer.
    /// </summary>
    public override void Update()
    {
        base.Update();
        ReduceAndCheckTimer();
    }
    /// <summary>
    /// See AAction Exit. 
    /// </summary>
    public override void Exit()
    {
        base.Exit();
    }
    /// <summary>
    /// Reduces the Timer and Checks, if it is zero.
    /// </summary>
    private void ReduceAndCheckTimer()
    {
        if (m_currentTime > 0)
        {
            m_currentTime--;
        }
        else
        {
            HasFinished = true;
        }
    }
}
