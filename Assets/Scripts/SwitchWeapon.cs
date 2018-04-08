using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchWeapon : MonoBehaviour
{
	public Sprite[] Weapons;
	public int equipWeapon, weaponDmg;
	SpriteRenderer sr;
	public List<Weapon> weaponlist;
	// Use this for initialization
	void Start ()
	{
		weaponlist = MenuManager.weaponlist;
		sr = gameObject.GetComponent<SpriteRenderer>();
		equipWeapon = PlayerPrefs.GetInt ("EquipWeapon");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

