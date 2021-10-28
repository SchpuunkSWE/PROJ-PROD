using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject starmenuPanel;
    public GameObject OptionsPanel;
    public GameObject accessibilitypanel;

    public void PressStartButton(){
        SceneManager.LoadScene("Level1");

    }

}
