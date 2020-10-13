using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode()]
public class LevelProgressBar : MonoBehaviour
{
    public int Minimum;
    public int Maximum;
    public float CurrentProgress;

    private int currentLVL;

    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI lvlText;

	void Start()
	{
        CurrentProgress = 0f;
        currentLVL = PlayerPrefs.GetInt("PlayerLVL");
        lvlText.text = "" + currentLVL;
	}

	void Update()
    {
        GetCurrentFill();
        UpdateLevel();
    }

    void GetCurrentFill()
	{
        CurrentProgress += Time.deltaTime;

        float currentOffset = CurrentProgress - Minimum;
        float maximumOffset = Maximum - Minimum;
        float fillAmount = currentOffset / maximumOffset;

        progressBar.fillAmount = fillAmount;
	}

    void UpdateLevel()
	{
        if(CurrentProgress > Maximum)
		{
            currentLVL++;
            PlayerPrefs.SetInt("PlayerLVL", currentLVL);
            lvlText.text = "" + currentLVL;
            CurrentProgress = 0f;
        }
    }
}
