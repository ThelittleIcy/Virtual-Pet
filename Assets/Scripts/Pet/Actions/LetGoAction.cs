using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetGoAction : AAction
{
    private GameObject m_ball;
    public override void Start()
    {
        base.Start();

        m_ball = GameManager.Instance.Ball;

        LetGo();
    }

    public override void Update()
    {
        base.Update();
        //Debug.Log("LetGo Update");
    }

    public override void Exit()
    {
        base.Exit();
        //Debug.Log("LetGo Exit");
    }

    private void LetGo()
    {
        //m_ball.transform.position = new Vector3(m_ball.transform.position.x, 0, m_ball.transform.position.z);
        m_ball.transform.SetParent(null);
        m_ball.GetComponentInChildren<SphereCollider>().enabled = true;
        m_ball.GetComponent<Rigidbody>().isKinematic = false;
        m_ball.GetComponent<Rigidbody>().useGravity = true;

        m_ball.GetComponent<BallController>().IsPickedUp = false;
        m_ball.GetComponent<BallController>().CanBePickedUp = true;

        HasFinished = true;
    }

    [ContextMenu("IsFinished")]
    public void SetFinished()
    {
        HasFinished = true;
    }
}
