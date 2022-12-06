using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    // The Animator for the Animations.
    public Animator Animator { get => m_animator; set => m_animator = value; }
    [SerializeField]
    private Animator m_animator;
    // Says, if the CurrentAnimation is Finished.
    public bool CurrentAnimationFinished { get => m_currentAnimationFinished; set => m_currentAnimationFinished = value; }
    private bool m_currentAnimationFinished = false;
    /// <summary>
    /// Function, to Activate the Sitting Animation.
    /// </summary>
    public void ActivateSitting()
    {
        m_animator.SetBool("IsSitting", true);
    }
    /// <summary>
    /// Function, to Dectivate the Sitting Animation.
    /// </summary>
    public void DeActivateSitting()
    {
        m_animator.SetBool("IsSitting", false);
    }
    /// <summary>
    /// Function, to Activate the Turning Animation.
    /// </summary>
    public void ActivateTurning()
    {
        m_animator.SetBool("IsTurning", true);
    }
    /// <summary>
    /// Function, to Deactivate the Turning Animation.
    /// </summary>
    public void DeActivateTurning()
    {
        m_animator.SetBool("IsTurning", false);
    }
    /// <summary>
    /// Function, to Activate the Digging Animation.
    /// </summary>
    public void ActivateDigging()
    {
        m_animator.SetBool("IsDigging", true);
    }
    /// <summary>
    /// Function, to Deactivate the Digging Animation.
    /// </summary>
    public void DeActivateDiggin()
    {
        m_animator.SetBool("IsDigging", false);
    }
    /// <summary>
    /// Function, to Activate the Barking Animation.
    /// </summary>
    public void ActivateBarking()
    {
        m_animator.SetBool("IsBarking", true);
    }
    /// <summary>
    /// Function, to Deactivate the Barking Animation.
    /// </summary>
    public void DeActivateBarking()
    {
        m_animator.SetBool("IsBarking", false);
    }
    /// <summary>
    /// Function, to Activate the Walking Animation.
    /// </summary>
    public void ActivateWalking()
    {
        m_animator.SetBool("IsWalking", true);
    }
    /// <summary>
    /// Function, to Deactivate the Walking Animation.
    /// </summary>
    public void DeActivateWalking()
    {
        m_animator.SetBool("IsWalking", false);
    }
    /// <summary>
    /// Function, to Activate the Idle Animation.
    /// </summary>
    public void ActivateIdle()
    {
        m_animator.SetBool("IsWalking", false);
        m_animator.SetBool("IsSitting", false);
        m_animator.SetBool("IsBarking", false);
    }
    /// <summary>
    /// Function to Set the current Animation to Finished. Ends the Current Action.
    /// </summary>
    public void AnimationFinished()
    {
        if(GameManager.Instance.BlackBoard.Current == null || GameManager.Instance.BlackBoard.Current.CurrentAction == null)
        {
            return;
        }
        GameManager.Instance.BlackBoard.Current.CurrentAction.HasFinished = true;
    }
}
