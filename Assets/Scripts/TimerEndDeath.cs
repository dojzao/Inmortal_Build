using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class TimerEndDeath : MonoBehaviour
{
    public GameObject finishedText;

    public Timer timer;
    public void TimerStart()
    {
        finishedText.SetActive(false);
    }
    public void TimerEnd()
    {
        finishedText.SetActive(true);
        StartCoroutine(WaitToDead());
    }

    IEnumerator WaitToDead()
	{
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
	}
}
