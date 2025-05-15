using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Transform head;
    public Camera camera;

    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;

    private float verticalLookRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        RotateView();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float z = Input.GetAxis("Vertical");   // W/S or Up/Down

        Vector3 move = transform.right * x + transform.forward * z;
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * move);
    }

    void RotateView()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the player (yaw)
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera (pitch)
        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        head.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
    }
}
