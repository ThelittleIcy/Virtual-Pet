using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkAction : AAction
{

    public override void Start()
    {
        base.Start();
        GameManager.Instance.BlackBoard.Agent.enabled = false;
        Handler.ActivateBarking();
        //Debug.Log("Bark Start");
    }

    public override void Update()
    {
        base.Update();
        //Debug.Log("Bark Update");
    }

    public override void Exit()
    {
        base.Exit();
        GameManager.Instance.BlackBoard.Agent.enabled = true;
        Handler.DeActivateBarking();
        //Debug.Log("Bark Exit");
    }

    [ContextMenu("IsFinished")]
    public void SetFinished()
    {
        HasFinished = true;
    }
}
