using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
	[SerializeField] float moveSpeed = 2f;
	
    // Start is called before the first frame update
    void Start()
    {
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
        GameObject player = GameObject.Find("Player");
		Vector2 direction = (player.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2 (direction.x, direction.y);
    }
	
		void OnTriggerEnter2D(Collider2D collider)
	{
		
		if (collider.gameObject.tag == "Player" &&  collider.gameObject.GetComponent<CharacterController2D>().life > 0 )
		{
			collider.gameObject.GetComponent<CharacterController2D>().ApplyDamage(2f,transform.position);
			Destroy (gameObject);
		}
		else if (collider.gameObject.tag == "Wall"){
			Destroy (gameObject);
		}
	}
}
