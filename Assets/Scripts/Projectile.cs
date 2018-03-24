using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public bool wait = true,
				isShooting = false;

	public float speed;
	public Vector2 targetPos, angle;
	Rigidbody2D rb2d;
	// Use this for initialization
	void Awake () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
			
	}
	public void Shoot(float spd, Vector2 position){
		speed = spd;
		targetPos = new Vector2 (position.x, position.y);
		angle = targetPos - new Vector2(transform.position.x,transform.position.y);
		rb2d.AddForce (angle * speed);
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Platform")
			Destroy (gameObject);
	}
}
