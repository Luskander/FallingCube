using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

enum Direction
{
    Left,
    Right
}
public class EnemyMove : MonoBehaviour
{
    Direction dir = Direction.Right;

    public float Min_X = -2.5f, Max_X = 2.5f, Bound_Y = 6f, MoveSpeed_X = 2f, MoveSpeed_Y = 2f;

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;

        temp.y += MoveSpeed_Y * Time.deltaTime;
        if (temp.y > Bound_Y)
        {
            gameObject.SetActive(false);
        }

        if (temp.x > Max_X)
		{
            dir = Direction.Left;
		}
        else if(temp.x < Min_X)
		{
            dir = Direction.Right;
		}
        
        if(dir == Direction.Right)
		{
            temp.x += MoveSpeed_X * Time.deltaTime;
        }
        else if (dir == Direction.Left)
        {
            temp.x -= MoveSpeed_X * Time.deltaTime;
        }

        transform.position = temp;
    }

	void OnTriggerEnter2D(Collider2D target)
	{
		if(target.gameObject.tag == "Player")
		{
            target.transform.position = new Vector2(1000f,1000f);
            SoundManager.instance.DeathSound();
            GameManager.instance.RestartGame();

        }
	}
}
