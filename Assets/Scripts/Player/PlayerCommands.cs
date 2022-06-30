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

    [SerializeField]
    private List<ScriptablePossibilitie> m_commandPossibilities;

    [SerializeField]
    private ScriptableInt m_enhanceValue;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (AAction action in GameManager.Instance.BlackBoard.Current.BelongingActions)
            {
                action.HasFinished = true;
            }
        }
        CheckTriggeredBehaviour();
        if (IsAllowedToCommand)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (CheckSucces(GetBelongingPossibilite(BehavoirEnum.SIT)))
                {
                    TriggerBehaviour(BehavoirEnum.SIT);
                    GetBelongingPossibilite(BehavoirEnum.SIT).Possibility += m_enhanceValue.Value;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (CheckSucces(GetBelongingPossibilite(BehavoirEnum.COME)))
                {
                    TriggerBehaviour(BehavoirEnum.COME);
                    GetBelongingPossibilite(BehavoirEnum.COME).Possibility += m_enhanceValue.Value;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (CheckSucces(GetBelongingPossibilite(BehavoirEnum.RUNTOTARGET)))
                {
                    TriggerBehaviour(BehavoirEnum.RUNTOTARGET);
                    GetBelongingPossibilite(BehavoirEnum.RUNTOTARGET).Possibility += m_enhanceValue.Value;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (CheckSucces(GetBelongingPossibilite(BehavoirEnum.FOLLOW)))
                {
                    TriggerBehaviour(BehavoirEnum.FOLLOW);
                    GetBelongingPossibilite(BehavoirEnum.FOLLOW).Possibility += m_enhanceValue.Value;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                if (CheckSucces(GetBelongingPossibilite(BehavoirEnum.BARK)))
                {
                    TriggerBehaviour(BehavoirEnum.BARK);
                    GetBelongingPossibilite(BehavoirEnum.BARK).Possibility += m_enhanceValue.Value;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                if (CheckSucces(GetBelongingPossibilite(BehavoirEnum.RUNAWAY)))
                {
                    TriggerBehaviour(BehavoirEnum.RUNAWAY);
                    GetBelongingPossibilite(BehavoirEnum.RUNAWAY).Possibility += m_enhanceValue.Value;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                if (CheckSucces(GetBelongingPossibilite(BehavoirEnum.PICKUP)))
                {
                    TriggerBehaviour(BehavoirEnum.PICKUP);
                    GetBelongingPossibilite(BehavoirEnum.PICKUP).Possibility += m_enhanceValue.Value;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                if (CheckSucces(GetBelongingPossibilite(BehavoirEnum.DIGGING)))
                {
                    TriggerBehaviour(BehavoirEnum.DIGGING);
                    GetBelongingPossibilite(BehavoirEnum.DIGGING).Possibility += m_enhanceValue.Value;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                if (CheckSucces(GetBelongingPossibilite(BehavoirEnum.TURNAROUND)))
                {
                    TriggerBehaviour(BehavoirEnum.TURNAROUND);
                    GetBelongingPossibilite(BehavoirEnum.TURNAROUND).Possibility += m_enhanceValue.Value;
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
            }
        }
    }

    private void CheckTriggeredBehaviour()
    {
        foreach (ABehavior behaviour in GameManager.Instance.BlackBoard.AllBehaviors)
        {
            if (behaviour.IsTriggered == true)
            {
                IsAllowedToCommand = false;
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
        foreach (ScriptablePossibilitie possibilitie in m_commandPossibilities)
        {
            if (possibilitie.BelongingBehaviour == _currentBehaviour)
            {
                return possibilitie;
            }
        }
        Debug.LogError("You requestet a Behaviour which does not have a Possibiliy");
        return null;
    }
}
