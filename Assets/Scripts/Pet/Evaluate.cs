using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evaluate : StateMachineBehaviour
{
    // The Blackboard for the Pet.
    public PetBlackboard BlackBoard { get => m_blackBoard; set => m_blackBoard = value; }
    [SerializeField]
    private PetBlackboard m_blackBoard;
    // Says, if a behaviour was Choosen.
    private bool m_behaviourWasChoosen = false;
    /// <summary>
    /// Called at every Start of this State.
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        BlackBoard = GameManager.Instance.BlackBoard;
    }
    /// <summary>
    /// Chooses A behaviour.
    ///     Checks first, if a Behaviour was triggered. 
    ///     When no Behaviour was triggered, it chooses a random Behaviour
    ///         Sums all Possibilites and saves their Borders.
    ///         Generates a random number in this sum and chooses the Behaviour based on the borders.
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        //  Befehle, etc.
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
        //  autonomes Verhalten
        if (!m_behaviourWasChoosen)
        {
            List<int> borders = new List<int>();
            List<BehaviourEnum> behavoirEnums = new List<BehaviourEnum>();
            int SumOfPossibilities = 0;
            foreach (ScriptablePossibilitie possibilitie in BlackBoard.AllPossibilities)
            {
                if (possibilitie.Possibility >= 0)
                {
                    borders.Add(SumOfPossibilities + possibilitie.Possibility);
                    behavoirEnums.Add(possibilitie.BelongingBehaviour);
                    SumOfPossibilities += possibilitie.Possibility;
                }
            }
            int rnd = Random.Range(0, SumOfPossibilities + 1);
            for (int i = 0; i < borders.Count; i++)
            {
                if (rnd <= borders[i])
                {
                    int behaviourIndex = 0;
                    for (int j = 0; j < BlackBoard.AllBehaviors.Count; j++)
                    {
                        if(BlackBoard.AllBehaviors[j].BehaviorIndex == behavoirEnums[i])
                        {
                            behaviourIndex = j;
                        }
                    }

                    animator.SetInteger("CurrentBehavior", (int)BlackBoard.AllBehaviors[behaviourIndex].BehaviorIndex);
                    BlackBoard.Current = BlackBoard.AllBehaviors[behaviourIndex];
                    m_behaviourWasChoosen = true;
                    return;
                }
            }
        }
    }
    /// <summary>
    /// Called at every Exit of this State.
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.SetInteger("CurrentBehavior", 0);
        m_behaviourWasChoosen = false;
    }

}
