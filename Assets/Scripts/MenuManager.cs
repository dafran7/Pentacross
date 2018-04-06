using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuManager : MonoBehaviour {
	public GameObject 	frontMenu,
						mainMenu,
						buttonList,
						shop,
						blackBox,
						stageMenu,
						inventory,
						weaponShopList,
						potionShopList,
						spellShopList,
						weaponInventoryList,
						potionInventoryList,
						spellInventoryList,
						blackBoxDesc,
						weaponShopDesc,
						potionShopDesc,
						spellShopDesc,
						weaponInventDesc,
						potionInventDesc,
						spellInventDesc;

	public Button	weaponShop,
					potionShop,
					spellShop,
					weaponInventory,
					potionInventory,
					spellInventory,
					descWeaponBuy;

	public Button[] weaponBuy,
					weaponEquip,
					spellBuy,
					spellEquip,
					potionBuy,
					potionEquip;

	public  Sprite shopButton, inventoryButton;

	public Text coinText,
				shopDescWeaponName,
				shopDescWeaponDamage,
				shopDescWeaponPrice,
				shopDescWeaponDesc,
				shopDescPotionName,
				shopDescPotionEffect,
				shopDescPotionPrice,
				shopDescPotionDesc,
				shopDescSpellName,
				shopDescSpellDuration,
				shopDescSpellPrice,
				shopDescSpellDesc,
				invenDescWeaponName,
				invenDescWeaponDamage,
				invenDescWeaponPrice,
				invenDescWeaponDesc,
				invenDescPotionName,
				invenDescPotionEffect,
				invenDescPotionPrice,
				invenDescPotionDesc,
				invenDescSpellName,
				invenDescSpellDuration,
				invenDescSpellPrice,
				invenDescSpellDesc;

	public Text[] 	spellShopNumber,
					heldSpell,
					potionShopNumber,
					heldPotion;

	public int coin;
	public int shopType=0;
	public string[] weapon={"Api","Air","Tanah"};

	public static List<Weapon> weaponlist;
	public static List<Spell> spelllist;
	public static List<Potion> potionlist;

	// Use this for initialization
	void Start () {
		StartCoroutine (Touchy (frontMenu));
		PlayerPrefs.SetInt ("Coin", 999999999);
		UpdateCoinText ();
		ConstructSpellList ();
		ConstructWeaponList ();
		ConstructPotionList ();
		ShowWeaponPrice ();
		CheckBoughtWeapon ();
		EquipWeapon (0);
		ResetSpellEquip (spellEquip);
		ResetPotionEquip (potionEquip);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ConstructPotionList(){
		potionlist = new List<Potion> ();
		potionlist.Add (new Potion ("Healing Potion (S)", 20, "Hope this can somehow heal you", 100, 1));
		potionlist.Add (new Potion ("Healing Potion (M)", 35, "No healbot no worries", 200, 0));
		potionlist.Add (new Potion ("Healing Potion (L)", 50, "I have half more life to spare", 500, 0));
	}

	void ConstructSpellList(){
		spelllist = new List<Spell> ();
		spelllist.Add (new Spell ("Barrier", 5, "Immune to any damage for 5 seconds", "Death's scythe will not even leave a mark", 100, 1));
		spelllist.Add (new Spell ("Might", 20, "increase damage dealt by 10 for 20 seconds", "The Light shall spread the right, The Might shall held the right", 200, 0));
		spelllist.Add (new Spell ("Transcend", 10, "Attacks become ranged for 10 seconds", "Blade of Transcended will, cleave the end of skies!", 500, 0));
	}

	void ConstructWeaponList(){
		weaponlist = new List<Weapon>();
		weaponlist.Add(new Weapon("weapon0", 10, "desc0", 1, true));
		weaponlist.Add(new Weapon("weapon1", 20, "desc1", 50, false));
		weaponlist.Add (new Weapon ("weapon2", 30, "desc2", 100, false));
		weaponlist.Add (new Weapon ("weapon3", 40, "desc3", 500, false));
		weaponlist.Add (new Weapon ("weapon4", 50, "desc3", 1000, false));
		weaponlist.Add (new Weapon ("weapon5", 100, "desc3", 10000, false));
	}

	void UpdateCoinText(){
		coin = PlayerPrefs.GetInt ("Coin");
		coinText.text = coin.ToString ();
	}

	public void GoToStageMenu(){
		mainMenu.SetActive (false);
		stageMenu.SetActive (true);
	}

	public void BackToMainMenu(){
		mainMenu.SetActive (true);
		stageMenu.SetActive (false);
	}

	public void GoToShop(){
		//mainMenu.SetActive (false);
		buttonList.SetActive (false);
		shop.SetActive (true);
		blackBox.SetActive (true);
		WeaponShop ();
	}

	public void WeaponShop(){
		spellShop.interactable = true;
		potionShop.interactable = true;
		weaponShop.interactable = false;
		weaponShopList.SetActive (true);
		potionShopList.SetActive (false);
		spellShopList.SetActive (false);
	}
		
	public void PotionShop(){
		spellShop.interactable = true;
		potionShop.interactable = false;
		weaponShop.interactable = true;
		weaponShopList.SetActive (false);
		potionShopList.SetActive (true);
		spellShopList.SetActive (false);
	}

	public void SpellShop(){
		spellShop.interactable = false;
		potionShop.interactable = true;
		weaponShop.interactable = true;
		weaponShopList.SetActive (false);
		potionShopList.SetActive (false);
		spellShopList.SetActive (true);
	}

	public void GoToInventory(){
		//mainMenu.SetActive (false);
		buttonList.SetActive (false);
		inventory.SetActive (true);
		blackBox.SetActive (true);
		WeaponInventory ();
	}

	public void WeaponInventory(){
		spellInventory.interactable = true;
		potionInventory.interactable = true;
		weaponInventory.interactable = false;
		weaponInventoryList.SetActive (true);
		potionInventoryList.SetActive (false);
		spellInventoryList.SetActive (false);
	}

	public void PotionInventory(){
		spellInventory.interactable = true;
		potionInventory.interactable = false;
		weaponInventory.interactable = true;
		weaponInventoryList.SetActive (false);
		potionInventoryList.SetActive (true);
		spellInventoryList.SetActive (false);
	}

	public void SpellInventory(){
		spellInventory.interactable = false;
		potionInventory.interactable = true;
		weaponInventory.interactable = true;
		weaponInventoryList.SetActive (false);
		potionInventoryList.SetActive (false);
		spellInventoryList.SetActive (true);
	}

	IEnumerator Touchy(GameObject skip){
		while (!Input.GetMouseButtonDown(0))
		{
			yield return null;
		}
		skip.SetActive (false);
	}

	public void CloseShop(){
		shop.SetActive (false);
		blackBox.SetActive (false);
		buttonList.SetActive (true);
	}

	public void CloseInventory(){
		inventory.SetActive (false);
		blackBox.SetActive (false);
		buttonList.SetActive (true);
	}

	/*public void testPress(int index){
		if (shopType == 0) {
			Debug.Log (weapon [index]);
		}
	}*/

	public void CheckBoughtWeapon(){
		for(int i = 0; i < weaponBuy.Length; i++){
			bool check = weaponlist[i].sold;
			if (check == true) {
				weaponBuy [i].interactable = false;
				weaponBuy[i].GetComponentInChildren<Text>().text="Sold";
			}
		}
	}

	public void ShowWeaponPrice(){
		for(int i = 0; i < weaponBuy.Length; i++){
			int price = weaponlist [i].price;
			weaponBuy[i].GetComponentInChildren<Text>().text = price.ToString();
		}
	}

	public void BuyWeapon(int index){
		int price = weaponlist [index].price;
		if (coin >= price) {
			PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-price);
			weaponlist [index].sold = true;
			UpdateCoinText ();
			CheckBoughtWeapon ();
			ResetEquip (weaponEquip);
			if (blackBoxDesc.activeSelf)
				OpenWeaponShopDescription (index);
		}
	}

	public void ResetEquip(Button[] buttons){
		foreach (Button button in buttons) {
			button.interactable = true;
			button.GetComponentInChildren<Text>().text="Equip";
		}
		for(int i = 0; i < weaponEquip.Length; i++){
			bool check = weaponlist[i].sold;
			if (check == false) {
				weaponEquip [i].interactable = false;
				weaponEquip [i].GetComponent<Image>().sprite = shopButton;
				weaponEquip [i].GetComponentInChildren<Text> ().text = "Buy in shop";
			} else {
				weaponEquip [i].GetComponent<Image>().sprite = inventoryButton;
			}
		}
		CheckEquip ();
	}

	public void EquipWeapon(int index){
		PlayerPrefs.SetInt ("EquipWeapon", index);
		ResetEquip (weaponEquip);
	}

	public void CheckEquip(){
		int index = PlayerPrefs.GetInt ("EquipWeapon");
		weaponEquip[index].interactable = false;
		weaponEquip[index].GetComponentInChildren<Text>().text="Equipped";
		Debug.Log ("Equip Weapon : " + weaponlist[PlayerPrefs.GetInt ("EquipWeapon")] .weaponName);
	}

	//type 0 = shop, type 1 = inven
	public void OpenWeaponShopDescription(int index){
		blackBoxDesc.SetActive (true);

		weaponShopDesc.SetActive (true);
		potionShopDesc.SetActive (false);
		spellShopDesc.SetActive (false);

		shopDescWeaponName.text = weaponlist [index].weaponName.ToString ();
		shopDescWeaponDamage.text = weaponlist [index].weaponDamage.ToString ();
		shopDescWeaponPrice.text = weaponlist [index].price.ToString ();
		shopDescWeaponDesc.text = weaponlist [index].weaponDescription.ToString ();

		if (weaponlist [index].sold) {
			descWeaponBuy.GetComponentInChildren<Text> ().text = "Sold";
			descWeaponBuy.interactable = false;	
		} else {
			descWeaponBuy.interactable = true;
			descWeaponBuy.GetComponentInChildren<Text> ().text = "Buy";
			descWeaponBuy.onClick.AddListener (delegate {
				BuyWeapon (index);
			});
		}
		
	}

	public void CloseDescBox (){
		blackBoxDesc.SetActive (false);
	}

	public void AddSpellBuyNumber(int index){
		Debug.Log ("Add");
		int currentNum = int.Parse (spellShopNumber[index].text);
		currentNum += 1;
		if (currentNum >= 99)
			currentNum = 99;
		spellShopNumber [index].text = currentNum.ToString ();
		int countPrice = currentNum * spelllist [index].price;
		Debug.Log (countPrice);
		spellBuy[index].GetComponentInChildren<Text> ().text = countPrice.ToString ();
	}


	public void ReduceSpellBuyNumber(int index){
		Debug.Log ("Reduce");
		int currentNum = int.Parse (spellShopNumber[index].text);
		currentNum -= 1;
		if (currentNum <= 1)
			currentNum = 1;
		spellShopNumber [index].text = currentNum.ToString ();
		int countPrice = currentNum * spelllist [index].price;
		spellBuy[index].GetComponentInChildren<Text> ().text = countPrice.ToString ();
	}

	public void BuySpell(int index){
		int currentNum = int.Parse (spellShopNumber[index].text);
		int totalPrice = currentNum * spelllist [index].price;
		if (coin >= totalPrice) {
			spelllist [index].held += currentNum;
			PlayerPrefs.SetInt ("Coin", PlayerPrefs.GetInt ("Coin") - totalPrice);
			UpdateCoinText ();
			spellShopNumber [index].text = "1";
			Debug.Log ("Total : "+totalPrice);
			Debug.Log ("Held : " + spelllist [index].held);
			ResetSpellEquip (spellEquip);
		}

	}

	public void EquipSpell(int index){
		PlayerPrefs.SetInt ("EquipSpell", index);
		ResetSpellEquip (spellEquip);
	}

	public void ResetSpellEquip(Button[] buttons){
		foreach (Button button in buttons) {
			button.interactable = true;
			button.GetComponentInChildren<Text>().text="Equip";
		}
		for(int i = 0; i < spellEquip.Length; i++){
			int heldNum = spelllist[i].held;
			heldSpell [i].text = " Held : " + heldNum.ToString();
			if (heldNum <= 0) {
				spellEquip [i].interactable = false;
				spellEquip [i].GetComponent<Image>().sprite = shopButton;
				spellEquip [i].GetComponentInChildren<Text> ().text = "Buy in shop";
			} else {
				spellEquip [i].GetComponent<Image>().sprite = inventoryButton;
			}
		}
		CheckSpellEquip ();
	}

	public void CheckSpellEquip(){
		int index = PlayerPrefs.GetInt ("EquipSpell");
		spellEquip[index].interactable = false;
		spellEquip[index].GetComponentInChildren<Text>().text="Equipped";
		Debug.Log ("Equip spell : " + spelllist[PlayerPrefs.GetInt ("EquipSpell")] .spellName);
	}


	//POTION
	public void AddPotionBuyNumber(int index){
		Debug.Log ("Add");
		int currentNum = int.Parse (potionShopNumber[index].text);
		currentNum += 1;
		if (currentNum >= 99)
			currentNum = 99;
		potionShopNumber [index].text = currentNum.ToString ();
		int countPrice = currentNum * potionlist [index].price;
		Debug.Log (countPrice);
		potionBuy[index].GetComponentInChildren<Text> ().text = countPrice.ToString ();
	}


	public void ReducePotionBuyNumber(int index){
		Debug.Log ("Reduce");
		int currentNum = int.Parse (potionShopNumber[index].text);
		currentNum -= 1;
		if (currentNum <= 1)
			currentNum = 1;
		potionShopNumber [index].text = currentNum.ToString ();
		int countPrice = currentNum * potionlist [index].price;
		potionBuy[index].GetComponentInChildren<Text> ().text = countPrice.ToString ();
	}

	public void BuyPotion(int index){
		int currentNum = int.Parse (potionShopNumber[index].text);
		int totalPrice = currentNum * potionlist [index].price;
		if (coin >= totalPrice) {
			potionlist [index].held += currentNum;
			PlayerPrefs.SetInt ("Coin", PlayerPrefs.GetInt ("Coin") - totalPrice);
			UpdateCoinText ();
			potionShopNumber [index].text = "1";
			Debug.Log ("Total : "+totalPrice);
			Debug.Log ("Held : " + potionlist [index].held);
			ResetPotionEquip (potionEquip);
		}

	}

	public void EquipPotion(int index){
		PlayerPrefs.SetInt ("EquipPotion", index);
		ResetPotionEquip (potionEquip);
	}

	public void ResetPotionEquip(Button[] buttons){
		foreach (Button button in buttons) {
			button.interactable = true;
			button.GetComponentInChildren<Text>().text="Equip";
		}
		for(int i = 0; i < potionEquip.Length; i++){
			int heldNum = potionlist[i].held;
			heldPotion [i].text = " Held : " + heldNum.ToString();
			if (heldNum <= 0) {
				potionEquip [i].interactable = false;
				potionEquip [i].GetComponent<Image>().sprite = shopButton;
				potionEquip [i].GetComponentInChildren<Text> ().text = "Buy in shop";
			} else {
				potionEquip [i].GetComponent<Image>().sprite = inventoryButton;
			}
		}
		CheckPotionEquip ();
	}

	public void CheckPotionEquip(){
		int index = PlayerPrefs.GetInt ("EquipPotion");
		potionEquip[index].interactable = false;
		potionEquip[index].GetComponentInChildren<Text>().text="Equipped";
		Debug.Log ("Equip potion : " + potionlist[PlayerPrefs.GetInt ("EquipPotion")] .potionName);
	}

	/*public void testArea(){
		SceneManager.LoadScene (0);
	}*/
}
