using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{

    public static bool startFight = false;

    public float floatSpeed = 0.1f;

    float timer = 0;

    public Transform playerTransform;

    enum BossState
    {
        Stomp,
        Shoot,
        Idle,
        ReturnToBase
    }

    BossState state;

    [SerializeField] float stateTime = 5;

    Vector3 startPos;

    bool up = true;
    float rotationAmount = 0;

    Vector3 stompTarget;


    void Start()
    {
        state = BossState.Idle;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startFight) return;



        if (state == BossState.Idle)
        {
            Idle();
        } else if (state == BossState.Shoot)
        {
            Shoot();
        } else if (state == BossState.Stomp)
        {
            Stomp();
        } else if (state == BossState.ReturnToBase)
        {
            ReturnToBase();
        }


    }

    // boss stomps on the player
    void Stomp()
    {

        transform.position = Vector3.MoveTowards(transform.position, stompTarget, floatSpeed * 4f * Time.deltaTime);
        if(transform.position.x == stompTarget.x)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(stompTarget.x, stompTarget.y - 7f, stompTarget.z),
                floatSpeed * 8f * Time.deltaTime);
        }
        if(transform.position.y <= stompTarget.y - 7f)
        {
            state = BossState.ReturnToBase;
        }

    }

    //returns the boss to where it started
    void ReturnToBase()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPos, floatSpeed * 8f * Time.deltaTime);
        if (transform.position == startPos)
        {
            state = BossState.Idle;
        }
    }

    //boss shoots the player
    void Shoot()
    {

        timer += Time.deltaTime;

        Vector3 rotationThisFrame = new Vector3(0, 75, 0) * Time.deltaTime;
        rotationAmount += rotationThisFrame.y;
        transform.Rotate(rotationThisFrame);

        if(rotationAmount >= 720)
        {
            transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
            rotationAmount = 0;
            state = BossState.Stomp;
            timer = 0;

            stompTarget = new Vector3(playerTransform.position.x, playerTransform.position.y + 7, playerTransform.position.z);
        }

        if(timer >= 0.5f)
        {
            timer = 0;
            //shoot bullet
        }


    }


    void Idle()
    {

        timer += Time.deltaTime;

        Vector3 floatMax = new Vector3(startPos.x, startPos.y + 3, startPos.z);

        if(up)
        {
            transform.position = Vector3.MoveTowards(transform.position, floatMax, floatSpeed * Time.deltaTime);
            if (transform.position.y >= floatMax.y) up = false;
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, floatSpeed * Time.deltaTime);
            if (transform.position.y <= startPos.y) up = true;
        }

        if(timer >= stateTime)
        {
            timer = 0;
            state = BossState.Shoot;
        }
    }
}
