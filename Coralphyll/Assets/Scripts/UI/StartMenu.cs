using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject starmenuPanel;
    public GameObject interactionPanel;
    public GameObject accessibilitypanel;
    public GameObject optionsPanel;
    public GameObject visionAidPanel;
    public GameObject audioOptionsPanel;




    public void PressStartButton(){
        SceneManager.LoadScene("Level1");

    }

    public void OpenOptionsButton(){
        openVisionAidPanel();
    }
    public void openVisionAidPanel(){
        interactionPanel.SetActive(true);
        visionAidPanel.SetActive(true);
        audioOptionsPanel.SetActive(false);
    }

    public void openAudioOptions(){
        interactionPanel.SetActive(true);
        visionAidPanel.SetActive(false);
        audioOptionsPanel.SetActive(true);
    }

}
