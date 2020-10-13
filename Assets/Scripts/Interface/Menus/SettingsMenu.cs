using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
	public AudioMixer audioMixer;

	[SerializeField] private Slider slider;
	[SerializeField] private Toggle musicToggle;
	[SerializeField] private Toggle soundToggle;

	private bool musicIsChanged = true;
	private bool soundIsActive = true;

	void Start()
	{
		SetStartVolume();
		slider.value = PlayerPrefs.GetFloat("PlayerVolume");
		Debug.Log(PlayerPrefs.GetInt("SoundActive"));
	}
	public void SetVolume(float volume)
	{
		PlayerPrefs.SetFloat("PlayerVolume", volume);
		audioMixer.SetFloat("MasterVolume", volume);
	}

	public void CheckMusic()
	{
		if(musicIsChanged)
		{
			musicIsChanged = false;
			MusicChange(musicIsChanged);
		}
		else
		{
			musicIsChanged = true;
			MusicChange(musicIsChanged);
		}
	}

	public void MusicChange(bool isActive)
	{
		if(isActive)
		{
			audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("PlayerVolume"));
			PlayerPrefs.SetInt("MusicActive", 1);
		}
		else
		{
			audioMixer.SetFloat("MusicVolume", -80);
			PlayerPrefs.SetInt("MusicActive", 0);
		}
	}


	public void CheckSound()
	{
		if (soundIsActive)
		{
			soundIsActive = false;
			SoundChange(soundIsActive);
		}
		else
		{
			soundIsActive = true;
			SoundChange(soundIsActive);
		}
	}

	public void SoundChange(bool isActive)
	{
		if (isActive)
		{
			audioMixer.SetFloat("SoundVolume", PlayerPrefs.GetFloat("PlayerVolume"));
			PlayerPrefs.SetInt("SoundActive", 1);
		}
		else
		{
			audioMixer.SetFloat("SoundVolume", -80);
			PlayerPrefs.SetInt("SoundActive", 0);
		}
	}

	public void SetStartVolume()
	{
		if (PlayerPrefs.GetInt("SoundActive") == 1)
		{
			soundToggle.isOn = true;
			audioMixer.SetFloat("SoundVolume", PlayerPrefs.GetFloat("PlayerVolume"));
		}

		else if (PlayerPrefs.GetInt("SoundActive") == 0)
		{
			soundToggle.isOn = false;
			audioMixer.SetFloat("SoundVolume", -80);
		}

		if (PlayerPrefs.GetInt("MusicActive") == 1)
		{
			musicToggle.isOn = true;
			audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("PlayerVolume"));
		}

		else if (PlayerPrefs.GetInt("MusicActive") == 0)
		{
			musicToggle.isOn = false;
			audioMixer.SetFloat("MusicVolume", -80);
		}
	}
}
