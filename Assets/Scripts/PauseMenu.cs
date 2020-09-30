using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject pauseButton;

    public static bool isPaused;

    public void Resume()
	{
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
	}

    public void Pause()
	{
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
	}

    public void LoadMenu()
	{
        SceneManager.LoadScene(0);
	}
}
