using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;

public abstract class ABehavior : StateMachineBehaviour
{
    public UnityEvent OnTriggeredEvent;

    public List<AAction> BelongingActions;

    public AAction CurrentAction { get => m_currentAction; set => m_currentAction = value; }
    [SerializeField]
    private AAction m_currentAction;
    public bool IsTriggered { get => m_isTriggered; set => m_isTriggered = value; }
    [SerializeField]
    private bool m_isTriggered = false;
    public bool PlayerHasReacted { get => m_playerHasReacted; set => m_playerHasReacted = value; }
    [SerializeField]
    private bool m_playerHasReacted = false;

    public BehavoirEnum BehaviorIndex { get => m_BehaviorIndex; set => m_BehaviorIndex = value; }
    [SerializeField]
    private BehavoirEnum m_BehaviorIndex;

    public ReactionEnum EffectiveReinforceReaction { get => m_effectiveReinforceReaction; set => m_effectiveReinforceReaction = value; }
    [SerializeField]
    private ReactionEnum m_effectiveReinforceReaction;

    public ReactionEnum EffectivePunishmentReaction { get => m_effectivePunishmentReaction; set => m_effectivePunishmentReaction = value; }
    [SerializeField]
    private ReactionEnum m_effectivePunishmentReaction;

    private int m_currentActionIndex = 0;

    public virtual void Awake()
    {
        OnTriggeredEvent.AddListener(Triggered);
    }

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
            // Problem : Gets ALL Actions even if they don't Belong to this State // SOLVED (I HOPE)
        }
        if (BelongingActions.Count == 0)
            return; // ExitState!

        m_currentActionIndex = 0;
        CurrentAction = BelongingActions[0];
        CurrentAction.Start();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (BelongingActions.Count == 0)
            return; // ExitState!
        if (CurrentAction.HasFinished == true)
        {
            m_currentActionIndex++;
            if (m_currentActionIndex >= BelongingActions.Count)
            {
                // Exit Allgemein!
                animator.SetBool("CurrentBehaviorFinished", true);
                return;
            }
            CurrentAction.Exit();
            CurrentAction = BelongingActions[m_currentActionIndex];
            CurrentAction.Start();
        }
        CurrentAction.Update();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (BelongingActions.Count == 0)
            return; // ExitState!
        CurrentAction.Exit();
        IsTriggered = false;
        animator.SetBool("CurrentBehaviorFinished", false);
        //GameManager.Instance.BlackBoard.Current = null;
    }

    public virtual void Triggered()
    {
        IsTriggered = true;
    }

    [ContextMenu("Trigger")]
    public void TestTriggering()
    {
        OnTriggeredEvent.Invoke();
    }

}
