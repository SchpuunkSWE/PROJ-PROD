using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject starmenuPanel;
 //  public GameObject interactionPanel;
   // public GameObject accessibilitypanel;
    public GameObject optionsPanel;
   // public GameObject visionAidPanel;
   // public GameObject audioOptionsPanel;
    public bool voiceAssist;
   

    private bool optionsOpen;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void PressStartButton(){
        SceneManager.LoadScene("Level1");
    }
    public void OpenOptionsButton(){
        if(optionsOpen == false){
            optionsPanel.SetActive(true);
        openVisionAidPanel();
        optionsOpen = true;
        }else 
        {
            optionsPanel.SetActive(false);
            optionsOpen = false;

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

     public void activateVoiceAssist (bool vA){
        voiceAssist = true;

    }

}
