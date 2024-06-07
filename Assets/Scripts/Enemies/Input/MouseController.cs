using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{
    [SerializeField] public float sensitivity = 5.0f;
    [SerializeField] public float maxOffset = 50.0f;
    [SerializeField]public float maxRotationSpeed = 100.0f;
    private Vector2 centerPosition;
    private float rotationDelta;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        centerPosition = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);
    }

    void Update()
    {
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        mouseDelta *= sensitivity * Time.deltaTime;
        mouseDelta.x = Mathf.Clamp(mouseDelta.x, -maxOffset, maxOffset);
        rotationDelta += mouseDelta.x;
        rotationDelta = Mathf.Clamp(rotationDelta, -maxRotationSpeed,
                                    maxRotationSpeed);
        transform.Rotate(Vector3.up, rotationDelta);
        rotationDelta = 0.0f;

        if (Mathf.Abs(Mouse.current.position.x.ReadValue() - centerPosition.x) 
            > maxOffset 
            ||
            Mathf.Abs(Mouse.current.position.y.ReadValue() - centerPosition.y)
            > maxOffset)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
