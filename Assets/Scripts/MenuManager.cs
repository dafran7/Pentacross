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
						spellInventoryList;

	public Button	weaponShop,
					potionShop,
					spellShop,
					weaponInventory,
					potionInventory,
					spellInventory;

	public Button[] weaponBuy,
					weaponEquip;

	public  Sprite shopButton, inventoryButton;

	public Text coinText;

	public int coin;
	public int shopType=0;
	public string[] weapon={"Api","Air","Tanah"};

	public static List<Weapon> weaponlist;
	// Use this for initialization
	void Start () {
		StartCoroutine (Touchy (frontMenu));
		PlayerPrefs.SetInt ("Coin", 999999999);
		UpdateCoinText ();
		ConstructWeaponList ();
		ShowWeaponPrice ();
		CheckBoughtWeapon ();
		EquipWeapon (0);
	}
	
	// Update is called once per frame
	void Update () {
		
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

	public void testPress(int index){
		if (shopType == 0) {
			Debug.Log (weapon [index]);
		}
	}

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

	/*public void testArea(){
		SceneManager.LoadScene (0);
	}*/
}
