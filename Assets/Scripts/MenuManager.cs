using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
	public GameObject 	frontMenu,
						mainMenu,
						buttonList,
						shopWeapon,
						shopConsumable,
						stageMenu,
						inventory;
	// Use this for initialization
	void Start () {
		StartCoroutine (Touchy (frontMenu));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToStageMenu(){
		
	}

	public void GoToShop(){
		//mainMenu.SetActive (false);
		//buttonList.SetActive (false);
		//shopWeapon.SetActive (true);
	}

	public void SwitchShopTab(){
		//if shopweapon active; shopweapon active false, shopconsume true;
	}

	public void BacktoMainMenu(){
		//mainMenu.SetActive (true);
		//buttonList.SetActive (true);
	}

	IEnumerator Touchy(GameObject skip){
		while (!Input.GetMouseButtonDown(0))
		{
			yield return null;
		}
		skip.SetActive (false);
	}
}
