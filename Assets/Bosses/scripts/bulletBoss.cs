using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBoss : MonoBehaviour
{
	[SerializeField] float moveSpeed = 2f;
	[SerializeField] public float damage = 2f;
	public EnemyBoss bulletdamage;
    // Start is called before the first frame update
    void Start()
    {
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
        GameObject player = GameObject.Find("Player");
		Vector2 direction = (player.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2 (direction.x, direction.y);
		GameObject boss = GameObject.Find("Boss");
		bulletdamage=boss.gameObject.GetComponent<EnemyBoss>(); 

    }
	
		void OnTriggerEnter2D(Collider2D collider)
	{
		
		if (collider.gameObject.tag == "Player" &&  collider.gameObject.GetComponent<CharacterController2D>().life > 0 )
		{
			Debug.Log("bullet hit");
			collider.gameObject.GetComponent<CharacterController2D>().ApplyDamage(bulletdamage.damage,transform.position);
			Destroy (gameObject);
		}
		else if (collider.gameObject.tag == "Wall"){
			Destroy (gameObject);
		}
        

		
	}
}
