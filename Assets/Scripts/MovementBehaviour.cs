using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour {
	private float	moveSpeed,
					jumpPower,
					downSpeed;

	public Rigidbody2D rb2d;

	protected void GetRigidBody2D () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}


	protected void SetMovementSpeed(float value){
		moveSpeed = value;
	}

	protected void SetDownSpeed(float value){
		downSpeed = value;
	}

	protected void SetJumpingPower(float value){
		jumpPower = value;
	}

	protected float GetMovementSpeed(){
		return moveSpeed;
	}
		
	protected float GetJumpingPower(){
		return jumpPower;
	}

	protected void MoveRight(){
		Vector2 movement = new Vector2 (moveSpeed, rb2d.velocity.y);
		rb2d.velocity = movement;
		Debug.Log ("MovingRight");
	}
	protected void MoveLeft(){
		Vector2 movement = new Vector2 (-moveSpeed, rb2d.velocity.y);
		rb2d.velocity = movement;
	}
	protected void Jump(){
		Vector2 jump = new Vector2 (rb2d.velocity.x, jumpPower);
		rb2d.AddForce (jump);
		Debug.Log ("Jumping");
	}
	protected void MoveDown(){
		Vector2 movement = new Vector2 (rb2d.velocity.x, -downSpeed);
		rb2d.velocity = movement;

	}
}
