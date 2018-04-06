using UnityEngine;
using System.Collections;

public class Potion
{
	public int potionID;
	public string potionName;
	public int HealingAmount;
	public string potionDescription;
	public int price;
	public int held;

	public Potion(string newName, int newHealAmount, string newDescription, int newPrice, int newHeld){
		potionName = newName;
		HealingAmount = newHealAmount;
		potionDescription = newDescription;
		price = newPrice;
		held = newHeld;
	}
}

