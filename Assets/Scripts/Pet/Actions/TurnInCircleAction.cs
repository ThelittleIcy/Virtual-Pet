using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnInCircleAction : AAction
{
    public override void Start()
    {
        base.Start();
        Handler.ActivateTurning();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();

        Handler.DeActivateTurning();
    }

    [ContextMenu("IsFinished")]
    public void SetFinished()
    {
        HasFinished = true;
    }
}
