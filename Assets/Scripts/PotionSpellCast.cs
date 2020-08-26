using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PotionSpellCast : MonoBehaviour
{

	public bool immortal = false,
				might = false,
				transcend = false;

	List<Spell> spelllist;
	List<Potion> potionlist;
	// Use this for initialization
	void Start ()
	{
		spelllist = MenuManager.spelllist;
		potionlist = MenuManager.potionlist;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Barrier(){
		StartCoroutine (BarrierCast ());
		//Deactivate button buat spell
	}

	IEnumerator BarrierCast(){
		/*
		 * masukkin bool immortal di ontrigger/oncollision yg ngasih dmg ke player
		 * bikin if(!immortal) kena damage
		 */
		immortal = true;
		int duration = spelllist [0].spellDuration;
		//Bangkitin effect barrier disini
		yield return new WaitForSeconds (duration);
		//Matiin effect barrier disini
		immortal = false;

		Debug.Log ("END BARRIER");
	}

	public void Might(){
		StartCoroutine (MightCast ());
		//Deactivate button buat spell
	}

	IEnumerator MightCast(){
		/*
		 * kasih might ke dmgweapon
		 * if(might active) weaponDmg + might Dmg(10)
		 */
		might = true;
		int duration = spelllist [1].spellDuration;
		//Bangkitin effect might disini
		yield return new WaitForSeconds(duration);
		//Matiin effect might disini
		might = false;
		Debug.Log ("END MIGHT");
	}

	public void Transcend(){
		StartCoroutine (TranscendCast ());
		//Deactivate button buat spell
	}

	IEnumerator TranscendCast(){
		/*
		 * bikin instantiate gameobject yg munculin swordwave. sword wave gerak lurus terus ke kanan sesuai posisi player saat instantiate
		 * di fungsi attack bikin if(transcend)
		 * kalo true, instantiate gameobjectnya,
		 * kasih damage sesuai damage weapon
		 */
		transcend = true;
		int duration = spelllist [2].spellDuration;
		//Bangkitin effect transcend disini
		yield return new WaitForSeconds(duration);
		//Matiin effect transcend disini
		transcend = false;

		Debug.Log ("END TRANSCEND");
	}

	public void HealPotion(){
		int potion = PlayerPrefs.GetInt("EquipPotion");
		int healAmount = potionlist [potion].HealingAmount;
		//playerHP +=healAmount
		//Set slider biar angka hpnya sama
		potionlist[potion].held-=1;
		//Deactivate button buat heal
	}
}

