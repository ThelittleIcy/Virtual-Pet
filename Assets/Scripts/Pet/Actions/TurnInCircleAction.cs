using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnInCircleAction : AAction
{
    /// <summary>
    /// See AAction Start. Sets Animation
    /// </summary>
    public override void Start()
    {
        base.Start();
        Handler.ActivateTurning();
    }
    /// <summary>
    /// See AAction Update.
    /// </summary>
    public override void Update()
    {
        base.Update();
    }
    /// <summary>
    /// See AAction Exit. Resets Animation.
    /// </summary>
    public override void Exit()
    {
        base.Exit();

        Handler.DeActivateTurning();
    }
}
