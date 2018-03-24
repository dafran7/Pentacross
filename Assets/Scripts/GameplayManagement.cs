using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManagement : MonoBehaviour {

	public GameObject 	boss,
						player;

	public SpriteRenderer 	sr_player,
							sr_boss;
	public Animator anim_player,
					anim_boss;
	// Use this for initialization
	void Start () {
		sr_player = player.GetComponent<SpriteRenderer> ();
		anim_player = player.GetComponent<Animator> ();
		sr_boss = boss.GetComponent<SpriteRenderer> ();
		anim_boss = boss.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (PlayerIdle ());
		//StartCoroutine (BossGlide ());
	}

	IEnumerator PlayerIdle(){
		anim_player.Play ("Idle");
		yield return new WaitForSeconds (5f);

		float x = 0;
		anim_boss.Play ("Glide");
		yield return new WaitForSeconds (0.5f);
		for(float i=boss.transform.position.y;i>=1.75f;){
			x -= 0.0425f;
			i = i - (x * x);
			boss.transform.position = new Vector2 (boss.transform.position.x+x, i);
		}
		yield return new WaitForSeconds (5f);
	}

	IEnumerator BossGlide(){
		float x = 0;
		anim_boss.Play ("Glide");
		yield return new WaitForSeconds (0.5f);
		for(float i=boss.transform.position.y;i>=1.75f;){
			x -= 0.0425f;
			i = i - (x * x);
			boss.transform.position = new Vector2 (boss.transform.position.x+x, i);
		}
		yield return new WaitForSeconds (5f);
	}

}
