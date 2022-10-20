using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBoss : MonoBehaviour
{
	[SerializeField] GameObject bullet;
	
	// Use this for initialization
	
    // Update is called once per frame
    public void shoot()
    {
        		Instantiate (bullet, transform.position, Quaternion.identity);
			
    }
	
	
}
