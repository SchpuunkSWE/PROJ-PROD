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
    public GameObject howToPlayPanel;
    public GameObject savePanel;

    // Start is called before the first frame update
    void Start()
    {
        optionsPanel.SetActive(false);
        savePanel.SetActive(false);
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
        howToPlayPanel.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<Audio_Pause>().ResumeFunction();
        GameisPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        FindObjectOfType<Audio_Pause>().PauseFunction();
        GameisPaused = true;
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }

    public void Save(){
        savePanel.SetActive(true);
        pauseMenuUI.SetActive(false);


    }

    public void ExitSave()
    {
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void Options(){
        optionsPanel.SetActive(true);
        optionsPanel.GetComponent<OptionsMenu>().setToggles();
        pauseMenuUI.SetActive(false);


    }

    public void howtoplay(){
        howToPlayPanel.SetActive(true);
    }

    
}
