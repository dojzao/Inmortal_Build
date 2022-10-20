using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
	[SerializeField] GameObject bullet;
	[SerializeField] float attackDistance = 0.5f;
	[SerializeField] float shootrate = 1f;
	
	float nextFire;
	private float distance;
	
	private Animator animador;
	private GameObject player;
	
	void Awake () {
		animador = GetComponentInParent<Animator>();
	}
	
	// Use this for initialization
	void Start () {
		nextFire = Time.time;
	}

    // Update is called once per frame
    void Update()
    {
		player = GameObject.Find("Player");
		distance = Vector2.Distance(transform.position, player.transform.position);
		
        if (distance <= attackDistance && Time.time > nextFire) {
			animador.SetTrigger("atacando");
			Instantiate (bullet, transform.position, Quaternion.identity);
			nextFire = Time.time + shootrate;
		}
    }
}
