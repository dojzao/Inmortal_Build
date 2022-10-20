using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
	[SerializeField] int damage = 1;
	
	void OnCollisionEnter2D(Collision2D collisionData)
    {
		if (collisionData.collider.tag == "Player") {
			CharacterController2D player = collisionData.collider.GetComponent<CharacterController2D>();
			player.ApplyDamage(damage, collisionData.transform.position);
		}
    }

    private void OnTriggerStay2D(Collider2D collisionData)
    {
		if (collisionData.tag == "Player") {
			CharacterController2D player = collisionData.GetComponent<CharacterController2D>();
			player.ApplyDamage(damage, collisionData.transform.position);
		}
    }
}
