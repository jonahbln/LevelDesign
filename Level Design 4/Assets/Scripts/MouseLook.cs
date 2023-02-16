using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Vector3 startRotate = new Vector3(0,0,0);

    Transform playerBody;

    float pitch = 0;


    void Start()
    {
        playerBody = transform.parent.transform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        transform.rotation = Quaternion.Euler(startRotate);
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = (Input.GetAxis("Mouse X")) * mouseSensitivity * Time.deltaTime;
        float moveY = (Input.GetAxis("Mouse Y")) * mouseSensitivity * Time.deltaTime;

        //yaw
        playerBody.Rotate(Vector3.up * moveX);

        //pitch
        pitch -= moveY;

        pitch = Mathf.Clamp(pitch, -90f, 90f);

        transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }
}
