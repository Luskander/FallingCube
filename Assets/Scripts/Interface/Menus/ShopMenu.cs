using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI starsCount;
	[SerializeField] private ShopItem[] shopItem;

	[SerializeField] private Transform shopContainer;
	[SerializeField] private GameObject shopItemPrefab;

	private int starsValue;

	Color yellow = new Color(255, 194, 0);
	Color red = new Color(255, 0, 0);

	private void Start()
	{
		PopulateShop();
	}

	private void Update()
	{
		ScoreUpdate();
	}

	private void OnButtonClick(GameObject itemObject, ShopItem item)
	{
		if(starsValue >= item.Cost)
		{
			starsValue -= item.Cost;

			PlayerPrefs.SetInt("StarsCount", starsValue);
			PlayerPrefs.SetInt($"{item.Name}", 1);

			itemObject.GetComponent<Button>().interactable = false;
			itemObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Bought";
			itemObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().fontSize = 23;
		}

		else
		{
			StartCoroutine(Wait());
			Debug.Log("Not enough stars");
		}
	}
	private void PopulateShop()
	{
		for (int i = 0; i < shopItem.Length; i++)
		{
			ShopItem item = shopItem[i];
			GameObject itemObject = Instantiate(shopItemPrefab, shopContainer);

			if (PlayerPrefs.GetInt($"{item.Name}") == 1)
			{
				itemObject.GetComponent<Button>().interactable = false;
				itemObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Bought";
				itemObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().fontSize = 16;
			}
			else
			{
				PlayerPrefs.SetInt($"{item.Name}", 0);
				itemObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(itemObject, item));
				itemObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Convert.ToString(item.Cost);
			}

			itemObject.transform.GetChild(0).GetComponent<Image>().sprite = item.sprite;
		}
	}

	void ScoreUpdate()
	{
		starsValue = PlayerPrefs.GetInt("StarsCount");
		starsCount.text = Convert.ToString(starsValue);
	}

	IEnumerator Wait()
	{
		starsCount.color = red;
		yield return new WaitForSeconds(0.2f);
		starsCount.color = yellow;
	}
}
