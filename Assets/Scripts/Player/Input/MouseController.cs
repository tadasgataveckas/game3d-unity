using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{
    [SerializeField] public float sensitivity = 5.0f;
    [SerializeField] public float maxOffset = 50.0f;
    [SerializeField]public float maxRotationSpeed = 100.0f;
    private Vector2 centerPosition; // Center of the screen
    private float rotationDelta;

    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;

        // Get the center position of the screen
        centerPosition = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);
    }

    void Update()
    {
        // Read mouse movement input
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        
        // Apply sensitivity
        mouseDelta *= sensitivity * Time.deltaTime;

        // Clamp the mouse delta
        mouseDelta.x = Mathf.Clamp(mouseDelta.x, -maxOffset, maxOffset);

        // Add mouse delta to rotation delta around Z-axis
        rotationDelta += mouseDelta.x;

        // Limit rotation delta
        rotationDelta = Mathf.Clamp(rotationDelta, -maxRotationSpeed, maxRotationSpeed);

        // Rotate the player around Z-axis
        transform.Rotate(Vector3.up, rotationDelta);

        // Reset rotation delta
        rotationDelta = 0.0f;

        // Move the cursor back to the center
        if (Mathf.Abs(Mouse.current.position.x.ReadValue() - centerPosition.x) > maxOffset ||
            Mathf.Abs(Mouse.current.position.y.ReadValue() - centerPosition.y) > maxOffset)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
