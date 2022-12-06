using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigAction : AAction
{
    /// <summary>
    /// Function, which is called at the Start of the Action. Sets up this Action and Animation.
    /// </summary>
    public override void Start()
    {
        base.Start();
        Handler.ActivateDigging();
    }
    /// <summary>
    /// See AAction Update.
    /// </summary>
    public override void Update()
    {
        base.Update();
    }
    /// <summary>
    /// Function, which is called at the End of the Action. Resets this Action and Animation.
    /// </summary>
    public override void Exit()
    {
        base.Exit();

        Handler.DeActivateDiggin();
    }
}
