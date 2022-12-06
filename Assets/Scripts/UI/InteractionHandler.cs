using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class InteractionHandler : MonoBehaviour
{
    // Event for the Activation.
    public UnityEvent OnActivateEvent;
    // Event for the Deactivation.
    public UnityEvent OnDeactivateEvent;
    // Says, if the Interaction is Activated.
    [SerializeField]
    private bool m_isActivated = false;
    // The Belonging Collider.
    public SphereCollider Collider { get => m_collider; set => m_collider = value; }
    public bool IsActivated { get => m_isActivated; set => m_isActivated = value; }

    private SphereCollider m_collider;
    /// <summary>
    /// Sets the Collider.
    /// </summary>
    private void Awake()
    {
        Collider = GetComponent<SphereCollider>();
    }
    /// <summary>
    /// Activates, if the Player enters the Trigger Collider.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnActivateEvent.Invoke();
            m_isActivated = true;
        }
    }
    /// <summary>
    /// Deactivates, if the Player leaves the Trigger Collider.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) { 
            OnDeactivateEvent.Invoke();
            m_isActivated = false;
        }
    }
}
