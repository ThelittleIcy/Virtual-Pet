using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class InteractionHandler : MonoBehaviour
{
    public UnityEvent OnActivateEvent;
    public UnityEvent OnDeactivateEvent;

    [SerializeField]
    private bool m_isActivated = false;

    public SphereCollider Collider { get => m_collider; set => m_collider = value; }
    public bool IsActivated { get => m_isActivated; set => m_isActivated = value; }

    private SphereCollider m_collider;

    private void Awake()
    {
        Collider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnActivateEvent.Invoke();
            m_isActivated = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) { 
            OnDeactivateEvent.Invoke();
            m_isActivated = false;
        }
    }





}
