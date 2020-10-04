using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

	[SerializeField] private AudioSource landSound;
	[SerializeField] private AudioSource starSound;
	[SerializeField] private AudioSource iceBreakSound;
	[SerializeField] private AudioSource deathSound;
	[SerializeField] private AudioSource backgroundMusic;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	void Start()
	{
		backgroundMusic.pitch = 1f;
	}

	void Update()
	{
		if(PauseMenu.isPaused)
		{
			backgroundMusic.volume = 0.12f;
		}
		else
		{
			backgroundMusic.volume = 0.2f;
		}
	}
	public void BGMusic()
	{
		backgroundMusic.Play();
	}

	public void LandSound()
	{
		landSound.Play();
	}

	public void DeathSound()
	{
		deathSound.Play();
	}

	public void IceBreakSound()
	{
		iceBreakSound.Play();
	}

	public void StarSound()
	{
		starSound.Play();
	}

	public bool AudioStatus()
	{
		return landSound.isPlaying;
	}

	public void SpeedingUp()
	{
		backgroundMusic.pitch = 1.06f;
	}

	public void SlowDown()
	{
		backgroundMusic.pitch = 1f;
	}
}
