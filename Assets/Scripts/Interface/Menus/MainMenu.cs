using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private RectTransform menuContainer;

	[SerializeField] private bool smooth;
	[SerializeField] private float smoothSpeed = 0.1f;
	[SerializeField] private Vector3 desiredPosition;

	[SerializeField] private TextMeshProUGUI currentLVL;
	private Vector3[] menuPositions;
	private void Awake()
	{
		PauseMenu.isPaused = false;
	}

	private void Start()
	{
		currentLVL.text = "Level: " + PlayerPrefs.GetInt("PlayerLVL");
		menuPositions = new Vector3[menuContainer.childCount];
		Vector3 halfScreen = new Vector3(Screen.width / 2, Screen.height / 2, 0);
		for(int i = 0; i < menuPositions.Length; i++)
		{
			menuPositions[i] = menuContainer.GetChild(i).position - halfScreen;
		}
	}

	private void Update()
	{
		if(smooth)
		{
			menuContainer.anchoredPosition = Vector3.Lerp(menuContainer.anchoredPosition, desiredPosition, smoothSpeed);
		}
		else
		{
			menuContainer.anchoredPosition = desiredPosition;
		}
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

	public void MoveMenu(int id)
	{
		desiredPosition = -menuPositions[id];
	}
}
