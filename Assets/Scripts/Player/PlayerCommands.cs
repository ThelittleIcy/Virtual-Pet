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
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (CheckSucces(GetBelongingPossibilite(BehavoirEnum.COME)))
                {
                    TriggerBehaviour(BehavoirEnum.COME);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (CheckSucces(GetBelongingPossibilite(BehavoirEnum.RUNTOTARGET)))
                {
                    TriggerBehaviour(BehavoirEnum.RUNTOTARGET);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (CheckSucces(GetBelongingPossibilite(BehavoirEnum.FOLLOW)))
                {
                    TriggerBehaviour(BehavoirEnum.FOLLOW);
                }
            }
            // "Cancels" the current Command
            else if (Input.GetKeyDown(KeyCode.R))
            {
                switch (GameManager.Instance.BlackBoard.Current.BehaviorIndex)
                {
                    case BehavoirEnum.NOTHING:
                        return;
                    case BehavoirEnum.BARK:
                        return;
                    case BehavoirEnum.PICKUP:
                        return;
                    case BehavoirEnum.RUNAWAY:
                        return;
                    case BehavoirEnum.SIT:
                        break;
                    case BehavoirEnum.COME:
                        break;
                    case BehavoirEnum.RUNTOTARGET:
                        break;
                    case BehavoirEnum.FOLLOW:
                        break;
                    default:
                        break;  
                }
                foreach (AAction action in GameManager.Instance.BlackBoard.Current.BelongingActions)
                {
                    action.HasFinished = true;  
                }
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
                //IsAllowedToCommand = false;
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
