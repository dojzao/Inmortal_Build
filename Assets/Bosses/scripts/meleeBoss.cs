using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeBoss : MonoBehaviour
{
	[SerializeField] float attackDistance = 0.5f;
	[SerializeField] float attackRate = 2f;
	[SerializeField] Transform player;
	
	private float distance;
	private bool cooling;
	private float nextattack;
	
	[Header("Animacion")]
	private Animator animador;
	
	private void Awake() {
        animador = GetComponent<Animator>();
        nextattack = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
		distance = Vector2.Distance(transform.position, player.transform.position);
		action();
    }
	
	void action() {
		
		if (attackDistance >= distance && cooling == false) {
            attack();
        }

        if (cooling) {
            cooldown();
        }
	}
	
	void attack () {
		Debug.Log("Atacking");
		animador.SetTrigger("atacando");
		cooling = true;
	}
	
	void cooldown () {
		if (Time.time > nextattack && cooling) {
			cooling = false;
			nextattack = Time.time + attackRate;
		}
	}
}














