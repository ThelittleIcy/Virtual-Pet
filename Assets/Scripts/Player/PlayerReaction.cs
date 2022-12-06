using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerReaction : MonoBehaviour
{
    // Pop-Up for the Praise.
    [SerializeField]
    private PopUpHandler m_praise;
    // Pop-Up for the Rant.
    [SerializeField]
    private PopUpHandler m_rant;
    // Pop-Up for the Warning for the Teddy.
    [SerializeField]
    private PopUpHandler m_TeddyWarning;
    // Pop-Up for the Warning for the Door.
    [SerializeField]
    private PopUpHandler m_DoorWarning;
    // The TeddyProp.
    [SerializeField]
    private TeddyProp m_teddy;
    // The DoorProp.
    [SerializeField]
    private DoorProp m_door;
    // The Visual Effect for the effective Reaction.
    [SerializeField]
    private VisualEffect m_effectiveReactionEffect;
    // The Start Time.
    [SerializeField]
    private float m_startTime = 50;
    // The current Time left.
    [SerializeField]
    private float m_timeLeft = 0;
    // The value, which is used to change the Possibilities.
    [SerializeField]
    private ScriptableInt m_reactionValue;

    // The Sounds
    // The Sound for a positive Reaction.
    [SerializeField]
    private AudioSource m_positiveReactionSound;
    // The Sound for a negative Reaction.
    [SerializeField]
    private AudioSource m_negativeReactionSound;

    /// <summary>
    /// Stops the Visual Effect.
    /// </summary>
    private void Awake()
    {
        m_effectiveReactionEffect.Stop();
    }
    /// <summary>
    /// Checks, if a Reaction was given.
    ///     Divides the Reaction in the four Reaction Types.
    ///         Checks if the Behaviour and the Reaction is Valid.
    ///         Increases or Decreases the Possibilitie with the Reaction Type.
    ///         Activates the Consequence of the Reaction.
    /// </summary>
    private void Update()
    {
        //positive Reinforcment
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (HasCurrentBehaviour())
            {
                if (GameManager.Instance.BlackBoard.Current.PlayerHasReacted)
                {
                    return;
                }
                IncreasePossibilitie(ReactionEnum.POS_REINFORCEMENT);
                GameManager.Instance.BlackBoard.Current.PlayerHasReacted = true;
                m_praise.OnActivatedEvent.Invoke();
            }
        }
        //negative Reinforcment
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (!CanReact(m_door))
            {
                m_DoorWarning.OnActivatedEvent.Invoke();
                return;
            }
            if (HasCurrentBehaviour())
            {
                if (GameManager.Instance.BlackBoard.Current.PlayerHasReacted)
                {
                    return;
                }
                IncreasePossibilitie(ReactionEnum.NEG_REINFORCEMENT);
                GameManager.Instance.BlackBoard.Current.PlayerHasReacted = true;
                m_door.OnActivateEvent.Invoke();
            }
        }
        //positive Punishment
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            if (HasCurrentBehaviour())
            {
                if (GameManager.Instance.BlackBoard.Current.PlayerHasReacted)
                {
                    return;
                }
                DecreasePossibilitie(ReactionEnum.POS_PUNISHMENT);
                GameManager.Instance.BlackBoard.Current.PlayerHasReacted = true;
                m_rant.OnActivatedEvent.Invoke();
            }
        }
        //negative Punishment
        else if (Input.GetKeyDown(KeyCode.C))
        {
            if (!CanReact(m_teddy))
            {
                m_TeddyWarning.OnActivatedEvent.Invoke();
                return;
            }
            if (HasCurrentBehaviour())
            {
                if (GameManager.Instance.BlackBoard.Current.PlayerHasReacted)
                {
                    return;
                }
                DecreasePossibilitie(ReactionEnum.NEG_PUNISHMENT);
                GameManager.Instance.BlackBoard.Current.PlayerHasReacted = true;
                m_teddy.OnActivateEvent.Invoke();
            }
        }
    }
    /// <summary>
    /// Returns, if the Player can react for this Prop or if it is already used.
    /// </summary>
    /// <param name="_prop"></param>
    /// <returns></returns>
    private bool CanReact(ReactionProp _prop)
    {
        if(_prop.IsUsed == true)
        {
            return false;
        }
        else 
        {
            return true;
        }
    }
    /// <summary>
    /// Checks, if there is a current Behaviour.
    /// </summary>
    /// <returns></returns>
    private bool HasCurrentBehaviour()
    {
        if (GameManager.Instance.BlackBoard.Current == null)
        {
            return false;
        }
        return true;
    }
    /// <summary>
    /// returns the Possibilitie from the given Behaviourenum.
    /// </summary>
    /// <param name="_current">the Behaviour</param>
    /// <returns></returns>
    private ScriptablePossibilitie GetCurrentPossibilitie(BehaviourEnum _current)
    {
        foreach (ScriptablePossibilitie possibilitie in GameManager.Instance.BlackBoard.AllPossibilities)
        {
            if (possibilitie.BelongingBehaviour == _current)
            {
                return possibilitie;
            }
        }
        Debug.LogError("You requestet a Behaviour which does not have a Possibiliy");
        return null;
    }
    /// <summary>
    /// Increases the Possibilitie with the given Reaction.
    /// </summary>
    /// <param name="_effectiveReaction">The Reaction Type</param>
    private void IncreasePossibilitie(ReactionEnum _effectiveReaction)
    {
        ScriptablePossibilitie pos = GetCurrentPossibilitie(GameManager.Instance.BlackBoard.Current.BehaviorIndex);
        if (GameManager.Instance.BlackBoard.Current.EffectiveReinforceReaction == _effectiveReaction)
        {
            //pos.Possibility += 10;
            pos.Add(m_reactionValue.Value + 2);
            m_timeLeft = m_startTime;
            StartCoroutine(Timer());
            m_effectiveReactionEffect.Play();
        }
        else
        {
            //pos.Possibility += 5;
            pos.Add(m_reactionValue.Value);
        }
        m_positiveReactionSound.Play();
    }
    /// <summary>
    /// Decreases the Possibilitie with the given Reaction.
    /// </summary>
    /// <param name="_effectiveReaction">The Reaction Type</param>
    private void DecreasePossibilitie(ReactionEnum _effectiveReaction)
    {
        ScriptablePossibilitie pos = GetCurrentPossibilitie(GameManager.Instance.BlackBoard.Current.BehaviorIndex);
        if (GameManager.Instance.BlackBoard.Current.EffectivePunishmentReaction == _effectiveReaction)
        {
            //pos.Possibility -= 10;
            pos.Decrease(m_reactionValue.Value + 2);
            m_timeLeft = m_startTime;
            StartCoroutine(Timer());
            m_effectiveReactionEffect.Play();
        }
        else
        {
            //pos.Possibility -= 5;
            m_timeLeft = m_startTime;
            pos.Decrease(m_reactionValue.Value);
        }
        m_negativeReactionSound.Play();
    }
    /// <summary>
    /// The Timer for the Visual Effect to Play.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            m_timeLeft -= 1;
            if (m_timeLeft <= 0)
            {
                m_effectiveReactionEffect.Stop();
                yield break;
            }
        }
    }
}
