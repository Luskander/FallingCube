using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/ Shop Item")]
public class ShopItem : ScriptableObject
{
	public Sprite sprite;
	public int Cost;
	public string Name;
}
