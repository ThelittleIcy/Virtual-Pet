using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToBallAction : WalkToLocationAction
{
    /// <summary>
    /// See WalkToLocationAction Start. Selects Aim.
    /// </summary>
    public override void Start()
    {
        base.Start();
        SelectAim();
    }
    /// <summary>
    /// See WalkToLocationAction Update. Updates Aim.
    /// </summary>
    public override void Update()
    {
        SelectAim();
        base.Update();
    }
    /// <summary>
    /// See WalkToLocationAction Exit.
    /// </summary>
    public override void Exit()
    {
        base.Exit();
    }
    /// <summary>
    /// Sets the Destination to the Ball.
    /// </summary>
    public override void SelectAim()
    {
        Aim = GameManager.Instance.Ball.transform.position;
        GameManager.Instance.BlackBoard.Agent.stoppingDistance = 1f;
    }
}
