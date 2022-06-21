using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAction : AAction
{

    public override void Start()
    {
        base.Start();
        Handler.ActivateWalking();
        GameManager.Instance.BlackBoard.Agent.isStopped = false;
        GameManager.Instance.BlackBoard.Agent.stoppingDistance = 3f;
    }

    public override void Update()
    {
        base.Update();
        if (GameManager.Instance.BlackBoard.Agent.velocity == Vector3.zero)
        {
            Handler.DeActivateWalking();
        }
        else
        {
            Handler.ActivateWalking();
        }
        Move();
    }

    public override void Exit()
    {
        base.Exit();
        Handler.DeActivateWalking();
        GameManager.Instance.BlackBoard.Agent.stoppingDistance = 1f;
        GameManager.Instance.BlackBoard.Agent.isStopped = true;
    }

    private void Move()
    {
        GameManager.Instance.BlackBoard.Agent.SetDestination(GameManager.Instance.Player.transform.position);
    }

    [ContextMenu("IsFinished")]
    public void SetFinished()
    {
        HasFinished = true;
    }
}
