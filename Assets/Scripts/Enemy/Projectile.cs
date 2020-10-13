using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;

    private Transform player;
    private Vector2 target;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
		{
            DestroyProjectile();
		}
    }

	private void OnTriggerEnter2D(Collider2D target)
	{
		if(target.CompareTag("Player"))
		{
            DestroyProjectile();
            if (!BuffInfluence.isImmune)
            {
                PlayerScript.CurrentHealth--;
                SoundManager.instance.DeathSound();

                if (PlayerScript.CurrentHealth == 0)
                {
                    target.transform.position = new Vector2(1000f, 1000f);
                    SoundManager.instance.DeathSound();
                    PlayerScript.isDead = true;
                    //GameManager.instance.RestartGame();
                }
            }
		}
	}

	void DestroyProjectile()
	{
        Destroy(gameObject);
	}
}
