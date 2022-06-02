using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitDownAction : AAction
{
    // In Animation HasFinshed setzten
    public override void Start()
    {
        base.Start();
        GameManager.Instance.BlackBoard.Agent.enabled = false;
        Handler.ActivateSitting();
        //Debug.Log("SitDown Start");
    }

    public override void Update()
    {
        base.Update();
        //Debug.Log("SitDown Update");
    }

    public override void Exit()
    {
        base.Exit();
        GameManager.Instance.BlackBoard.Agent.enabled = true;
        Handler.DeActivateSitting();
        //Debug.Log("SitDown Exit");
    }

    [ContextMenu("IsFinished")]
    public void SetFinished()
    {
        HasFinished = true;
    }
}
