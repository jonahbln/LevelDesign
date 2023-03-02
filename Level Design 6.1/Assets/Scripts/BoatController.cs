using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatController : MonoBehaviour
{
    public float rowForce = 3f;
    public float torque = 3f;

    Rigidbody rb;
    public Animator rightAnim;
    public Animator leftAnim;

    bool canRowRight = true;
    bool canRowLeft = true;

    public Text gameText;

    enum Direction
    {
        Left,
        Right
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (transform.position.z > 595f)
        {
            rb.velocity = Vector3.zero;
            rb.angularDrag = 1f;
            gameText.text = "YOU WIN!!";
            gameText.gameObject.SetActive(true);
            return;
        }

        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            && canRowRight)
        {
            StartCoroutine("Row", Direction.Right);
            rb.angularDrag = 0.05f;
            leftAnim.Play("LRow");
            rb.AddTorque(transform.up * torque);
            rb.AddForce(transform.forward * rowForce);
        }
        if((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            && canRowLeft)
        {
            StartCoroutine("Row", Direction.Left);
            rb.angularDrag = 0.05f;
            rightAnim.Play("RRow");
            rb.AddTorque(transform.up * -torque);
            rb.AddForce(transform.forward * rowForce);
        }
        rb.velocity = Vector3.MoveTowards(Vector3.ClampMagnitude(rb.velocity, 30f), Vector3.zero, Time.deltaTime * 1.5f);
        rb.angularDrag += 0.01f;

    }

    IEnumerator Row(Direction d)
    {
        if (d == Direction.Right) canRowRight = false;
        if (d == Direction.Left) canRowLeft = false;

        yield return new WaitForSeconds(1f);

        if (d == Direction.Right) canRowRight = true;
        if (d == Direction.Left) canRowLeft = true;

    }
}
