using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] private GameObject deathMenuUI;
	void Start()
	{
		DeathMenuHide();
	}

	void Update()
	{
		if(PlayerScript.isDead)
		{
			DeathMenuLoad();
		}
	}

	public void DeathMenuLoad()
	{
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
	}

	public void DeathMenuHide()
	{
		deathMenuUI.SetActive(false);
		Time.timeScale = 1f;
	}

    public void Restart()
	{
		PlayerScript.isDead = false;
		Time.timeScale = 1f;
		deathMenuUI.SetActive(false);
		SceneManager.LoadScene(1);
	}

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
