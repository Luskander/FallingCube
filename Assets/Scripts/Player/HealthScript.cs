using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int Health;
    public int MaxHealth;

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

	void Start()
	{
		Health = MaxHealth;
	}

	void Update()
	{
		HealthUpdate();
	}

	public void HealthUpdate()
	{
		if (Health > MaxHealth)
		{
			Health = MaxHealth;
		}

		else if(Health == 0)
		{
			PlayerScript.isDead = true;
		}

		for (int i = 0; i < hearts.Length; i++)
		{
			if (i < Health)
			{
				hearts[i].sprite = fullHeart;
			}
			else
			{
				hearts[i].sprite = emptyHeart;
			}

			if (i < MaxHealth)
			{
				hearts[i].enabled = true;
			}
			else
			{
				hearts[i].enabled = false;
			}
		}
	}

	public void SetHealth(int health)
	{
		Health = health;
	}

	public void SetMaxHealth(int maxhealth)
	{
		MaxHealth = maxhealth;
	}
}
