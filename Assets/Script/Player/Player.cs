using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private float xRotation = 0;
    private float yRotation = 0;

    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Mouse.current.delta.x.ReadValue();
        float mouseY = Mouse.current.delta.y.ReadValue();
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(0, yRotation, 0);
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }

    public void Jump()
    {
        GetComponent<Rigidbody>().velocity = Vector3.up * Mathf.Sqrt(jumpHeight * -1.0f * gravity);
    }
}
