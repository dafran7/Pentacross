using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
	public GameObject BlackboxImage, GameOverWindow, PauseWindow;
	public bool paused = false;
	public Text scoreText;
	// Use this for initialization


	public void ResumeGame(){
		Time.timeScale = 1f;
		BlackboxImage.SetActive (false);
		PauseWindow.SetActive (false);
		paused = false;
	}

	public void PauseGame(){
		Time.timeScale = 0f;
		BlackboxImage.SetActive (true);
		PauseWindow.SetActive (true);
		paused = true;
	}

	public void GameOver(){
		Time.timeScale = 0f;
		BlackboxImage.SetActive (true);
		GameOverWindow.SetActive (true);
		paused = true;
		//scoreText.text = {Masukkin score disini}.ToString();
	}

	public void BackToStageMenu(){
		Time.timeScale = 1f;
		paused = false;
		//SceneManager.LoadScene ("Masukkkiiiin");
	}
}