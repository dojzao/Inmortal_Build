using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelEndMessage : MonoBehaviour
{
   public GameObject finishedText;

    void OnTriggerEnter2D(Collider2D attackInit)
	{
        
        
         
		if (attackInit.gameObject.tag == "Player")
		{
			
            EndLevel();
		} 
		
	}
    
    public void EndLevel()
    {
        StartCoroutine(WaitToDead());
    }

    IEnumerator WaitToDead()
	{
        yield return new WaitForSeconds(2.0f);
        finishedText.SetActive(true);
		yield return new WaitForSeconds(10.0f);
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
	}
}
