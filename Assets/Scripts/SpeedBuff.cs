using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : MonoBehaviour
{
    public float Speed, BoundY, MaxAmount, MinAmount = 0;
    public bool isEaten = false;
    void Update()
    {
        SpeedUp();
        Move();
    }

	private void OnTriggerEnter2D(Collider2D target)
	{
		if(target.gameObject.tag == "Player")
		{
            isEaten = true;
            gameObject.SetActive(false);
		}
	}

    void Move()
	{
        Vector2 temp = transform.position;
        temp.y += Speed * Time.deltaTime;
        transform.position = temp;

        if(temp.y == BoundY)
		{
            gameObject.SetActive(false);
        }
    }

    void SpeedUp()
	{
        if(isEaten)
		{
            Time.timeScale = 2f;
            MinAmount += Time.deltaTime;
            if(MinAmount > MaxAmount)
			{
                Time.timeScale = 1f;
                isEaten = false;
			}
		}
	}
}
