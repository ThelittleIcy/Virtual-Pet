using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigAction : AAction
{

    public override void Start()
    {
        base.Start();
        Handler.ActivateDigging();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();

        Handler.DeActivateDiggin();
    }

    [ContextMenu("IsFinished")]
    public void SetFinished()
    {
        HasFinished = true;
    }
}
