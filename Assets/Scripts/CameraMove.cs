using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraMove : MovementBehaviour
{
	public int 	stageIteration=0,
				maxIteration;
	public GameObject[] platformCor;
	GameObject player;
	public float yOffset;
	public Vector3 distance;
	public bool end=false;
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

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Background") {
			if (!end) {
				distance.x = col.gameObject.GetComponent<Renderer> ().bounds.size.x;
				//int rand = Random.Range dari 0 sampe angka sebelum portal
				//index 0 dibawah ganti jadi rand
				Instantiate (platformCor [0], col.gameObject.transform.position + distance, Quaternion.identity);
				stageIteration += 1;
				if (stageIteration == maxIteration)
					end = true;
			} else {
				//Instantiate (platformCor [/*index stage final yg ada portal*/], col.gameObject.transform.position + distance, Quaternion.identity);
			}
		}
	}
}

