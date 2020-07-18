using System;
using UnityEngine;

public class LookAround_Mouse : MonoBehaviour
{
    [SerializeField] private float mosueSensitivity =100f;
    public Transform playerBody;
    float rotationX = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mosueSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mosueSensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
