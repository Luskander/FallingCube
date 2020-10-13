using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LockerMenu : MonoBehaviour
{
	[SerializeField] private LockerItem[] lockerItem;

	[SerializeField] private Transform lockerContainer;
	[SerializeField] private GameObject lockerItemPrefab;
	[SerializeField] private GameObject playerPrefab;
	[SerializeField] private Image playerPreview;
	[SerializeField] private TextMeshProUGUI abilityText;

	private void Start()
	{
		PopulateLocker();
	}

	private void Update()
	{
		UpdateLocker();
	}

	private void PopulateLocker()
	{
		for(int i = 0; i < lockerItem.Length; i++)
		{
			LockerItem item = lockerItem[i];
			if (PlayerPrefs.GetInt($"{item.Name}") == 1)
			{
				GameObject itemObject = Instantiate(lockerItemPrefab, lockerContainer);
				itemObject.GetComponent<Image>().sprite = item.sprite;
				itemObject.transform.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(item));
				itemObject.name = item.Name;
			}

			if(item.Name == PlayerPrefs.GetString("PlayerPreview"))
			{
				playerPreview.sprite = item.sprite;
				SetAbilityText(item);
			}
		}
	}

	private void UpdateLocker()
	{
		for(int i = 0; i < lockerItem.Length; i++)
		{
			LockerItem item = lockerItem[i];
			if (!GameObject.Find($"{item.Name}") && PlayerPrefs.GetInt($"{item.Name}") == 1)
			{
				GameObject itemObject = Instantiate(lockerItemPrefab, lockerContainer);
				itemObject.GetComponent<Image>().sprite = item.sprite;
				itemObject.transform.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(item));
				itemObject.name = item.Name;
			}
		}
	}

	
	private void OnButtonClick(LockerItem item)
	{
		PlayerPrefs.SetString("PlayerPreview", item.Name);
		SetAbilityText(item);

		playerPreview.sprite = item.sprite;
		playerPrefab.GetComponent<SpriteRenderer>().sprite = item.sprite;

		DontDestroyOnLoad(playerPrefab);
	}

	private void SetAbilityText(LockerItem item)
	{
		switch (item.Name)
		{
			case "Default":
				{
					abilityText.text = "None";
					break;
				}
			case "Green":
				{
					abilityText.text = "Additional life";
					break;
				}
			case "Violet":
				{
					abilityText.text = "Immune to spiked platforms";
					break;
				}
		}
	}
}
