using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_attachPoint;

    [SerializeField]
    private InteractionHandler m_interaction;

    public bool IsPickedUp
    {
        get => m_isPickedUp;
        set
        {
            m_isPickedUp = value;
        }
    }
    public bool CanBePickedUp
    {
        get => m_canBePickedUp;
        set
        {
            m_canBePickedUp = value;
        }
    }

    [SerializeField]
    private bool m_isPickedUp = false;

    [SerializeField]
    private bool m_canBePickedUp = true;

    [SerializeField]
    private Rigidbody m_rb;

    [SerializeField]
    private float m_throwForce = 1.5f;

    [SerializeField]
    private float m_timer = 0;
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {

        if (m_interaction.IsActivated)
        {
            if (m_canBePickedUp)
            {
                if (Input.GetKeyUp(KeyCode.F))
                {
                    PickUpPlayer();
                }
            }
            else if (m_isPickedUp)
            {
                if (Input.GetKey(KeyCode.F))
                {
                    m_timer += Time.deltaTime;
                    m_throwForce += 0.01f;
                }
                else if((Input.GetKeyUp(KeyCode.F) && m_timer > 1))
                {
                    Throw();
                    m_timer = 0;
                    m_throwForce = 5f;
                }
                else if((Input.GetKeyUp(KeyCode.F) && m_timer < 1))
                {
                    LetGoPlayer();
                    m_timer = 0;
                    m_throwForce = 5f;
                }
            }
        }
    }

    public void PickUpPlayer()
    {
        this.GetComponentInChildren<SphereCollider>().enabled = false;
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Rigidbody>().useGravity = false;
        this.transform.SetParent(m_attachPoint.gameObject.transform);
        this.transform.position = m_attachPoint.transform.position;
        IsPickedUp = true;
        CanBePickedUp = false;
    }

    public void LetGoPlayer()
    {
        this.GetComponentInChildren<SphereCollider>().enabled = true;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().useGravity = true;
        this.transform.SetParent(null);
        IsPickedUp = false;
        CanBePickedUp = true;
    }

    public void Throw()
    {
        LetGoPlayer();
        m_rb.AddForceAtPosition(GameManager.Instance.Player.transform.forward * m_throwForce, this.transform.position, ForceMode.Impulse);
    }
}
