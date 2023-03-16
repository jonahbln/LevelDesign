using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 10f;

    Transform playerBody;

    float pitch = 0;

    public GameObject crosshair;

    public float zoomAmount = 10f;

    public GameObject targetSnake;

    Camera cam;

    bool seen = false;

    public GameObject winText;


    void Start()
    {
        playerBody = transform.parent.transform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        cam = UnityEngine.Camera.main;
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

        if(Input.GetMouseButton(1))
        {
            GetComponent<Camera>().fieldOfView = zoomAmount;
            crosshair.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                if (seen == true) {
                    winText.SetActive(true);
                  
                }
                crosshair.GetComponent<Animator>().SetBool("click", true);
                Invoke("reset", 1);
                
            }
        }
        else
        {

            crosshair.SetActive(false);
            GetComponent<Camera>().fieldOfView = 60;
        }

        Vector3 viewPos = cam.WorldToViewportPoint(targetSnake.transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0) {
            seen = true;
        }
        else {
            seen = false;
        }

    }
    void reset()
    {
        crosshair.GetComponent<Animator>().SetBool("click", false);
    }
}


