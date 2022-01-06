using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Audio_Cutscenes_Events : MonoBehaviour
{

    [SerializeField] private GameObject controller;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SharkBite()
    {
        AkSoundEngine.PostEvent("Cutscene_level2_SharkBite", controller);
    }

    public void LoadCredits()
    {
        Debug.Log("Credits maybe loaded");
        controller.GetComponent<SceneController>().LoadScene("Credits");
        Debug.Log("Credits loaded");
    }
    public void LoadMainMenu()
    {
       
        controller.GetComponent<SceneController>().LoadScene("StartMenu 1");
    }
    public void LoadLevel1()
    {
        controller.GetComponent<SceneController>().LoadScene("Level1");
    }
    public void LoadLevel2()
    {
        controller.GetComponent<SceneController>().LoadScene("Level2");
    }
    public void LoadLevel3()
    {
        controller.GetComponent<SceneController>().LoadScene("Level3");
    }
}
