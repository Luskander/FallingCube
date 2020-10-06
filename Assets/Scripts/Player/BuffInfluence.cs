using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuffInfluence : MonoBehaviour
{
	public static BuffInfluence instance;

	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private Sprite defaultSprite;
	[SerializeField] private Sprite immuneSprite;

	public float SpeedTotalTime = 5f;
	public float ImmuneTotalTime = 5f;
	public float DoubleTotalTime = 5f;

	private float timeCounter = 0f;

	private bool isTooked = false;

	private bool isSpeed = false;

	public static bool isImmune = false;

	public static bool isDoubled = false;

	void Awake()
	{
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

	void Start()
	{
		Time.timeScale = 1f;
	}

	void Update()
	{
		ImmuneBuff();
		SpeedBuff();
		DoubleBuff();
	}

	private void OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.tag == "SpeedBuff")
		{
			isTooked = true;
			isSpeed = true;
		}

		if(target.gameObject.tag == "ImmuneBuff")
		{
			isTooked = true;
			isImmune = true;
		}

		if(target.gameObject.tag == "DoubleBuff")
		{
			isTooked = true;
			isDoubled = true;
		}
	}

	void SpeedBuff()
	{
		if (isSpeed)
		{
			if (isTooked)
			{
				timeCounter = 0f;
				isTooked = false;
			}

			else if (timeCounter < SpeedTotalTime)
			{
				timeCounter += Time.deltaTime;
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

	void ImmuneBuff()
	{
		if (isImmune)
		{
			spriteRenderer.sprite = immuneSprite;

			if(isTooked)
			{
				timeCounter = 0f;
				isTooked = false;
			}

			else if (timeCounter < ImmuneTotalTime)
			{
				timeCounter += Time.deltaTime;
			}

			else
			{
				spriteRenderer.sprite = defaultSprite;
				timeCounter = 0f;
				isImmune = false;
			}
		}
	}

	void DoubleBuff()
	{
		if(isDoubled)
		{
			if(isTooked)
			{
				timeCounter = 0f;
				isTooked = false;
			}
			
			else if(timeCounter < DoubleTotalTime)
			{
				timeCounter += Time.deltaTime;
			}

			else
			{
				isDoubled = false;
				timeCounter = 0f;
			}
		}
	}
}
