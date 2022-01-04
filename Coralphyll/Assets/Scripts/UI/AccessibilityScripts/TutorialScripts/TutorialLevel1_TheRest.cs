using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLevel1_TheRest : MonoBehaviour
{
    public static bool GameIsPaused = false;
    //public GameObject hintSystemCanvas;
    public GameObject level1;

    //the rest
    public GameObject howtopickupfish;
    public GameObject leavefishatcoral;
    public GameObject progressbarexplained;
    public GameObject differentfish;
    public GameObject finishlevel;

    //The Trigger
    public GameObject level1trigger2;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            // un-disable:ar level 1 gameobjektet
            level1.SetActive(true);
            StartSlide();
            Pause();
        }

    }

    //Buttonhappenings

    public void StartSlide()
    {
        howtopickupfish.SetActive(true);
    }
    public void NextSlide()
    {
        howtopickupfish.SetActive(false);
        leavefishatcoral.SetActive(true);
    }

    public void NextSlide2()
    {
        leavefishatcoral.SetActive(false);
        progressbarexplained.SetActive(true);
    }

    public void NextSlide3()
    {
        progressbarexplained.SetActive(false);
        differentfish.SetActive(true);
    }

    public void NextSlide4()
    {
        differentfish.SetActive(false);
        finishlevel.SetActive(true);
    }

    public void ExitFirst()
    {
        level1.SetActive(false);
        level1trigger2.SetActive(false);
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
