using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float StartTimeShots;
    private float currentTimeShots;

    public GameObject projectile;

    private Transform player;
    void Start()
    {
        currentTimeShots = StartTimeShots;
    }

    void Update()
    {
        Shoot(); 
    }

    void Shoot()
	{
        if(currentTimeShots <= 0)
		{
            Instantiate(projectile, transform.position, Quaternion.identity);
            currentTimeShots = StartTimeShots;
		}
        else
		{
            currentTimeShots -= Time.deltaTime;
		}
	}
}
