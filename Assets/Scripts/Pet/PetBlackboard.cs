using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetBlackboard : MonoBehaviour
{
    public List<ABehavior> AllBehaviors;

    public List<ScriptablePossibilitie> AllPossibilities;

    public ABehavior Current { get => m_current; set => m_current = value; }
    private ABehavior m_current;

    public Animator BehaviorAnimator { get => m_BehaviorAnimator; set => m_BehaviorAnimator = value; }
    [SerializeField]
    private Animator m_BehaviorAnimator;

    public NavMeshAgent Agent { get => m_agent; set => m_agent = value; }
    [SerializeField]
    private NavMeshAgent m_agent;

    public GameObject MouthTarget { get => m_mouthTarget; set => m_mouthTarget = value; }
    [SerializeField]
    private GameObject m_mouthTarget;

    private void Start()
    {
        if (AllBehaviors.Count == 0)
        {
            AllBehaviors.AddRange(BehaviorAnimator.GetBehaviours<ABehavior>());
        }
    }

    [ContextMenu("Reset All Possibilities")]
    private void ResetAllPossibilities()
    {
        foreach (ScriptablePossibilitie possibilitie in AllPossibilities)
        {
            possibilitie.SetToDefault();
        }
    }

}
