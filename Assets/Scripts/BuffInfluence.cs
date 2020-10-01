using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuffInfluence : MonoBehaviour
{
	public float SpeedTime = 5f;

	private float timeCounter = 0f;
	private bool isSpeed = false;

	void Start()
	{
		Time.timeScale = 1f;
	}

	void Update()
	{
		if(isSpeed)
		{
			timeCounter += Time.deltaTime;
			if(timeCounter < SpeedTime)
			{
				Time.timeScale = 1.8f;
				SoundManager.instance.SpeedingUp();
			}
			else
			{
				Time.timeScale = 1f;
				SoundManager.instance.SlowDown();
				timeCounter = 0f;
				isSpeed = false;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.tag == "SpeedBuff")
		{
			isSpeed = true;
		}
	}
}
