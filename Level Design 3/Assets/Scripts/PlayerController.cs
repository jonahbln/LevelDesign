using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpHeight = 1f;
    public float gravity = 9.8f;
    public float airControl = 10f;

    CharacterController controller;
    Vector3 input;
    Vector3 moveDirection;
    bool first = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if(BossBehavior.dead && first)
        {
            jumpHeight += 1f;
            airControl += 3f;
            first = false;
        }

        input = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;

        if (controller.isGrounded)
        {
            moveDirection = input;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);
            }
            else
            {
                moveDirection.y = 0.0f;
            }
        }
        else
        {
            input.y = moveDirection.y;
            moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
        }

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * speed * Time.deltaTime);
    }
}