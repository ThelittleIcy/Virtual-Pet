using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform [] m_WayPoint;

    [SerializeField]
    private NavMeshAgent m_agent;

    private int m_currentPoint = 0;

    private void Awake()
    {
        if(m_WayPoint.Length == 0)
        {
            Debug.LogError("You need to Give the Enemy Waypoints to walk to");
        }
    }

    private void Update()
    {
        CheckCurrentWayPoint();
        m_agent.SetDestination(m_WayPoint[m_currentPoint].transform.position);
    }

    private void CheckCurrentWayPoint()
    {
        Vector3 dir = m_WayPoint[m_currentPoint].transform.position - transform.position;
        float sqr = dir.sqrMagnitude;
        if (sqr <= 1)
        {
            m_currentPoint++;
            if(m_currentPoint == m_WayPoint.Length)
            {
                m_currentPoint = 0;
                return;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        foreach (BaseBehavior behavior in GameManager.Instance.BlackBoard.AllBehaviors)
        {
            if(behavior.BehaviorIndex == BehavoirEnum.BARK)
            {
                behavior.OnTriggeredEvent.Invoke();
            }   
        }
    }
}
