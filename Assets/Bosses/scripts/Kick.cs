using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyBoss eb;
    [SerializeField] float lifeboss;
    [SerializeField] float ataqueElegido;
    [SerializeField] bool cooling;
    [SerializeField] Transform Boss;

    
    private void Start()
    {
        GameObject go = GameObject.Find("Boss");
        eb=go.gameObject.GetComponent<EnemyBoss>();
        lifeboss=eb.lifeBoss;
        ataqueElegido=eb.ataqueElegido;
        cooling=eb.cooling;
		   
    }
   void OnTriggerEnter2D(Collider2D attackInit)
	{
        
        
         
		lifeboss=eb.lifeBoss;
        ataqueElegido=eb.ataqueElegido;
        cooling=eb.cooling;
		if (attackInit.gameObject.tag == "Player" && eb.lifeBoss > 0 && eb.ataqueNum == 1 && !eb.cooling)
		{
			attackInit.gameObject.GetComponent<CharacterController2D>().ApplyDamage(2f, transform.position);
            eb.cooling=true;
            eb.animador.SetBool("Ataque3Melee",false);	
            eb.StartCoroutine(eb.cooldown(1f));

            
		}else if(attackInit.gameObject.tag == "Player" && eb.lifeBoss > 0 && eb.ataqueNum == 2 && !eb.cooling)
		{
			attackInit.gameObject.GetComponent<CharacterController2D>().ApplyDamage(3f, transform.position);
			eb.cooling=true;
            eb.animador.SetBool("Ataque4Tackle",false);	
            eb.StartCoroutine(eb.cooldown(1.5f));

            
		} 
		
	}

    void OnTriggerStay2D(Collider2D attackInit)
	{
        
        
         
		lifeboss=eb.lifeBoss;
        ataqueElegido=eb.ataqueElegido;
        cooling=eb.cooling;
		if (attackInit.gameObject.tag == "Player" && eb.lifeBoss > 0 && eb.ataqueNum == 1 && !eb.cooling)
		{
			attackInit.gameObject.GetComponent<CharacterController2D>().ApplyDamage(2f, transform.position);
			eb.cooling=true;
            eb.animador.SetBool("Ataque3Melee",false);	
            eb.StartCoroutine(eb.cooldown(1f));

		}else if(attackInit.gameObject.tag == "Player" && eb.lifeBoss > 0 && eb.ataqueNum == 2 && !eb.cooling)
		{
			attackInit.gameObject.GetComponent<CharacterController2D>().ApplyDamage(3f, transform.position);
			eb.cooling=true;
            eb.animador.SetBool("Ataque4Tackle",false);	
            eb.StartCoroutine(eb.cooldown(1.5f));
		} 
		
	}

    /*void OnTriggerExit2D(Collider2D attackFin)
	{
		
        lifeboss=eb.lifeBoss;
        ataqueElegido=eb.ataqueElegido;
        cooling=eb.cooling;
            
        if (attackFin.gameObject.tag == "Player" && eb.lifeBoss > 0 && eb.ataqueNum == 1 && eb.cooling)
		{
			eb.animador.SetBool("Ataque3Melee",false);
            eb.StartCoroutine(eb.cooldown());
            
        
		}if (attackFin.gameObject.tag == "Player" && eb.lifeBoss > 0 && eb.ataqueNum == 2 && eb.cooling)
		{
			eb.animador.SetBool("Ataque4Tackle",false);
		    eb.StartCoroutine(eb.cooldown());
        
		}
    

		
     	
		
		
		
		
	}*/


}
