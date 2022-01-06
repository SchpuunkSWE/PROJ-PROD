using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject starmenuPanel;
    public GameObject howToPlayPanel;

    public GameObject optionsPanel;

   

    public GameObject loadPanel;
    public OptionsMenu OM;
    private bool loadOpen;

    private bool optionsOpen;
    private bool howtoplay;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        OM.voiceAssist = false;
    }
    public void PressStartButton()
    {
        SceneManager.LoadScene(7);
        AkSoundEngine.PostEvent("StopMainMenuMusic", GameObject.FindGameObjectWithTag("MainCamera"));
        Logger.LoggerInstance.CreateTextFile("#PlayTestSTARTED");
        Logger.LoggerInstance.CreateTextFile("Level 1: ");

    }
    public void OpenOptionsButton(){
        if(optionsOpen == false){
            optionsPanel.SetActive(true);
        openVisionAidPanel();
        optionsOpen = true;

        

        }
        else 
        {
            optionsPanel.SetActive(false);
            optionsOpen = false;

        }

        

    }

    public void openLoadManager()
    {
        if (loadOpen == false)
        {
            loadPanel.SetActive(true);
            loadOpen = true;
        }
        else
        {
            loadPanel.SetActive(false);
            loadOpen = false;

        }
    }


    public void openVisionAidPanel(){
     
    }

    public void openAudioOptions(){
    
    }
    public void exitGame()
    {
        Application.Quit();
    }

    public void openHowToPlay(){
        howToPlayPanel.SetActive(howtoplay!);
        howtoplay = !howtoplay;
        if(optionsOpen){
            OpenOptionsButton();
        }
    }

     

}
