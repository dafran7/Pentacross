using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyBehaviour : EnemyBehaviour {
	public bool isAttacking = false, 
				isDelayed = false;
	public GameObject projectile;
	public Vector2 shootPos;
	public float 	attackPower,
					attackDelay,
					angle;
	// Use this for initialization
	void Start () {
		maxHpVal = 1;
		hpVal = maxHpVal;
		GetHitBox ();
		GetSpriteRenderer();
		GetRigidBody2D ();
		GetAnimator ();
		GetTarget ("Player");
		rb2d.isKinematic = true;
	}

	// Update is called once per frame
	void Update () {
		CheckTargetDistance ();
		if (!isDying && !isAttacking)
			anim.Play("Idle");
		if (targetDistance < 10) {
			if (!isDying && !isDelayed) {
				angle = Mathf.Asin ((transform.position.y - target.transform.position.y) / targetDistance) * Mathf.Rad2Deg;
				StartCoroutine (Attacking ());
			}
		}else if (targetDistance < 20) {
			if(!isDying&&transform.position.x>target.transform.position.x)
				gameObject.transform.position = Vector2.MoveTowards (gameObject.transform.position, target.transform.position, speed); 
		}
	}

	void Attack(){
		isAttacking = true;
		isDelayed = true;
		GetTargetPosition ();
		shootPos = new Vector2 (targetPos.x, targetPos.y);
		anim.Play ("Attack");
	}

	IEnumerator Attacking(){
		Attack ();
		yield return new WaitForSeconds (0.1f);
		GameObject x = Instantiate (projectile, gameObject.transform.position, Quaternion.Euler(0,0,angle));
		x.GetComponent<Projectile> ().Shoot (attackPower, shootPos);
		yield return new WaitForSeconds (0.2f);
		isAttacking = false;
		yield return new WaitForSeconds (attackDelay);
		isDelayed = false;
	}

	protected void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Weapon") {
			
			StartCoroutine(Dying ());
		}
	}

	void GainScore(){
		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 100);
	}

	IEnumerator Dying(){
		isDying = true;
		rb2d.isKinematic = false;
		rb2d.gravityScale = 1;
		anim.Play ("Die");
		hitBox.enabled = false;
		GainScore();
		yield return new WaitForSeconds (0.6f);
		Destroy (gameObject);
	}
}
