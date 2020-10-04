using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
	{
        if(instance == null)
		{
            instance = this;
		}
	}

	public void RestartGame()
	{
		Invoke("RestartAfterTime", 0.5f);
	}

	public void RestartAfterTime()
	{
		SceneManager.LoadScene(1);
	}
}
