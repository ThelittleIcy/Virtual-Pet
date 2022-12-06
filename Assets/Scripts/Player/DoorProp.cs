using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorProp : ReactionProp
{
    // The Animator for Closing and Opening Animation.
    public Animator Animator { get => m_animator; set => m_animator = value; }
    [SerializeField]
    private Animator m_animator;
    // The Interaction.
    [SerializeField]
    private PropInteraction m_interaction;

    /// <summary>
    /// Activates this Door (Opens the Door)
    /// </summary>
    [ContextMenu("ActivateDoor")]
    public override void Activate()
    {
        m_animator.SetBool("IsOpen", true);
    }
    /// <summary>
    /// Deactivates this Door (Closes the Door)
    /// </summary>
    [ContextMenu("DeactivateDoor")]
    public override void Deactivate()
    {
        m_animator.SetBool("IsOpen", false);
    }
    /// <summary>
    ///  Enables the Collider turns IsUsed to true.
    /// </summary>
    public void OpenAnimationFinished()
    {
        m_interaction.Interaction.Collider.enabled = true;
        IsUsed = true;
    }
    /// <summary>
    /// Disables the Collider and turns isUsed to false.
    /// </summary>
    public void CloseAnimationFinished()
    {
        m_interaction.Interaction.Collider.enabled = false;
        IsUsed = false;
    }
}
