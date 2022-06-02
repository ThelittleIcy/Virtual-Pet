using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorProp : ReactionProp
{
    public Animator Animator { get => m_animator; set => m_animator = value; }
    [SerializeField]
    private Animator m_animator;

    [SerializeField]
    private InteractionPopUp m_interaction;

    [ContextMenu("ActivateDoor")]
    public override void Activate()
    {
        m_animator.SetBool("IsOpen", true);
    }
    [ContextMenu("DeactivateDoor")]
    public override void Deactivate()
    {
        m_animator.SetBool("IsOpen", false);
    }

    public void OpenAnimationFinished()
    {
        m_interaction.Collider.enabled = true;
        IsUsed = true;
    }

    public void CloseAnimationFinished()
    {
        m_interaction.Collider.enabled = false;
        IsUsed = false;
    }
}
