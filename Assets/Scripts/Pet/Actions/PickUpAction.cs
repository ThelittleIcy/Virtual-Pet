using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAction : AAction
{
    // The GameObject for the Ball.
    private GameObject m_ball;
    // The GameObject for the Mouth, where the Ball should be positioned.
    private GameObject m_mouth;
    /// <summary>
    /// Function, which is called at the Start of the Action. Sets the Ball and Mouth.
    /// Checks, if the Ball is already Picked up (by Player or otherwise).
    /// Picks up the Ball.
    /// </summary>
    public override void Start()
    {
        base.Start();
        m_ball = GameManager.Instance.Ball;
        m_mouth = GameManager.Instance.BlackBoard.MouthTarget;

        if (m_ball.GetComponent<BallController>().IsPickedUpbyPlayer == true)
        {
            HasFinished = true;
            return;
        }


        PickUp();
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
    ///  Turns of the Collider and Rigidbody of the Ball.
    ///  Parents it to the AI and sets it's position to the Mouth Position.
    /// </summary>
    private void PickUp()
    {
        m_ball.GetComponentInChildren<SphereCollider>().enabled = false;
        m_ball.GetComponent<Rigidbody>().isKinematic = true;
        m_ball.GetComponent<Rigidbody>().useGravity = false;
        m_ball.transform.SetParent(m_mouth.gameObject.transform);
        m_ball.transform.position = m_mouth.transform.position;

        m_ball.GetComponent<BallController>().IsPickedUpbyPlayer = true;
        m_ball.GetComponent<BallController>().CanBePickedUp = false;

        HasFinished = true;
    }
}
