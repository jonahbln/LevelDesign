using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 10f;

    Transform playerBody;

    float pitch = 0;

    //public GameObject crosshair;


    void Start()
    {
        playerBody = transform.parent.transform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float moveY = Input.GetAxis("Mouse Y") * mouseSensitivity * 2.5f * Time.deltaTime;

        //yaw
        playerBody.Rotate(Vector3.up * moveX);

        //pitch
        pitch -= moveY;

        pitch = Mathf.Clamp(pitch, -90f, 45f);

        transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }
}


