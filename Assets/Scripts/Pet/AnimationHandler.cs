using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Animator Animator { get => m_animator; set => m_animator = value; }
    [SerializeField]
    private Animator m_animator;

    public bool CurrentAnimationFinished { get => m_currentAnimationFinished; set => m_currentAnimationFinished = value; }
    private bool m_currentAnimationFinished = false;

    public void ActivateSitting()
    {
        m_animator.SetBool("IsSitting", true);
    }
    public void DeActivateSitting()
    {
        m_animator.SetBool("IsSitting", false);
    }

    public void ActivateBarking()
    {
        m_animator.SetBool("IsBarking", true);
    }

    public void DeActivateBarking()
    {
        m_animator.SetBool("IsBarking", false);
    }

    public void ActivateWalking()
    {
        m_animator.SetBool("IsWalking", true);
    }
    public void DeActivateWalking()
    {
        m_animator.SetBool("IsWalking", false);
    }

    public void ActivateIdle()
    {
        m_animator.SetBool("IsWalking", false);
        m_animator.SetBool("IsSitting", false);
        m_animator.SetBool("IsBarking", false);
    }

    public void AnimationFinished()
    {
        if(GameManager.Instance.BlackBoard.Current == null || GameManager.Instance.BlackBoard.Current.CurrentAction == null)
        {
            return;
        }
        GameManager.Instance.BlackBoard.Current.CurrentAction.HasFinished = true;
    }
}
