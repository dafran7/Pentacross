using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour
{
	public int 	healthPoint,
				strengthPoint,
				defencePoint;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void SetHealthPoint(int value){
		PlayerPrefs.SetInt ("PlayerHP", value);
	}

	public void GetHealthPoint(){
		PlayerPrefs.GetInt ("PlayerHP");
	}

	public void SetStrengthPoint(int value){
		PlayerPrefs.SetInt ("PlayerSTR", value);
	}

	public void GetStrengthPoint(){
		PlayerPrefs.GetInt ("PlayerSTR");
	}

	public void SetDefencePoint(int value){
		PlayerPrefs.SetInt ("PlayerDEF", value);
	}

	public void GetDefencePoint(){
		PlayerPrefs.GetInt ("PlayerDEF");
	}

}

