using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform[] m_WayPoint;

    [SerializeField]
    private NavMeshAgent m_agent;
    [SerializeField]
    private float m_waitTime = 5f;
    private float m_currentWaitTime = 0f;

    private int m_currentPoint = 0;
    private bool m_isWaiting = false;

    private void Awake()
    {
        if (m_WayPoint.Length == 0)
        {
            Debug.LogError("You need to Give the Enemy Waypoints to walk to");
        }
    }

    private void Update()
    {
        CheckCurrentWayPoint();
        if (!m_isWaiting)
        {
            m_agent.SetDestination(m_WayPoint[m_currentPoint].transform.position);
        }
    }

    private void CheckCurrentWayPoint()
    {
        Vector3 dir = m_WayPoint[m_currentPoint].transform.position - transform.position;
        float sqr = dir.sqrMagnitude;
        if (sqr <= 1)
        {
            m_currentPoint++;
            m_isWaiting = true;
            m_currentWaitTime = m_waitTime;
            StartCoroutine(Wait());
            if (m_currentPoint == m_WayPoint.Length)
            {
                m_currentPoint = 0;
                return;
            }

        }
    }

    private IEnumerator Wait()
    {
        while (true)
        {
            if (m_currentWaitTime <= 0)
            {
                m_isWaiting = false;
                yield break;
            }
            else
            {
                m_currentWaitTime--;
                yield return new WaitForSeconds(1f);
            }   
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //foreach (BaseBehavior behavior in GameManager.Instance.BlackBoard.AllBehaviors)
        //{
        //    if (behavior.BehaviorIndex == BehavoirEnum.BARK)
        //    {
        //        behavior.OnTriggeredEvent.Invoke();
        //    }
        //}
    }
}
