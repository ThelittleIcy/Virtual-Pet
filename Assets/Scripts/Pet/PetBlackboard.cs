using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetBlackboard : MonoBehaviour
{
    // List of all Behaviours.
    public List<ABehavior> AllBehaviors;
    // List of all Possibilities.
    public List<ScriptablePossibilitie> AllPossibilities;
    // The Current Behaviour.
    public ABehavior Current { get => m_current; set => m_current = value; }
    private ABehavior m_current;
    // The Current Animator for the Behaviours.
    public Animator BehaviorAnimator { get => m_BehaviorAnimator; set => m_BehaviorAnimator = value; }
    [SerializeField]
    private Animator m_BehaviorAnimator;
    // The NavMeshAgent.
    public NavMeshAgent Agent { get => m_agent; set => m_agent = value; }
    [SerializeField]
    private NavMeshAgent m_agent;
    // The Mouth where the Ball should be placed. 
    public GameObject MouthTarget { get => m_mouthTarget; set => m_mouthTarget = value; }
    [SerializeField]
    private GameObject m_mouthTarget;
    /// <summary>
    /// Gets all Behaviours from the Animator.
    /// </summary>
    private void Start()
    {
        if (AllBehaviors.Count == 0)
        {
            AllBehaviors.AddRange(BehaviorAnimator.GetBehaviours<ABehavior>());
        }
    }
    /// <summary>
    /// Resets All The Possibilities.
    /// </summary>
    [ContextMenu("Reset All Possibilities")]
    private void ResetAllPossibilities()
    {
        foreach (ScriptablePossibilitie possibilitie in AllPossibilities)
        {
            possibilitie.SetToDefault();
        }
    }

}
