using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkAwayFromPlayer : WalkToLocationAction
{
    public override void Start()
    {
        base.Start();
        SelectAim();
    }
    public override void Update()
    {
        base.Update();
    }
    public override void Exit()
    {
        base.Exit();
    }

    public override void SelectAim()
    {
        Aim = GameManager.Instance.FleePlace;
        GameManager.Instance.BlackBoard.Agent.stoppingDistance = 0f;
    }
}
