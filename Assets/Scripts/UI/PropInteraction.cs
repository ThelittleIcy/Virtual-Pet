using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PropInteraction : MonoBehaviour
{
    [SerializeField]
    private ReactionProp m_prop;

    public bool CanInteract { get => m_canInteract; set => m_canInteract = value; }

    [SerializeField]
    private bool m_canInteract = false;

    public InteractionHandler Interaction { get => m_interaction; set => m_interaction = value; }
    [SerializeField]
    private InteractionHandler m_interaction;

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
