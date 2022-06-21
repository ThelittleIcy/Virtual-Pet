using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToPillow : WalkToLocationAction
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
        Aim = GameManager.Instance.Pillow.transform.position;
        GameManager.Instance.BlackBoard.Agent.stoppingDistance = 1f;
    }
}
