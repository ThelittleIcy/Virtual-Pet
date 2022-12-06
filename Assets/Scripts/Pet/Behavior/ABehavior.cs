using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;

public abstract class ABehavior : StateMachineBehaviour
{
    // Event, which is Invoken when the Behaviour is Triggered.
    public UnityEvent OnTriggeredEvent;
    // List of All Actions, which belonge to this Behaviour.
    public List<AAction> BelongingActions;
    //The Current Action.
    public AAction CurrentAction { get => m_currentAction; set => m_currentAction = value; }
    [SerializeField]
    private AAction m_currentAction;
    // Says, if the Behaviour is Triggered.
    public bool IsTriggered { get => m_isTriggered; set => m_isTriggered = value; }
    [SerializeField]
    private bool m_isTriggered = false;
    // Says, if the Player has Reacted to this Behaviour to avoid multiple Reactions at once.
    public bool PlayerHasReacted { get => m_playerHasReacted; set => m_playerHasReacted = value; }
    [SerializeField]
    private bool m_playerHasReacted = false;
    // The Behaviour 
    public BehaviourEnum BehaviorIndex { get => m_BehaviorIndex; set => m_BehaviorIndex = value; }
    [SerializeField]
    private BehaviourEnum m_BehaviorIndex;
    // The Effective Reinforce Reaction for this Behaviour.
    public ReactionEnum EffectiveReinforceReaction { get => m_effectiveReinforceReaction; set => m_effectiveReinforceReaction = value; }
    [SerializeField]
    private ReactionEnum m_effectiveReinforceReaction;
    // The Effective Punishment Reaction for this Behaviour.
    public ReactionEnum EffectivePunishmentReaction { get => m_effectivePunishmentReaction; set => m_effectivePunishmentReaction = value; }
    [SerializeField]
    private ReactionEnum m_effectivePunishmentReaction;

    // The index for the current Action.
    private int m_currentActionIndex = 0;

    // Adds The Triggered Methode to the OnTriggeredEvent.
    public virtual void Awake()
    {
        OnTriggeredEvent.AddListener(Triggered);
    }
    /// <summary>
    /// Called at the Start of this Behaviour. Sets up Variables and adds the Actions.
    /// Starts the First Action.
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerHasReacted = false;
        animator.SetBool("CurrentBehaviorFinished", false);
        // Add Actions
        if (BelongingActions.Count == 0)
        {
            List<AAction> actions = new List<AAction>();
            actions.AddRange(animator.GetBehaviours<AAction>());
            for (int i = 0; i < actions.Count; i++)
            {
                if (actions[i].Behaviour == BehaviorIndex)
                {
                    BelongingActions.Add(actions[i]);
                }
            }
            actions.Clear();
        }
        if (BelongingActions.Count == 0)
            return; // And Exits the State.
        // Sets and Starts Current Action.
        m_currentActionIndex = 0;
        CurrentAction = BelongingActions[0];
        CurrentAction.Start();
    }
    /// <summary>
    /// The Update Function. 
    /// Checks if the current Action is Finished.
    ///     Sets the next Action or ends the Behaviour.
    ///     Updates the Current Action
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (BelongingActions.Count == 0)
            return; // ExitState!
        if (CurrentAction.HasFinished == true)
        {
            m_currentActionIndex++;
            if (m_currentActionIndex >= BelongingActions.Count)
            {
                animator.SetBool("CurrentBehaviorFinished", true);
                return; // And Exits the State.
            }
            CurrentAction.Exit();
            CurrentAction = BelongingActions[m_currentActionIndex];
            CurrentAction.Start();
        }
        CurrentAction.Update();
    }
    /// <summary>
    /// Called at the End of this Behaviour.
    /// Resets the Variables and Exits the Current Action.
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (BelongingActions.Count == 0)
            return; // ExitState!
        CurrentAction.Exit();
        IsTriggered = false;
        animator.SetBool("CurrentBehaviorFinished", false);
        GameManager.Instance.BlackBoard.Current = null;
    }
    /// <summary>
    /// Sets IsTriggered to true.
    /// </summary>
    public virtual void Triggered()
    {
        IsTriggered = true;
    }

    /// <summary>
    /// For Testing Purpose: Triggeres this Behaviour.
    /// </summary>
    [ContextMenu("Trigger")]
    public void TestTriggering()
    {
        OnTriggeredEvent.Invoke();
    }

}
