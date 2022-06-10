using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionPopUp : MonoBehaviour
{
    public UnityEvent OnActivateEvent;
    public UnityEvent OnDeactivateEvent;

    public SphereCollider Collider { get => m_collider; set => m_collider = value; }

    private SphereCollider m_collider;

    [SerializeField]
    private ReactionProp m_prop;

    public bool CanInteract { get => m_canInteract; set => m_canInteract = value; }
    [SerializeField]
    private bool m_canInteract = false;


    private void Awake()
    {
        Collider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        OnActivateEvent.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        OnDeactivateEvent.Invoke();
    }

    private void Update()
    {
        if (!m_canInteract)
            return;
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (m_prop != null)
            {
                m_prop.OnDeactivateEvent.Invoke();
            }
            OnDeactivateEvent.Invoke();
        }
    }
}
