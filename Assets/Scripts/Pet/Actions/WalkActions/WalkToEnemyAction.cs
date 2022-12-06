using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToEnemyAction : WalkToLocationAction
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
    /// see WalkToLocationAction Update. Updates Aim.
    /// </summary>
    public override void Update()
    {
        SelectAim();
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
    /// Sets the Destination to the Enemy.
    /// </summary>
    public override void SelectAim()
    {
        Aim = GameManager.Instance.Enemy.transform.position;
        GameManager.Instance.BlackBoard.Agent.stoppingDistance = 6f;
    }
}
