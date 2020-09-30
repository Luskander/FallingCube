using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public float Bound_Y = 6f;

    public bool MovingPlatformLeft, MovingPlatformRight, IsBreakable, IsSpike, IsPlatform;
    
    private bool isCanPlaySound;

    private Animator anim;

    void Awake()
    {
        if (IsBreakable)
        {
            anim = GetComponent<Animator>(); // анимации для разрушающейся платформы
        }
    }

    void Update()
    {
        Move();
    }

    void Move()
	{
        Vector2 temp = transform.position;
        temp.y += MoveSpeed * Time.deltaTime;
        transform.position = temp;
        if(temp.y > Bound_Y) // если значение выходит за пределы высоты (BoundY), то убираем платформу
		{
            gameObject.SetActive(false);
		}
	}

    void BreakableDeactivate()
	{
        Invoke("DeactivateGameObject", 0.5f);
	}

    void DeactivateGameObject()
	{
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
	}

    void OnTriggerEnter2D(Collider2D target)
	{
        if (target.tag == "Player")
		{
            if(IsSpike)
			{
                target.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.DeathSound();
                GameManager.instance.RestartGame();
			}
		}
	}

    void OnCollisionEnter2D(Collision2D target)
	{
        if(target.gameObject.tag == "Player")
		{
            isCanPlaySound = true;
            if(!SoundManager.instance.AudioStatus() && isCanPlaySound == true)
			{
                StartCoroutine(PlayLandingSound());
                
			}

            if (IsBreakable)
			{
                anim.Play("Break");
			}
        }
	}

    void OnCollisionStay2D(Collision2D target)
	{
        if(target.gameObject.tag == "Player")
		{
            if(MovingPlatformLeft)
			{
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
			}

            if (MovingPlatformRight)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }
        }
	}

    IEnumerator PlayLandingSound()
	{
        isCanPlaySound = false;
        SoundManager.instance.LandSound();
        yield return new WaitForSeconds(0.05f);
        isCanPlaySound = true;
    }
}
