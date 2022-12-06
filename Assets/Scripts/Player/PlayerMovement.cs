using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    // the Movementspeed.
    [SerializeField]
    private float m_movementSpeed = 5f;
    // The Speed for the Camera Rotation.
    [SerializeField]
    private float m_cameraRotationSpeed = 100f;
    // The Body of the Player.
    [SerializeField]
    private Transform m_playerBody;
    // The Main Camera.
    [SerializeField]
    private Transform m_camera;
    // The Rigidbody of the Player.
    private Rigidbody m_rb;
    // Input Values of the X and Y for the Rotation.
    private float m_mouseX;
    private float m_mouseY;
    // The x Rotation.
    private float m_xRotation = 0f;
    // Event for the Opening of the Options.
    public UnityEvent OnOptionsOpenEvent;
    // Event for the Closing of the Options.
    public UnityEvent OnOptionsCloseEvent;
    // Says, if the Options is Open.
    private bool m_optionsIsOpen = false;
    // Says, if the Player can currently Move or Look around.
    private bool m_canMoveAndRotate = true;
    /// <summary>
    /// Locks the Mouse.
    /// </summary>
    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    /// <summary>
    /// Unlocks the Mouse.
    /// </summary>
    public void UnLockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    /// <summary>
    /// Locks the Movement and Rotation of the Player.
    /// </summary>
    public void LockMovement()
    {
        m_canMoveAndRotate = false;
    }
    /// <summary>
    /// Unlocks the Movement and Rotation of the Player.
    /// </summary>
    public void UnlockMovement()
    {
        m_canMoveAndRotate = true;
    }
    /// <summary>
    /// Sets the Rigidbody.
    /// </summary>
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }
    /// <summary>
    /// Update Functions, Moves and Rotates acording to the Player Inputs.
    /// Options Input Managment.
    /// </summary>
    private void Update()
    {
        if (m_canMoveAndRotate)
        {
            Movement();
            Rotation();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (m_optionsIsOpen)
            {
                OnOptionsCloseEvent.Invoke();
                m_optionsIsOpen = false;
            }
            else
            {
                OnOptionsOpenEvent.Invoke();
                m_optionsIsOpen = true;
            }
        }
    }
    /// <summary>
    /// Moves the Player.
    /// </summary>
    private void Movement()
    {
        Vector3 dir = m_camera.transform.forward * Input.GetAxisRaw("Vertical") + m_camera.transform.right * Input.GetAxisRaw("Horizontal");
        dir = dir.normalized * m_movementSpeed;
        dir.y = m_rb.velocity.y;
        m_rb.velocity = dir;
    }
    /// <summary>
    /// Rotates the Camera.
    /// </summary>
    private void Rotation()
    {
        m_mouseX = Input.GetAxis("Mouse X") * m_cameraRotationSpeed * Time.deltaTime;
        m_mouseY = Input.GetAxis("Mouse Y") * m_cameraRotationSpeed * Time.deltaTime;

        m_xRotation -= m_mouseY;
        m_xRotation = Mathf.Clamp(m_xRotation, -90f, 90f);

        m_camera.localRotation = Quaternion.Euler(m_xRotation, 0f, 0f);

        m_playerBody.Rotate(Vector3.up * m_mouseX);
    }
}
