using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToLocationAction : AAction
{
    public Vector3 Aim { get => m_aim; set => m_aim = value; }
    [SerializeField]
    private Vector3 m_aim;
    public override void Start()
    {
        GameManager.Instance.BlackBoard.Agent.isStopped = false;
        base.Start();

        Handler.ActivateWalking();
        //ChooseAim();
    }

    public override void Update()
    {
        base.Update();
        if (GameManager.Instance.BlackBoard.Agent.velocity == Vector3.zero)
        {
            Handler.DeActivateWalking();
        }
        else
        {
            Handler.ActivateWalking();
        }
        Move();
    }

    public override void Exit()
    {
        base.Exit();
        GameManager.Instance.BlackBoard.Agent.stoppingDistance = 1f;
        GameManager.Instance.BlackBoard.Agent.isStopped = true;
        Handler.DeActivateWalking();
        //Debug.Log("WalkTo Exit");
    }

    public virtual void SelectAim()
    {

    }

    //private void ChooseAim()
    //{
    //    switch (Behaviour)
    //    {
    //        case BehavoirEnum.NOTHING:
    //            break;
    //        case BehavoirEnum.BARK:
    //            Aim = GameManager.Instance.Enemy;
    //            GameManager.Instance.BlackBoard.Agent.stoppingDistance = 4f;
    //            break;
    //        case BehavoirEnum.PICKUP:
    //            Aim = GameManager.Instance.Ball;
    //            Debug.Log("Ball: " + GameManager.Instance.Ball.transform.position);
    //            GameManager.Instance.BlackBoard.Agent.stoppingDistance = 1f;
    //            break;
    //        case BehavoirEnum.RUNAWAY:
    //            Aim.transform.position = GameManager.Instance.Ball.transform.position;
    //            GameManager.Instance.BlackBoard.Agent.stoppingDistance = 1f;
    //            break;
    //        case BehavoirEnum.SIT:
    //            break;
    //        case BehavoirEnum.COME:
    //            Aim = GameManager.Instance.Player;
    //            GameManager.Instance.BlackBoard.Agent.stoppingDistance = 3f;
    //            break;
    //        case BehavoirEnum.RUNTOTARGET:
    //            Aim = GameManager.Instance.Pillow;
    //            GameManager.Instance.BlackBoard.Agent.stoppingDistance = 1f;
    //            break;
    //        case BehavoirEnum.LETGO:
    //            Aim = GameManager.Instance.Player;
    //            GameManager.Instance.BlackBoard.Agent.stoppingDistance = 3f;
    //            break;
    //        default:
    //            break;
    //    }
    //}
    private void Move()
    {
        GameManager.Instance.BlackBoard.Agent.SetDestination(Aim);
        if (isClose())
        {
            HasFinished = true;
        }
    }

    private bool isClose()
    {
        if (CalculateDistanceToAim() <= GameManager.Instance.BlackBoard.Agent.stoppingDistance)
        {
            return true;
        }
        return false;
    }

    private float CalculateDistanceToAim()
    {
        return Vector3.Distance(Aim, GameManager.Instance.BlackBoard.gameObject.transform.position);
    }

    [ContextMenu("IsFinished")]
    public void SetFinished()
    {
        HasFinished = true;
    }
}
