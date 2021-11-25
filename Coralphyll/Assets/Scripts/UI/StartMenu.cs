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

    private bool optionsOpen;


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

}
