using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public int weaponID;
	public string weaponName;
	public int weaponDamage;
	public string weaponDescription;
	public int price;
	public bool sold;

	public Weapon(string newName, int newDamage, string newDescription,int newPrice,bool isSold){
		weaponName = newName;
		weaponDamage = newDamage;
		weaponDescription = newDescription;
		price = newPrice;
		sold = isSold;
	}
}

