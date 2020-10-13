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

	[SerializeField] private Image playerPreview;
	[SerializeField] private TextMeshProUGUI abilityText;

	[SerializeField] private GameObject purchaseCost;
	[SerializeField] private GameObject equipButton;
	[SerializeField] private GameObject playerPrefab;

	private int starsValue;

	Color yellow = new Color(255, 194, 0);
	Color red = new Color(255, 0, 0);

	private void Start()
	{
		PlayerPrefs.SetInt("Default", 1);
		//PlayerPrefs.SetInt("Green", 0);
		//PlayerPrefs.SetInt("Violet", 0);
		PopulateShop();
	}

	private void Update()
	{
		StarsUpdate();
	}

	private void OnButtonClick(ShopItem item)
	{
		playerPreview.sprite = item.sprite;
		SetAbilityText(item);
		if(PlayerPrefs.GetInt($"{item.Name}") == 1)
		{
			purchaseCost.SetActive(false);
			equipButton.SetActive(true);

			if (item.sprite == playerPrefab.GetComponent<SpriteRenderer>().sprite)
			{
				equipButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Equipped";
			}
			else
			{
				equipButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Equip";
			}
		}
		else
		{
			purchaseCost.SetActive(true);
			equipButton.SetActive(false);

			purchaseCost.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Convert.ToString(item.Cost);
		}
	}
	private void PopulateShop()
	{
		purchaseCost.SetActive(false);
		equipButton.SetActive(true);
		equipButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Equipped";

		for (int i = 0; i < shopItem.Length; i++)
		{
			ShopItem item = shopItem[i];
			GameObject itemObject = Instantiate(shopItemPrefab, shopContainer);

			itemObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(item));

			itemObject.transform.GetChild(0).GetComponent<Image>().sprite = item.sprite;
			itemObject.name = item.Name;

			if(item.sprite == playerPrefab.GetComponent<SpriteRenderer>().sprite)
			{
				playerPreview.sprite = playerPrefab.GetComponent<SpriteRenderer>().sprite;
				SetAbilityText(item);
			}
		}
	}

	private void StarsUpdate()
	{
		starsValue = PlayerPrefs.GetInt("StarsCount");
		starsCount.text = Convert.ToString(starsValue);
	}

	public void PurchaseItem()
	{
		for(int i = 0; i < shopItem.Length; i++)
		{
			ShopItem item = shopItem[i];
			if(item.sprite == playerPreview.sprite)
			{
				if (starsValue >= item.Cost)
				{
					starsValue -= item.Cost;

					PlayerPrefs.SetInt("StarsCount", starsValue);
					PlayerPrefs.SetInt($"{item.Name}", 1);

					purchaseCost.SetActive(false);
					equipButton.SetActive(true);
					equipButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Equip";
				}

				else
				{
					StartCoroutine(Wait());
					Debug.Log("Not enough stars");
				}
			}
		}
	}
	private void SetAbilityText(ShopItem item)
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

	public void EquipItem()
	{
		for (int i = 0; i < shopItem.Length; i++)
		{
			ShopItem item = shopItem[i];
			if (item.sprite == playerPreview.sprite)
			{
				playerPrefab.GetComponent<SpriteRenderer>().sprite = item.sprite;
				equipButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Equipped";
				DontDestroyOnLoad(playerPrefab);
			}
		}

	}

	IEnumerator Wait()
	{
		starsCount.color = red;
		yield return new WaitForSeconds(0.2f);
		starsCount.color = yellow;
	}
}
