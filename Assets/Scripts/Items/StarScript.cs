using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarScript : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public float Bound_Y = 6f;

    private int starValue = 0;
    void Update()
    {
        Move();
    }

    void Move()
	{
        Vector2 temp = transform.position;
        temp.y += MoveSpeed * Time.deltaTime;
        transform.position = temp;
        if(temp.y > Bound_Y)
		{
            gameObject.SetActive(false);
		}            
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            SoundManager.instance.StarSound();
        }
    }
}
