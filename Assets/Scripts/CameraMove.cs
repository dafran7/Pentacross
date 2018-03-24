using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraMove : MovementBehaviour
{
	GameObject player;
	public float yOffset;
	// Use this for initialization
	void Start ()
	{
		GetRigidBody2D ();
		SetMovementSpeed (5);
		player = GameObject.FindGameObjectWithTag ("Player"); 
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameObject.transform.position = new Vector3(gameObject.transform.position.x, player.transform.position.y, -5);
		MoveRight ();
	}
}

