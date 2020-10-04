using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : MonoBehaviour
{
    public float Speed, BoundY;
    void Update()
    {
        Move();
    }

	private void OnTriggerEnter2D(Collider2D target)
	{
		if(target.gameObject.tag == "Player")
		{
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
}
