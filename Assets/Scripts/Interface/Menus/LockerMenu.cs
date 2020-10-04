using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockerMenu : MonoBehaviour
{
	[SerializeField] private LockerItem[] lockerItem;

	[SerializeField] private Transform lockerContainer;
	[SerializeField] private GameObject shopItemPrefab;
	[SerializeField] private GameObject playerPrefab;
	[SerializeField] private Image playerPreview;

	private void Start()
	{
		PopulateLocker();
	}

	private void PopulateLocker()
	{
		for(int i = 0; i < lockerItem.Length; i++)
		{
			LockerItem item = lockerItem[i];

			if(PlayerPrefs.GetInt($"{item}") == 1)
			{
				GameObject itemObject = Instantiate(shopItemPrefab, lockerContainer);
				itemObject.transform.GetChild(1).GetComponent<Image>().sprite = item.sprite;
				itemObject.transform.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(item));
			}
		}
	}

	
	private void OnButtonClick(LockerItem item)
	{
		playerPreview.sprite = item.sprite;
		playerPrefab.GetComponent<SpriteRenderer>().sprite = item.sprite;
		DontDestroyOnLoad(playerPrefab);
	}
}
