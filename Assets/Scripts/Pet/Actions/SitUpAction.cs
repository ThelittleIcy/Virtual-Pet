using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitUpAction : AAction
{
    // In Animation HasFinshed setzten
    public override void Start()
    {
        base.Start();
        GameManager.Instance.BlackBoard.Agent.enabled = false;
        //Debug.Log("SitUp Start");
    }

    public override void Update()
    {
        base.Update();
        //Debug.Log("SitUp Update");
    }

    public override void Exit()
    {
        base.Exit();
        GameManager.Instance.BlackBoard.Agent.enabled = true;
        //Debug.Log("SitUp Exit");
    }

    [ContextMenu("IsFinished")]
    public void SetFinished()
    {
        HasFinished = true;
    }
}
