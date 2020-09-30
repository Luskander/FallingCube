using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	private void Awake()
	{
		PauseMenu.isPaused = false;
		Time.timeScale = 1f;
	}

	public void PlayGame()
	{
		SceneManager.LoadScene(1);
	}

	public void QuitGame()
	{
		Debug.Log("App is closed");
		Application.Quit();
	}
}
