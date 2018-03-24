using UnityEngine;
using System.Collections;

public class BossSystem : MonoBehaviour{

    public int  hpVal,
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
    public string BossName;
    public Rigidbody2D rb2d;

    // Declare Functions
    protected void GetTarget(string tagName)
    {
        target = GameObject.FindGameObjectWithTag(tagName);
    }

    protected void CheckTargetDistance()
    {
        targetDistance = Vector2.Distance(target.transform.position, gameObject.transform.position);
    }

    protected void GetTargetPosition()
    {
        targetPos = new Vector2(target.transform.position.x, target.transform.position.y);
    }

    protected void Hit(int value)
    {
        hpVal -= value;
        if (hpVal <= 0)
            Dead();
    }

    protected void Dead()
    {
        StartCoroutine(Dying());
    }

    protected IEnumerator Dying()
    {
        isDying = true;
        anim.Play("Die");
        hitBox.enabled = false;
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Weapon")
        {
			anim.Play ("Idle");
			gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 8.15f), 3);
        }
    }

    protected void GetSpriteRenderer()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    protected void GetHitBox()
    {
        hitBox = gameObject.GetComponent<BoxCollider2D>();
    }
    protected void GetAnimator()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    protected void GetRigidBody2D()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    
}
