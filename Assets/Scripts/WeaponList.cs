using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponList : MonoBehaviour
{
	void Start(){
		List<Weapon> weaponlist = new List<Weapon>();
		weaponlist.Add(new Weapon("pedang biasa", 10, "Pedang yang sangat biasa dibuat oleh orang biasa dihari yang biasa", 1, false));
		weaponlist.Add(new Weapon ("Pedang Lumayan", 20, "desc 2", 50, false));
		Debug.Log (weaponlist[0].weaponName+" "+weaponlist [0].sold);
		PlayerPrefs.SetString ("weapon" + weaponlist [0].weaponName.ToString (), "true");
		weaponlist [0].sold = System.Convert.ToBoolean(PlayerPrefs.GetString ("weapon" + weaponlist [0].weaponName.ToString ()));
		Debug.Log (weaponlist[0].weaponName+" "+weaponlist [0].sold);
	}
}

