using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;

    public float MoveSpeed = 1f;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

	void Move()
	{
		if(Input.GetAxisRaw("Horizontal") > 0f)
		{
            myBody.velocity = new Vector2(MoveSpeed, myBody.velocity.y);
		}

        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myBody.velocity = new Vector2(-MoveSpeed, myBody.velocity.y);
        }
    }

    public void PlatformMove(float x)
	{
        myBody.velocity = new Vector2(x, myBody.velocity.y);
	}
}
