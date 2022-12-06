using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAction : WalkToLocationAction
{
    /// <summary>
    /// Function, which is called at the Start of the Action. Sets up this Action and Animation.
    /// </summary>
    public override void Start()
    {
        base.Start();
        Handler.ActivateWalking();
        GameManager.Instance.BlackBoard.Agent.isStopped = false;
        GameManager.Instance.BlackBoard.Agent.stoppingDistance = 3f;
    }
    /// <summary>
    /// Selects the Aim and Animation and Moves to the Destination. 
    /// Does not check, if it is close.
    /// This Action will only end, when the Player ends it.
    /// </summary>
    public override void Update()
    {
        SelectAim();
        DetermineCurrentAnimation();
        Move();
    }
    /// <summary>
    /// Function, which is called at the End of the Action. Resets this Action and Animation.
    /// </summary>
    public override void Exit()
    {
        base.Exit();
    }
    /// <summary>
    /// Sets the Destination to the Player.
    /// </summary>
    public override void SelectAim()
    {
        Aim = GameManager.Instance.Player.transform.position;
        GameManager.Instance.BlackBoard.Agent.stoppingDistance = 1f;
    }
}
