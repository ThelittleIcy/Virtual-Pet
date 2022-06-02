using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_movementSpeed = 5f;
    [SerializeField]
    private float m_cameraRotationSpeed = 100f;

    [SerializeField]
    private Transform m_playerBody;
    [SerializeField]
    private Transform m_camera;

    private Rigidbody m_rb;

    private float m_mouseX;
    private float m_mouseY;

    private float m_xRotation = 0f;
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Movement();
        Rotation();
    }
    private void Movement()
    {
        Vector3 dir = m_camera.transform.forward * Input.GetAxisRaw("Vertical") + m_camera.transform.right * Input.GetAxisRaw("Horizontal");
        dir = dir.normalized * m_movementSpeed;
        dir.y = m_rb.velocity.y;
        m_rb.velocity = dir;
    }

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
