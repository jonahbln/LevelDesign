using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static bool XRAY = false;

    public float speed = 10f;
    public float jumpHeight = 10f;
    public float gravity = 9.81f;
    public float airControl = 10f;

    CharacterController controller;
    Vector3 input;

    AudioSource goggleSound;

    Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        goggleSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        input = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;

        input *= speed;

        if (XRAY) input *= 0.5f;

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            XRAY = !XRAY;

            if(!goggleSound.enabled) {
                goggleSound.enabled = true;
            }
            else {
                goggleSound.enabled = false;
            }
            
        }

        if (controller.isGrounded)
        {

            moveDirection = input;

            //we can jump
            if (Input.GetButton("Jump"))
            {

                moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);

            }
            else
            {
                moveDirection.y = 0f;
            }

        }
        else
        {
            input.y = moveDirection.y;
            moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(input * Time.deltaTime);
    }
}
