using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLevel1_PlayerControlsUI : MonoBehaviour
{
    public static bool GameIsPaused = false;
    //public GameObject hintSystemCanvas;
    public GameObject level1;

    //PlayerControls
    public GameObject helloandwelcome;
    public GameObject pcControls;
    public GameObject xboxcontrols;
    public GameObject letstryit;


    //The Trigger
    public GameObject level1trigger;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            // un-disable:ar level 1 gameobjektet
            level1.SetActive(true);
            helloandwelcome.SetActive(true);
            Pause();
        }

    }

    //Buttonhappenings

    public void NextSlide()
    {
        helloandwelcome.SetActive(false);
        pcControls.SetActive(true);
    }
    public void NextSlide2()
    {
        pcControls.SetActive(false);
        xboxcontrols.SetActive(true);
    }

    public void NextSlide3()
    {
        xboxcontrols.SetActive(false);
        letstryit.SetActive(true);
    }

    public void ExitFirst()
    {
        level1.SetActive(false);
        level1trigger.SetActive(false);
        Resume();
    }

    // Start is called before the first frame update
 /*   void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
 */

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
