using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // The Attachpoint at the Player.
    [SerializeField]
    private GameObject m_attachPoint;
    // The Interaction.
    [SerializeField]
    private InteractionHandler m_interaction;
    // Says, if the Player has the Ball picked up.
    public bool IsPickedUpbyPlayer
    {
        get => m_isPickedUpByPlayer;
        set
        {
            m_isPickedUpByPlayer = value;
        }
    }
    // Says, if the Ball can be picked up by the Player or Pet.
    public bool CanBePickedUp
    {
        get => m_canBePickedUp;
        set
        {
            m_canBePickedUp = value;
        }
    }
    [SerializeField]
    private bool m_isPickedUpByPlayer = false;

    [SerializeField]
    private bool m_canBePickedUp = true;
    // The Rigidbody of the Ball.
    [SerializeField]
    private Rigidbody m_rb;
    // The Throw Force.
    [SerializeField]
    private float m_throwForce = 1.5f;
    // The Timer how long the Player loads for the Throwing of the Ball.
    [SerializeField]
    private float m_timer = 0;
    /// <summary>
    /// Sets the Rigidbody.
    /// </summary>
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }
    /// <summary>
    /// Check if the Ball can be Picked up or if it is currently picked up.
    /// Handles the Input.
    /// </summary>
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
            else if (m_isPickedUpByPlayer)
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
    /// <summary>
    /// Lets the Player Pick up the Ball.
    /// </summary>
    public void PickUpPlayer()
    {
        this.GetComponentInChildren<SphereCollider>().enabled = false;
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Rigidbody>().useGravity = false;
        this.transform.SetParent(m_attachPoint.gameObject.transform);
        this.transform.position = m_attachPoint.transform.position;
        IsPickedUpbyPlayer = true;
        CanBePickedUp = false;
    }
    /// <summary>
    ///  The Player lets the Ball Go.
    /// </summary>
    public void LetGoPlayer()
    {
        this.GetComponentInChildren<SphereCollider>().enabled = true;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().useGravity = true;
        this.transform.SetParent(null);
        IsPickedUpbyPlayer = false;
        CanBePickedUp = true;
    }
    /// <summary>
    /// The Player Throws the Ball.
    /// </summary>
    public void Throw()
    {
        LetGoPlayer();
        m_rb.AddForceAtPosition(GameManager.Instance.Player.transform.forward * m_throwForce, this.transform.position, ForceMode.Impulse);
    }
}
