using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkAwayFromPlayer : WalkToLocationAction
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
    /// See WalkToLocationAction Update.
    /// </summary>
    public override void Update()
    {
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
    /// Sets the Destination to the Flee Place.
    /// </summary>
    public override void SelectAim()
    {
        Aim = GameManager.Instance.FleePlace.transform.position;
        GameManager.Instance.BlackBoard.Agent.stoppingDistance = 0f;
    }
}
