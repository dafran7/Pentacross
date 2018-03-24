using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehaviour : MovementBehaviour{
	public int	hpVal,
				maxHpVal,
				meleeDamageVal,
				rangeDamageVal;

	public float speed;

	public Vector2 targetPos;

	public GameObject target;
	public float targetDistance;
	public SpriteRenderer sr;
	public BoxCollider2D hitBox;
	public Animator anim;
	public bool isDying;
	// Use this for initialization
	void Start (){
		maxHpVal = 1;
		hpVal = maxHpVal;
		GetHitBox ();
		GetSpriteRenderer();
		GetRigidBody2D ();
		GetAnimator ();
		GetTarget ("Player");
	}

	// Update is called once per frame
	void Update (){
		CheckTargetDistance ();
		if(!isDying)
			anim.Play ("Walk");
		if (targetDistance < 20&&!isDying&&transform.position.x>target.transform.position.x)
				gameObject.transform.position = Vector2.MoveTowards (gameObject.transform.position, target.transform.position, speed);
	}

	protected void GetTarget(string tagName){
		target = GameObject.FindGameObjectWithTag (tagName);
	}

	protected void CheckTargetDistance(){
		targetDistance = Vector2.Distance (target.transform.position, gameObject.transform.position);
	}

	protected void GetTargetPosition(){
		targetPos = new Vector2(target.transform.position.x,target.transform.position.y);
	}

	protected void Hit(int value){
		hpVal -= value;
		if (hpVal <= 0)
			Dead ();
	}

	protected void Dead(){
		StartCoroutine (Dying ());
	}

	protected IEnumerator Dying(){
		isDying = true;
		anim.Play ("Die");
		hitBox.enabled = false;
		GainScore ();
		yield return new WaitForSeconds (0.6f);
		Destroy (gameObject);
	}

	protected void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Weapon") {
			Dead ();
		}
	}
		
	protected void GetSpriteRenderer(){
		sr = gameObject.GetComponent<SpriteRenderer> ();
	}
	protected void GetHitBox(){
		hitBox = gameObject.GetComponent<BoxCollider2D> ();
	}
	protected void GetAnimator(){
		anim = gameObject.GetComponent<Animator> ();
	}

	void GainScore(){
		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 100);
	}
}

