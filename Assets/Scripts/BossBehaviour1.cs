using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour1 : BossSystem {

    public bool isAttacking = false,
                isDelayed = false;
    public GameObject projectile;
    public Vector2 shootPos;
    public float    attackPower,
                    angle,
                    attackDelay,
                    rand;
    public bool startboss = true;
    // Use this for initialization
    void Start () {
        maxHpVal = 250;
        hpVal = maxHpVal;
        GetHitBox();
        GetSpriteRenderer();
        GetRigidBody2D();
        GetAnimator();
        GetTarget("Player");
    }
	
	// Update is called once per frame
	void Update () {
        CheckTargetDistance();
        if (startboss && (targetDistance < 26))
        {
            anim.Play("Idle");
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 8.15f), 10);
            startboss = false;
        }
        else if (!startboss)
        {
            MoveRight();
            if (!isDying && !isAttacking)
                anim.Play("Idle");
            if (!isDying && !isDelayed)
            {
                angle = Mathf.Asin((transform.position.y - target.transform.position.y) / targetDistance) * Mathf.Rad2Deg;
                if (hpVal < 0.5 * maxHpVal)
                {
                    rand = Random.Range(0.0f, 1.0f);
                    if (rand < 0.75f)
                        anim.Play("Attack3");
                    else StartCoroutine(Attacking());
                }
                else StartCoroutine(Attacking());
            }
        }
    }

    void MoveRight()
    {
        Vector2 movement = new Vector2(target.GetComponent<PlayerBehaviour>().standarMoveSpeed, rb2d.velocity.y);
        rb2d.velocity = movement;
    }

    void Attack()
    {
        isAttacking = true;
        isDelayed = true;
        GetTargetPosition();
        shootPos = new Vector2(targetPos.x, targetPos.y);
        anim.Play("Attack2");
    }

    IEnumerator Attacking()
    {
        Attack();
        yield return new WaitForSeconds(0.1f);
        GameObject x = Instantiate(projectile, new Vector2(gameObject.transform.position.x-4.08f, gameObject.transform.position.y-1.4f), Quaternion.Euler(0, 0, angle));
        x.transform.localScale += new Vector3(4, 4, 0);
        x.GetComponent<Projectile>().Shoot(attackPower, shootPos);
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
        yield return new WaitForSeconds(attackDelay);
        isDelayed = false;
    }

    public GameObject[] fires;
    void Attack3()
    { 
        fires = GameObject.FindGameObjectsWithTag("fire");
        foreach (GameObject fire in fires){
            fire.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        StartCoroutine(StartAttack3());
    }

    IEnumerator StartAttack3()
    {
        foreach (GameObject fire in fires)
        {
            GetTargetPosition();
            shootPos = new Vector2(targetPos.x, targetPos.y);
            fire.GetComponent<Projectile>().Shoot(attackPower, shootPos);
            yield return new WaitForSeconds(0.8f);
        }
        isAttacking = false;
        yield return new WaitForSeconds(attackDelay);
        isDelayed = false;
    }
}
