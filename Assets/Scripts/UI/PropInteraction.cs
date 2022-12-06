using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PropInteraction : MonoBehaviour
{
    // The Prop.
    [SerializeField]
    private ReactionProp m_prop;
    // Says, if the Prop can be Interacted with.
    public bool CanInteract { get => m_canInteract; set => m_canInteract = value; }
    [SerializeField]
    private bool m_canInteract = false;
    // The Interaction Handler.
    public InteractionHandler Interaction { get => m_interaction; set => m_interaction = value; }
    [SerializeField]
    private InteractionHandler m_interaction;
    /// <summary>
    /// Checks, if the Prop can be Interacted with and deactivates it, if the Input F was pressed.
    /// </summary>
    private void Update()
    {
        if (!m_canInteract)
            return;
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (m_prop != null)
            {
                m_prop.OnDeactivateEvent.Invoke();
                Interaction.OnDeactivateEvent.Invoke();
            }
        }
    }
}
