using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLevel2 : MonoBehaviour
{
    public static bool GameIsPaused = false;
    //public GameObject hintSystemCanvas;
    public GameObject level2;

    //the rest
    public GameObject explainEnemy;
    public GameObject explainSafezone;
    public GameObject explainDash;
    public GameObject explainCorals;
    public GameObject goodLuck;

    //The Trigger
    public GameObject level2trigger;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            // un-disable:ar level 2 gameobjektet
            level2.SetActive(true);
            StartSlide();
            Pause();
        }

    }

    //Buttonhappenings

    public void StartSlide()
    {
        explainEnemy.SetActive(true);
    }
    public void NextSlide()
    {
        explainEnemy.SetActive(false);
        explainSafezone.SetActive(true);
    }

    public void NextSlide2()
    {
        explainSafezone.SetActive(false);
        explainDash.SetActive(true);
    }

    public void NextSlide3()
    {
        explainDash.SetActive(false);
        explainCorals.SetActive(true);
    }

    public void NextSlide4()
    {
        explainCorals.SetActive(false);
        goodLuck.SetActive(true);
    }

    public void ExitFirst()
    {
        level2.SetActive(false);
        level2trigger.SetActive(false);
        Resume();
    }


    void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = true;
    }
}
