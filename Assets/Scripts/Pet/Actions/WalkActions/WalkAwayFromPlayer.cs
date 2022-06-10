using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAwayFromPlayer : WalkToLocationAction
{
    private  Vector3 m_target;

    [SerializeField]
    private float m_stopDistance = 5f;
    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        SelectAim();
        GameManager.Instance.BlackBoard.Agent.SetDestination(m_target);
        if(Vector3.SqrMagnitude(m_target) >= m_stopDistance * m_stopDistance)
        {
            HasFinished = true;
        }
    }
    public override void Exit()
    {
        base.Exit();
    }

    public override void SelectAim()
    {
        Vector3 dirPlayer = GameManager.Instance.Player.transform.position - 
            GameManager.Instance.BlackBoard.gameObject.transform.position;
        m_target = -dirPlayer;
        GameManager.Instance.BlackBoard.Agent.stoppingDistance = 0f;
    }
}
