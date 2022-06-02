using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommands : MonoBehaviour
{
    public bool IsAllowedToCommand { get => m_isAllowedToCommand; set => m_isAllowedToCommand = value; }
    [SerializeField]
    private bool m_isAllowedToCommand = true;

    [SerializeField]
    private PopUpHandler m_negativeRespond;
    [SerializeField]
    private PopUpHandler m_positiveRespond;

    private void Update()
    {
        CheckTriggeredBehaviour();
        if (IsAllowedToCommand)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (CheckSucces(GetBelongingPossibilite(BehavoirEnum.SIT)))
                {
                    TriggerBehaviour(BehavoirEnum.SIT);
                }

                //m_isAllowedToCommand = false;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (CheckSucces(GetBelongingPossibilite(BehavoirEnum.COME)))
                {
                    TriggerBehaviour(BehavoirEnum.COME);
                }
                //m_isAllowedToCommand = false;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (CheckSucces(GetBelongingPossibilite(BehavoirEnum.RUNTOTARGET)))
                {
                    TriggerBehaviour(BehavoirEnum.RUNTOTARGET);
                }
                //m_isAllowedToCommand = false;
            }
        }
    }

    private void TriggerBehaviour(BehavoirEnum _behaviour)
    {
        foreach (ABehavior behaviour in GameManager.Instance.BlackBoard.AllBehaviors)
        {
            if (behaviour.BehaviorIndex == _behaviour)
            {
                behaviour.OnTriggeredEvent.Invoke();
                Debug.Log(behaviour.BehaviorIndex);
            }
        }
    }

    private void CheckTriggeredBehaviour()
    {
        foreach (ABehavior behaviour in GameManager.Instance.BlackBoard.AllBehaviors)
        {
            if (behaviour.IsTriggered == true)
            {
                return;
            }
        }
        IsAllowedToCommand = true;
    }

    private bool CheckSucces(ScriptablePossibilitie _poss)
    {
        float rnd = Random.Range(0, 100);
        if (_poss.Possibility >= rnd)
        {
            m_positiveRespond.OnActivatedEvent.Invoke();
            return true;
        }
        m_negativeRespond.OnActivatedEvent.Invoke();
        return false;
    }

    private ScriptablePossibilitie GetBelongingPossibilite(BehavoirEnum _currentBehaviour)
    {
        foreach (ScriptablePossibilitie possibilitie in GameManager.Instance.BlackBoard.AllPossibilities)
        {
            if(possibilitie.BelongingBehaviour == _currentBehaviour)
            {
                return possibilitie;
            }
        }
        Debug.LogError("You requestet a Behaviour which does not have a Possibiliy");
        return null;
    }
}
