using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommands : MonoBehaviour
{
    // Says, if the Player is Currently Allowed to Command.
    public bool IsAllowedToCommand { get => m_isAllowedToCommand; set => m_isAllowedToCommand = value; }
    [SerializeField]
    private bool m_isAllowedToCommand = true;
    // Pop-Up for the negative Respond, that the Pet does not listen.
    [SerializeField]
    private PopUpHandler m_negativeRespond;
    // Pop-Up for the positive Respond, that the Pet does listen.
    [SerializeField]
    private PopUpHandler m_positiveRespond;
    // List of all Possibilities for the different Commands.
    [SerializeField]
    private List<ScriptablePossibilitie> m_commandPossibilities;
    // The Value which is used, to increase the Possibilities.
    [SerializeField]
    private ScriptableInt m_enhanceValue;
    /// <summary>
    /// Resets the Command Possibilities.
    /// </summary>
    public void ResetCommandPossibilities()
    {
        foreach (ScriptablePossibilitie pos in m_commandPossibilities)
        {
            pos.SetToDefault();
        }
    }
    /// <summary>
    /// Checks, if a Behaviour is Canceled.
    /// Checks for triggered Behaviours and if the Player can Command the Pet.
    /// Checks the Different Inputs.
    ///     Checks, if the Command is successfull and triggers the Behaviour and 
    ///     increases the Possibilitie for this Command to be successfull.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CancelBehaviour();
        }
        CheckTriggeredBehaviour();

        if (IsAllowedToCommand)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (CheckSucces(GetBelongingPossibilite(BehaviourEnum.SIT)))
                {
                    TriggerBehaviour(BehaviourEnum.SIT);
                    GetBelongingPossibilite(BehaviourEnum.SIT).Possibility += m_enhanceValue.Value;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (CheckSucces(GetBelongingPossibilite(BehaviourEnum.COME)))
                {
                    TriggerBehaviour(BehaviourEnum.COME);
                    GetBelongingPossibilite(BehaviourEnum.COME).Possibility += m_enhanceValue.Value;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (CheckSucces(GetBelongingPossibilite(BehaviourEnum.RUNTOTARGET)))
                {
                    TriggerBehaviour(BehaviourEnum.RUNTOTARGET);
                    GetBelongingPossibilite(BehaviourEnum.RUNTOTARGET).Possibility += m_enhanceValue.Value;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (CheckSucces(GetBelongingPossibilite(BehaviourEnum.FOLLOW)))
                {
                    TriggerBehaviour(BehaviourEnum.FOLLOW);
                    GetBelongingPossibilite(BehaviourEnum.FOLLOW).Possibility += m_enhanceValue.Value;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                if (CheckSucces(GetBelongingPossibilite(BehaviourEnum.BARK)))
                {
                    TriggerBehaviour(BehaviourEnum.BARK);
                    GetBelongingPossibilite(BehaviourEnum.BARK).Possibility += m_enhanceValue.Value;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                if (CheckSucces(GetBelongingPossibilite(BehaviourEnum.RUNAWAY)))
                {
                    TriggerBehaviour(BehaviourEnum.RUNAWAY);
                    GetBelongingPossibilite(BehaviourEnum.RUNAWAY).Possibility += m_enhanceValue.Value;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                if (CheckSucces(GetBelongingPossibilite(BehaviourEnum.PICKUP)))
                {
                    TriggerBehaviour(BehaviourEnum.PICKUP);
                    GetBelongingPossibilite(BehaviourEnum.PICKUP).Possibility += m_enhanceValue.Value;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                if (CheckSucces(GetBelongingPossibilite(BehaviourEnum.DIGGING)))
                {
                    TriggerBehaviour(BehaviourEnum.DIGGING);
                    GetBelongingPossibilite(BehaviourEnum.DIGGING).Possibility += m_enhanceValue.Value;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                if (CheckSucces(GetBelongingPossibilite(BehaviourEnum.TURNAROUND)))
                {
                    TriggerBehaviour(BehaviourEnum.TURNAROUND);
                    GetBelongingPossibilite(BehaviourEnum.TURNAROUND).Possibility += m_enhanceValue.Value;
                }
            }
        }
    }
    /// <summary>
    /// Cancels the CurrentBehaviour.
    /// </summary>
    private void CancelBehaviour()
    {
        if (GameManager.Instance.BlackBoard.Current == null)
            return;
        foreach (AAction action in GameManager.Instance.BlackBoard.Current.BelongingActions)
        {
            action.HasFinished = true;
        }
    }
    /// <summary>
    /// Triggeres the Behaviour.
    /// </summary>
    /// <param name="_behaviour">The Behaviour to trigger</param>
    private void TriggerBehaviour(BehaviourEnum _behaviour)
    {
        foreach (ABehavior behaviour in GameManager.Instance.BlackBoard.AllBehaviors)
        {
            if (behaviour.BehaviorIndex == _behaviour)
            {
                behaviour.OnTriggeredEvent.Invoke();
            }
        }
        CancelBehaviour();
    }
    /// <summary>
    /// Check, if a Behaviour is already triggered.
    /// </summary>
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
    /// <summary>
    /// Checks, if the Command was successfull.
    /// </summary>
    /// <param name="_poss"></param>
    /// <returns></returns>
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
    /// <summary>
    /// Returns the Possibilities for the Behaviour.
    /// </summary>
    /// <param name="_currentBehaviour">The Behaviour</param>
    /// <returns></returns>
    private ScriptablePossibilitie GetBelongingPossibilite(BehaviourEnum _currentBehaviour)
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
    /// <summary>
    /// Saves the Command Possibilities on Quit.
    /// </summary>
    private void OnApplicationQuit()
    {
        foreach (ScriptablePossibilitie pos in m_commandPossibilities)
        {
            PlayerPrefs.SetInt(pos.name, pos.Possibility);
        }
        PlayerPrefs.Save();
    }
}
