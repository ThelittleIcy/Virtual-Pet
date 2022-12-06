using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitUpAction : AAction
{
    /// <summary>
    /// Function, which is called at the Start of the Action. Sets up the Action and Animation.
    /// </summary>
    public override void Start()
    {
        base.Start();
        GameManager.Instance.BlackBoard.Agent.enabled = false;
    }
    /// <summary>
    /// See AAction Update.
    /// </summary>
    public override void Update()
    {
        base.Update();
    }
    /// <summary>
    /// See AAction Exit.
    /// </summary>
    public override void Exit()
    {
        base.Exit();
        GameManager.Instance.BlackBoard.Agent.enabled = true;
    }
}
