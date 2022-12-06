using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetGoAction : AAction
{
    // The Ball.
    private GameObject m_ball;

    /// <summary>
    /// Function, which is called at the Start of the Action. Sets the Ball and Lets it go.
    /// </summary>
    public override void Start()
    {
        base.Start();

        m_ball = GameManager.Instance.Ball;

        LetGo();
    }
    /// <summary>
    /// See AAction Update.
    /// </summary>
    public override void Update()
    {
        base.Update();
    }
    /// <summary>
    /// See AAction Exit.
    /// </summary>
    public override void Exit()
    {
        base.Exit();
    }
    /// <summary>
    /// Turns on the Rigidbody and Collider of the Ball and unparents it from the AI.
    /// The Ball can be Picked up Again. 
    /// Ends this Action.
    /// </summary>
    private void LetGo()
    {
        m_ball.transform.SetParent(null);
        m_ball.GetComponentInChildren<SphereCollider>().enabled = true;
        m_ball.GetComponent<Rigidbody>().isKinematic = false;
        m_ball.GetComponent<Rigidbody>().useGravity = true;

        m_ball.GetComponent<BallController>().IsPickedUpbyPlayer = false;
        m_ball.GetComponent<BallController>().CanBePickedUp = true;

        HasFinished = true;
    }
}
