using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour {
	public Sprite[] weaponSprite;
	public GameObject weaponHolder, slashTrailHolder;
	public SpriteRenderer srWeap, srSlash;
	public List<Weapon> weaponlist;
	public int equipWeapon, weaponDmg;

	// Use this for initialization
	void Start () {
		weaponlist = MenuManager.weaponlist;
		srWeap = weaponHolder.GetComponent<SpriteRenderer> ();
		srSlash = slashTrailHolder.GetComponent<SpriteRenderer> ();
		equipWeapon = PlayerPrefs.GetInt ("EquipWeapon");
		Debug.Log (equipWeapon);
		weaponDmg = weaponlist [equipWeapon].weaponDamage;
		Debug.Log ("Damage : " + weaponDmg.ToString ());
		srWeap.sprite = weaponSprite [equipWeapon];
		//srSlash.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
