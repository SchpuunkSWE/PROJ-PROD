using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;

    public GameObject[] otherPanels;

    public GameObject optionsPanel;
    

    // Start is called before the first frame update
    void Start()
    {
        optionsPanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            if(GameisPaused)
            {
                Resume();
            } else
            {
                Pause();
            }

        }
    }
    

  public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsPanel.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }

    public void Save(){

    }
    public void Options(){
        optionsPanel.SetActive(true);
        pauseMenuUI.SetActive(false);


    }

    
}
