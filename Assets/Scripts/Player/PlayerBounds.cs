using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float Min_X = -2.6f, Max_X = 2.6f, Min_Y = -5.6f;

    private bool isOutOfBounds;
    void Update()
    {
        CheckBounds();
    }

    void CheckBounds()
	{
        Vector2 temp = transform.position;
        if(temp.x > Max_X)
		{
            temp.x = Max_X;
		}

        if(temp.x < Min_X)
		{
            temp.x = Min_X;
		}

        transform.position = temp;

        if(temp.y <= Min_Y)
		{
            if(!isOutOfBounds)
			{
                isOutOfBounds = true;

				SoundManager.instance.DeathSound();
                PlayerScript.isDead = true;
                //GameManager.instance.RestartGame();
			}
		}
	}

    void OnTriggerEnter2D(Collider2D target)
	{
        if(target.tag == "TopSpike")
		{
            transform.position = new Vector2(1000f, 1000f);
            SoundManager.instance.DeathSound();
            PlayerScript.isDead = true;
            //GameManager.instance.RestartGame();
        }
	}
}
