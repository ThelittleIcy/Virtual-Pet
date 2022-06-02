using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evaluate : StateMachineBehaviour
{
    public PetBlackboard BlackBoard { get => m_blackBoard; set => m_blackBoard = value; }
    [SerializeField]
    private PetBlackboard m_blackBoard;

    private bool m_behaviourWasChoosen = false;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        BlackBoard = GameManager.Instance.BlackBoard;
        GameManager.Instance.BlackBoard.Current = null;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if (!m_behaviourWasChoosen)
        {
            for (int i = 0; i < BlackBoard.AllBehaviors.Count; i++)
            {
                
                if (BlackBoard.AllBehaviors[i].IsTriggered == true)
                {
                    animator.SetInteger("CurrentBehavior", (int)BlackBoard.AllBehaviors[i].BehaviorIndex);
                    BlackBoard.Current = BlackBoard.AllBehaviors[i];
                    m_behaviourWasChoosen = true;
                }
            }
        }
        if (!m_behaviourWasChoosen)
        {
            // Warscheinlichkeiten
            for (int j = 0; j < BlackBoard.AllBehaviors.Count; j++)
            {
                int rnd = Random.Range(0, 100);
                ScriptablePossibilitie currentPossibilitie = new ScriptablePossibilitie();
                for (int i = 0; i < BlackBoard.AllPossibilities.Count; i++)
                {
                    if (BlackBoard.AllPossibilities[i].BelongingBehaviour == BlackBoard.AllBehaviors[j].BehaviorIndex)
                    {
                        currentPossibilitie = BlackBoard.AllPossibilities[i];
                    }
                }

                if (currentPossibilitie.Possibility >= rnd)
                {
                    animator.SetInteger("CurrentBehavior", (int)BlackBoard.AllBehaviors[j].BehaviorIndex);
                    BlackBoard.Current = BlackBoard.AllBehaviors[j];
                    m_behaviourWasChoosen = true;
                    return;
                }
            }
        }
        
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.SetInteger("CurrentBehavior", 0);
        m_behaviourWasChoosen = false;
    }

}
