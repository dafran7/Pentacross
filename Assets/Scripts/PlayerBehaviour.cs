using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MovementBehaviour {
	public int	hpVal,
				maxHpVal,
				meleeDamageVal,
				rangeDamageVal,
				chargeVal,
				jumpingPower,
				areaLimitCheck = 0,
				standarMoveSpeed,
				slowMoveSpeed,
				fastMoveSpeed,
				currentSpeed,
				dropSpeed;

	public Vector2 	curVelocity,
					slideOffset,
					slideSize,
					standarOffset,
					standarSize;

	public bool	isJumping 	= false,
				isAttacking	= false,
				isSliding 	= false,
				slide = false,
				moveFast,
				moveSlow;

	public BoxCollider2D	hitBox,
							slideHitBox,
							attackBox,
							leftLimit,
							rightLimit;

	public Animator anim;

	public PotionSpellCast psCast;

	// Use this for initialization
	void Start () {
		psCast = gameObject.GetComponent<PotionSpellCast> ();
		hitBox = gameObject.GetComponent<BoxCollider2D> ();
		standarOffset = new Vector2 (0f, 0.16f);
		standarSize = new Vector2 (0.73f, 1.59f);
		slideOffset = new Vector2 (-0.15f, -0.04f);
		slideSize = new Vector2 (1.52f, 0.91f);
		hitBox.offset = standarOffset;
		hitBox.size = standarSize;
		maxHpVal = 50;
		hpVal = maxHpVal;
		GetAnimator ();
		GetRigidBody2D ();
		//rb2d.gravityScale = 0;
		SetJumpingPower(jumpingPower);
		SpeedCheck(standarMoveSpeed);
		anim.Play ("Idle");

	}
	
	// Update is called once per frame
	void Update () {
		if (psCast.immortal)
			Debug.Log ("IMMORTALITY!");
		if (psCast.might)
			Debug.Log ("MIGHT!");
		if (psCast.transcend)
			Debug.Log ("TRANSCENDED BLADE");
		

		MoveRight ();
		curVelocity = rb2d.velocity;
	
		if (Input.GetKeyDown (KeyCode.Z)) {
			if (!isSliding && !isAttacking) {
					isAttacking = true;
					MeleeAttack ();
			}
		} else if (curVelocity.y < 0 && !isAttacking) {
				anim.Play ("Fall");
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			Jumping ();
			//} else if (!slide) {
			//		StopSlide ();
		} else if (slide && !isJumping) {
				Slide ();
		} else if (slide && isJumping) {
				SetFallSpeed (dropSpeed);
		} else if (moveFast) {
			if (!isJumping && !isAttacking)
				anim.Play ("Run");
			SpeedCheck (fastMoveSpeed);
		} else if (moveSlow) {
			if (!isJumping && !isAttacking)
				anim.Play ("Run");
			SpeedCheck (slowMoveSpeed);
		} else {
			if (!isJumping && !isAttacking)
				anim.Play ("Run");
			SpeedCheck (standarMoveSpeed);
		}

	}

	public void PressSlide(){
		slide = true;
	}

	public void ReleaseSlide(){
		slide = false;
		StopSlide ();
	}

	public void PressMoveF(){
		moveFast = true;
		moveSlow = false;
	}

	public void PressMoveS(){
		moveFast = false;
		moveSlow = true;
	}

	public void ReleaseMove(){
		moveFast = false;
		moveSlow = false;
	}

	void GetAnimator(){
		anim = gameObject.GetComponent<Animator> ();
	}

	void Jumping(){
		if (!isJumping) {
			SpeedCheck (currentSpeed);
			gameObject.GetComponent<Animator> ().Play ("Jump");
			isJumping = true;
			Jump ();
		}
	}

	void SetFallSpeed(int speed){
		SetDownSpeed (speed);
		MoveDown ();
		anim.Play ("Fall");
	}

	void SpeedCheck(int speed){
		if (areaLimitCheck == -1 && speed == slowMoveSpeed){
			SetMovementSpeed (standarMoveSpeed);
			currentSpeed = standarMoveSpeed;
		}else if (areaLimitCheck == 1 && speed == fastMoveSpeed){
			SetMovementSpeed (standarMoveSpeed);
			currentSpeed = standarMoveSpeed;
		}else{
			SetMovementSpeed (speed);
			currentSpeed = speed;
		}
	}
	void MeleeAttack(){
		StartCoroutine (MAttack());
	}

	void RangeAttack(){
	
	}

	public void Slide(){
		SpeedCheck (currentSpeed);
		isSliding = true;
		hitBox.size = slideSize;
		hitBox.offset = slideOffset;
		gameObject.GetComponent<Animator> ().Play ("Slide");
	}
	public void StopSlide(){
		hitBox.size = standarSize;
		hitBox.offset = standarOffset;
		isSliding = false;
	}
		
	void Hit(int value){
		hpVal -= value;
		if (hpVal <= 0)
			Dead ();
	}

	void Dead(){
		gameObject.GetComponent<Animator> ().Play ("Idle");
		Destroy (gameObject);
	}

	void RecoverHP(int value){
		hpVal += value;
		if (hpVal > maxHpVal)
			hpVal = maxHpVal;
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Platform") {
			isJumping = false;
		}
	}
	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "Platform") {
			isSliding = false;
		}

	}
	void OnTriggerEnter2D(Collider2D col){
		if (col == leftLimit)
			areaLimitCheck = -1;
		if (col == rightLimit)
			areaLimitCheck = 1;
	}
	void OnTriggerExit2D(Collider2D col){
		if (col == leftLimit || col == rightLimit)
			areaLimitCheck = 0;
	}

	IEnumerator MAttack(){
		attackBox.enabled = true;
		if (curVelocity.y != 0) {
			gameObject.GetComponent<Animator> ().Play ("Airattack");
		} else {
			gameObject.GetComponent<Animator> ().Play ("Attack");
		}
		yield return new WaitForSeconds (.5f);
		attackBox.enabled = false;
		isAttacking = false;
	}
}
