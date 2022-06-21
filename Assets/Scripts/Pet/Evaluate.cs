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
            List<int> borders = new List<int>();
            List<BehavoirEnum> behavoirEnums = new List<BehavoirEnum>();
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
            Debug.Log(rnd);
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


            //for (int j = 0; j < BlackBoard.AllBehaviors.Count; j++)
            //{
            //    int rnd = Random.Range(0, 100);
            //    ScriptablePossibilitie currentPossibilitie = new ScriptablePossibilitie();
            //    for (int i = 0; i < BlackBoard.AllPossibilities.Count; i++)
            //    {
            //        if (BlackBoard.AllPossibilities[i].BelongingBehaviour == BlackBoard.AllBehaviors[j].BehaviorIndex)
            //        {
            //            currentPossibilitie = BlackBoard.AllPossibilities[i];
            //        }
            //    }

            //    if (currentPossibilitie.Possibility >= rnd)
            //    {
            //        animator.SetInteger("CurrentBehavior", (int)BlackBoard.AllBehaviors[j].BehaviorIndex);
            //        BlackBoard.Current = BlackBoard.AllBehaviors[j];
            //        m_behaviourWasChoosen = true;
            //        return;
            //    }
            //}
        }

    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.SetInteger("CurrentBehavior", 0);
        m_behaviourWasChoosen = false;
    }

}
