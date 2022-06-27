using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerReaction : MonoBehaviour
{
    [SerializeField]
    private PopUpHandler m_praise;
    [SerializeField]
    private PopUpHandler m_rant;

    [SerializeField]
    private PopUpHandler m_TeddyWarning;
    [SerializeField]
    private PopUpHandler m_DoorWarning;

    [SerializeField]
    private TeddyProp m_teddy;
    [SerializeField]
    private DoorProp m_door;

    [SerializeField]
    private VisualEffect m_effectiveReactionEffect;

    [SerializeField]
    private float m_startTime = 50;
    [SerializeField]
    private float m_timeLeft = 0;

    [SerializeField]
    private ScriptableInt m_reactionValue;

    [SerializeField]
    private AudioSource m_positiveReactionSound;
    [SerializeField]
    private AudioSource m_negativeReactionSound;


    private void Awake()
    {
        m_effectiveReactionEffect.Stop();
    }
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
    private bool HasCurrentBehaviour()
    {
        if (GameManager.Instance.BlackBoard.Current == null)
        {
            return false;
        }
        return true;
    }

    private ScriptablePossibilitie GetCurrentPossibilitie(BehavoirEnum _current)
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
