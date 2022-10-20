using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
	[SerializeField] int damage = 1;
	
	void OnCollisionEnter2D(Collision2D collisionData)
    {
		if (collisionData.collider.tag == "Enemy") {
			Enemy enemy = collisionData.collider.GetComponent<Enemy>();
			enemy.ApplyDamage(damage);
		}
    }

    private void OnTriggerStay2D(Collider2D collisionData)
    {
		if (collisionData.tag == "Enemy") {
			Enemy enemy = collisionData.GetComponent<Enemy>();
			enemy.ApplyDamage(damage);
		}
    }
}
