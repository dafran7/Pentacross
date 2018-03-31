using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour {
	public Sprite[] weaponSprite;
	public GameObject weaponHolder, slashTrailHolder;
	public SpriteRenderer srWeap, srSlash;
	// Use this for initialization
	void Start () {
		srWeap = weaponHolder.GetComponent<SpriteRenderer> ();
		srSlash = slashTrailHolder.GetComponent<SpriteRenderer> ();
		srWeap.sprite = weaponSprite [1];
		srSlash.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
