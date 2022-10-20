using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float life = 4;
	
	private Rigidbody2D rb;
	private Animator animador;
	public bool isInvincible = false;
	//private bool isHitted = false;

	void Awake () {
		animador = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (life <= 0) {
			animador.SetBool("dead", true);
			//StartCoroutine(DestroyEnemy());
		}
	}

	public void ApplyDamage(float damage) {
		if (!isInvincible) 
		{
			float direction = damage / Mathf.Abs(damage);
			damage = Mathf.Abs(damage);
			animador.SetTrigger("golpeado");
			life -= damage;
			rb.velocity = Vector2.zero;
			rb.AddForce(new Vector2(direction * 500f, 100f));
			StartCoroutine(HitTime()); 
		}
	}

	IEnumerator HitTime()
	{
		//isHitted = true;
		isInvincible = true;
		yield return new WaitForSeconds(0.1f);
		//isHitted = false;
		isInvincible = false;
		rb.velocity = Vector2.zero;
	}

	/*IEnumerator DestroyEnemy()
	{
		ia.speed = 0f;
		CapsuleCollider2D capsule = GetComponent<CapsuleCollider2D>();
		capsule.size = new Vector2(0.2f, 0.2f);
		capsule.offset = new Vector2(0f, -0.8f);
		capsule.direction = CapsuleDirection2D.Horizontal;
		yield return new WaitForSeconds(0.25f);
		rb.velocity = new Vector2(0, rb.velocity.y);
		yield return new WaitForSeconds(5f);
		Destroy(gameObject);
	}*/
}
