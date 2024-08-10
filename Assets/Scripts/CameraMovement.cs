using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //variables
    float mouseX;
    float mouseY;
    float xRotation;
    float yRotation;
    public float positionSmoothTime = 0.2f; // Smoothing time for position
    public float rotationSmoothTime = 0.2f; // smoothing time for rotation

    private Vector3 positionVelocity = Vector3.zero;

    //components
    public Transform player;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }
    // -16.79 13.9 -27.1
    // Update is called once per frame
    void Update()
    {
        //transform.position = player.position;
        Cursor.lockState = CursorLockMode.Locked;
        MyInput();
    }

    void MyInput()
    {
        mouseX = Input.GetAxis("Mouse X") * 100f * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * 100f * Time.deltaTime;

        //rotate player along Y-axis
        //yRotation += mouseX;


        //rotate camera along X-axis
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        player.Rotate(Vector3.up * mouseX);

    }

    
}
