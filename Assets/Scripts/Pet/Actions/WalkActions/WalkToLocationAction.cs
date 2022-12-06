using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToLocationAction : AAction
{
    // The Destination, to which this gameObject should move to.
    public Vector3 Aim { get => m_aim; set => m_aim = value; }
    [SerializeField]
    private Vector3 m_aim;

    /// <summary>
    /// Function, which is called at the Start of the Action. Sets up this Action and Animation.
    /// </summary>
    public override void Start()
    {
        GameManager.Instance.BlackBoard.Agent.isStopped = false;
        base.Start();

        Handler.ActivateWalking();
    }
    /// <summary>
    /// Moves this GameObject to the Destination. Checks if it is still moving.
    /// </summary>
    public override void Update()
    {
        base.Update();
        Move();
        DetermineCurrentAnimation();
        CheckFinished();
    }
    /// <summary>
    /// Handles the End of this Action. Stops the NavmeshAgent.
    /// </summary>
    public override void Exit()
    {
        base.Exit();
        GameManager.Instance.BlackBoard.Agent.stoppingDistance = 1f;
        GameManager.Instance.BlackBoard.Agent.isStopped = true;
        Handler.DeActivateWalking();
    }
    /// <summary>
    /// Function, which Defines the Aim (or Destination).
    /// </summary>
    public virtual void SelectAim()
    {

    }

    /// <summary>
    /// Moves the NavmeshAgent.
    /// </summary>
    public virtual void Move()
    {
        GameManager.Instance.BlackBoard.Agent.SetDestination(Aim);
    }
    /// <summary>
    /// Ends the Action, when the Navmesh is close to the Destination.
    /// </summary>
    public virtual void CheckFinished()
    {
        if (isClose())
        {
            HasFinished = true;
        }
    }
    /// <summary>
    /// Sets the Animation.
    /// </summary>
    public void DetermineCurrentAnimation()
    {
        if (GameManager.Instance.BlackBoard.Agent.velocity == Vector3.zero)
        {
            Handler.DeActivateWalking();
        }
        else
        {
            Handler.ActivateWalking();
        }
    }
    /// <summary>
    /// Checks, if the NavmeshAgent is close to the Destination
    /// </summary>
    /// <returns>true, if it close; false if it is not close</returns>
    private bool isClose()
    {
        if (CalculateDistanceToAim() <= GameManager.Instance.BlackBoard.Agent.stoppingDistance)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Calculates the Distance to the Destination.
    /// </summary>
    /// <returns>float distance</returns>
    private float CalculateDistanceToAim()
    {
        return Vector3.Distance(Aim, GameManager.Instance.BlackBoard.gameObject.transform.position);
    }
}
