using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAction : AAction
{
    [SerializeField]
    private float m_startTimer = 5f;
    [SerializeField]
    private float m_currentTime = 0f;
    public override void Start()
    {
        base.Start();
        m_currentTime = m_startTimer;
        Handler.ActivateIdle();
        //Debug.Log("Wait Start");
    }

    public override void Update()
    {
        base.Update();
        ReduceAndCheckTimer();
        //Debug.Log("Wait Update");
    }

    public override void Exit()
    {
        base.Exit();
        //Debug.Log("Wait Exit");
    }

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

    [ContextMenu("IsFinished")]
    public void SetFinished()
    {
        HasFinished = true;
    }
}
