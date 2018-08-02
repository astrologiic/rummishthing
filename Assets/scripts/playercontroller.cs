using UnityEngine;
using System.Collections;
using System;

public class playercontroller : MonoBehaviour
{

    public Vector2 direction = new Vector2();
    public Vector2 keyDirection;
    public bool IsKeyDown;
    public bool hasInputForMovement
    {
        get
        {
            if (direction.magnitude == 0) return false;
            return true;
        }
    }

    bool facingRight;


    public playercontroller()
    {
        keyDirection = new Vector2();
    }

    private void Awake()
    {
        facingRight = true;
    }
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        Flip();
        keyDirection.x = keyDirection.y = 0;


        if (Input.GetKey("right"))
        {
            keyDirection.x += 1;
        }

        if (Input.GetKey("left"))
        {
            keyDirection.x += -1;
        }

        if (Input.GetKey("up"))
        {
            keyDirection.y += 1;
        }

        if (Input.GetKey("down"))
        {
            keyDirection.y += -1;
        }

        direction = keyDirection;

        //normalize
        direction.Normalize();
    }

    void Flip()
    {
        if(keyDirection.x > 0 && !facingRight || keyDirection.x < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }
}
