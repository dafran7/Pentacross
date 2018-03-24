using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject 	startPoint,
						finishPoint,
						currentPoint;

	public Text scoreText;

	public Slider roadMap;
	void Start(){
		PlayerPrefs.SetInt ("Score", 0);
		StartCoroutine (AddScore ());
	}
	void Update(){
		CountRoadMapDistance ();
		CheckScore ();
	}

	void CountRoadMapDistance(){
		float totalDistance = finishPoint.transform.position.x - startPoint.transform.position.x;
		float currentDistance = currentPoint.transform.position.x - startPoint.transform.position.x;
		float slideValue = (currentDistance / totalDistance) * 100;
		roadMap.value = slideValue;
	}

	void CheckScore(){
		int score = PlayerPrefs.GetInt ("Score");
		scoreText.text = "Score : "+score.ToString ();
	}

	IEnumerator AddScore(){
		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 1);
		yield return new WaitForSeconds (1.5f);
		StartCoroutine (AddScore());
	}
}
