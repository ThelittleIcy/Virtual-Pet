using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAction : AAction
{
    private GameObject m_ball;
    private GameObject m_mouth;

    public override void Start()
    {
        base.Start();
        m_ball = GameManager.Instance.Ball;
        m_mouth = GameManager.Instance.BlackBoard.MouthTarget;
        PickUp();
        //Debug.Log("PickUp Start");
    }

    public override void Update()
    {
        base.Update();
        //Debug.Log("PickUp Update");
    }

    public override void Exit()
    {
        base.Exit();
        //Debug.Log("PickUp Exit");
    }

    private void PickUp()
    {
        m_ball.GetComponentInChildren<SphereCollider>().enabled = false;
        m_ball.GetComponent<Rigidbody>().isKinematic = true;
        m_ball.GetComponent<Rigidbody>().useGravity = false;
        m_ball.transform.SetParent(m_mouth.gameObject.transform);
        m_ball.transform.position = m_mouth.transform.position;
        Debug.Log("Mouth" + m_mouth.transform.position + " Ball" + m_ball.transform.position);
        //m_ball.transform.position = m_mouth.transform.position;
        HasFinished = true;
    }

    [ContextMenu("IsFinished")]
    public void SetFinished()
    {
        HasFinished = true;
    }
}
