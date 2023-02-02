using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    /* 
    Create a variable called 'rb' that will represent the 
    rigid body of this object.
    */
    private Rigidbody rb;

    // Create a public variable for the cameraTarget object
    public GameObject cameraTarget;
    /* 
    You will need to set the cameraTarget object in Unity. 
    The direction this object is facing will be used to determine
    the direction of forces we will apply to our player.
    */
    public float movementIntensity;

    public float jumpIntensity = 1.0f;

    private bool isGrounded;
    /* 
    Creates a public variable that will be used to set 
    the movement intensity (from within Unity)
    */
    float lastJump;

    public int speed;

    private float gravityValue = -9.81f;

    public CharacterController characterController;

    public Transform cameraHolder;
    public float mouseSens = 4f;
    public float upLimit = -50;
    public float downLimit = 50;

    Vector3 playerVelocity;

    void Start()
    {
        // make our rb variable equal the rigid body component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        /* 
    	Establish some directions 
    	based on the cameraTarget object's orientation 
    	
        var ForwardDirection = cameraTarget.transform.forward;
        var RightDirection = cameraTarget.transform.right;

        // Move Forwards
        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(ForwardDirection * movementIntensity);
            /* You may want to try using velocity rather than force.
            This allows for a more responsive control of the movement
            possibly better suited to first person controls, eg: 
            //rb.velocity = ForwardDirection * movementIntensity;
        }
        // Move Backwards
        if (Input.GetKey(KeyCode.S)) {
            // Adding a negative to the direction reverses it
            rb.AddForce(-ForwardDirection * movementIntensity);
        }
        // Move Rightwards (eg Strafe. *We are using A & D to swivel)
        if (Input.GetKey(KeyCode.E)) {
            rb.AddForce(RightDirection * movementIntensity);
        }
        // Move Leftwards
        if (Input.GetKey(KeyCode.Q)) {
            rb.AddForce(-RightDirection * movementIntensity);
        } */
        if (Cursor.visible == true)
        {
            Cursor.visible = false;
        }


        Move();
        Rotate();

        isGrounded = characterController.isGrounded;

        if (isGrounded && playerVelocity.y < 0) {
            playerVelocity.y = 0f;
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpIntensity * -3.0f * gravityValue);

        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    public void Move()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * verticalAxis + transform.right * horizontalAxis;
        characterController.Move(move * Time.deltaTime * speed);

    }

    public void Rotate()
    {
        float horizontalRot = Input.GetAxis("Mouse X");
        float verticalRot = Input.GetAxis("Mouse Y");

        transform.Rotate(0, horizontalRot * mouseSens, 0);
        cameraHolder.Rotate(-verticalRot * mouseSens, 0, 0);

        Vector3 currentRotation = cameraHolder.localEulerAngles;
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
        cameraHolder.localRotation = Quaternion.Euler(currentRotation);
    }
}