using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponList : MonoBehaviour
{
	List<Weapon> weaponlist;
	void Start(){
		weaponlist = MenuManager.weaponlist;
		//List<Weapon> weaponlist = new List<Weapon>();
		//weaponlist.Add(new Weapon("pedang biasa", 10, "Pedang yang sangat biasa dibuat oleh orang biasa dihari yang biasa", 1, false));
		//weaponlist.Add(new Weapon ("Pedang Lumayan", 20, "desc 2", 50, false));
		Debug.Log (weaponlist[0].weaponName+" "+weaponlist [0].sold);
		Debug.Log (weaponlist [5].weaponName + " "+weaponlist[5].weaponDamage);
		PlayerPrefs.SetString ("weapon" + weaponlist [0].weaponName.ToString (), "true");
		weaponlist [0].sold = System.Convert.ToBoolean(PlayerPrefs.GetString ("weapon" + weaponlist [0].weaponName.ToString ()));
		Debug.Log (weaponlist[0].weaponName+" "+weaponlist [0].sold);
	}
}

