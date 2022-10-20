using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] float lifelost = 1;
    [SerializeField] Vector2 damagdir= new Vector2(0f,0f);
	
    void OnCollisionEnter2D(Collision2D collisionData)
    {

        Collider2D objectCollided = collisionData.collider;
        CharacterController2D playerfull = objectCollided.GetComponent<CharacterController2D>();
        if(playerfull != null)
        {
            playerfull.ApplyDamage(lifelost,transform.position);
                   
        }
    }

    private void OnTriggerStay2D(Collider2D collisionData)
    {
        Collider2D objectCollided = collisionData;
        CharacterController2D playerfull = objectCollided.GetComponent<CharacterController2D>();
        if(playerfull != null)
        {
            playerfull.ApplyDamage(lifelost,damagdir);
                   
        }
    }
}
