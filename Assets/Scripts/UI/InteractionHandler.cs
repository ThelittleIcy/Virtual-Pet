using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class InteractionHandler : MonoBehaviour
{
    public UnityEvent OnActivateEvent;
    public UnityEvent OnDeactivateEvent;

    public SphereCollider Collider { get => m_collider; set => m_collider = value; }
    private SphereCollider m_collider;

    private void Awake()
    {
        Collider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            OnActivateEvent.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
             OnDeactivateEvent.Invoke();
    }
}
