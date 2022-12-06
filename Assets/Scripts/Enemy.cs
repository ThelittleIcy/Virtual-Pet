using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // The Waypoint to which the Enemy moves.
    [SerializeField]
    private Transform[] m_WayPoint;
    // The Animator for animations.
    [SerializeField]
    private Animator m_animator;
    // The Navmeshagent of the Enemy.
    [SerializeField]
    private NavMeshAgent m_agent;
    // The time to wait at the different Waypoints.
    [SerializeField]
    private float m_waitTime = 5f;
    // The currently time left.
    private float m_currentWaitTime = 0f;
    // The Current Waypoint index.
    private int m_currentPoint = 0;
    // Says, if the Enemy is currently Waiting.
    private bool m_isWaiting = false;
    /// <summary>
    /// Checks, if the Enemy has Waypoint to run to.
    /// </summary>
    private void Awake()
    {
        if (m_WayPoint.Length == 0)
        {
            Debug.LogError("You need to Give the Enemy Waypoints to walk to");
        }
    }
    /// <summary>
    /// Checks the Current Way Point, Handles the Animation and Moves the NavmeshAgent.
    /// </summary>
    private void Update()
    {
        CheckCurrentWayPoint();
        float velocity = m_agent.velocity.magnitude / m_agent.speed;
        m_animator.SetFloat("Walking", velocity);
        if (!m_isWaiting)
        {
            m_agent.SetDestination(m_WayPoint[m_currentPoint].transform.position);
            
        }
    }
    /// <summary>
    /// Checks the distance to the current Way Point.
    ///     if the Enemy is close it sets the current Way Point to the next.
    /// </summary>
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
    /// <summary>
    /// Enemy Waits for at the Waypoint.
    /// </summary>
    /// <returns></returns>
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

    /// For Testing: The Enemy triggered the Bark Behaviour, if the Pet is in the Collider.
    /// This is no longer in the End Version, because it causes the Pet to show the Bark Behaviour 
    ///     And the Player does not recognize why.
    //private void OnTriggerEnter(Collider other)
    //{
    //    foreach (BaseBehavior behavior in GameManager.Instance.BlackBoard.AllBehaviors)
    //    {
    //        if (behavior.BehaviorIndex == BehaviourEnum.BARK)
    //        {
    //            behavior.OnTriggeredEvent.Invoke();
    //        }
    //    }
    //}
}
