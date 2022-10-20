using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image[] healthcounter;
    //10 health 10 imagenes (0,1,2,3,4,5,6,7,8,9)
    [SerializeField] int lifec;
    CharacterController2D playerfull;
    public void LoseLife(float damage)
    {
        lifec= (int)playerfull.life-1;
        Debug.Log("Life now " + (int)playerfull.life + "Lifec " + lifec);
        for (int i = 0; i < damage; i++)
        {
            healthcounter[lifec].enabled=false;
            lifec-=1;
            
        } 
        

    }
    
    
}
