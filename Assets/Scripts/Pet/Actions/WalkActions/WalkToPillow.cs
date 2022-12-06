using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToPillow : WalkToLocationAction
{
    /// <summary>
    /// see WalkToLocationAction Start. Selects Aim.
    /// </summary>
    public override void Start()
    {
        base.Start();
        SelectAim();
    }
    /// <summary>
    /// see WalkToLocationAction Update.
    /// </summary>
    public override void Update()
    {
        base.Update();
    }
    /// <summary>
    /// see WalkToLocationAction Exit.
    /// </summary>
    public override void Exit()
    {
        base.Exit();
    }
    /// <summary>
    /// Sets the Destination to the Pillow.
    /// </summary>
    public override void SelectAim()
    {
        Aim = GameManager.Instance.Pillow.transform.position;
        GameManager.Instance.BlackBoard.Agent.stoppingDistance = 1f;
    }
}
