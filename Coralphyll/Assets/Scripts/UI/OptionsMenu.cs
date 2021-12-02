using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject OptionMenu;
   // public TabGroup tabGroup;
    //public TabButton startButton;
    // Start is called before the first frame update
    void Start()
    {
      //tabGroup.OnTabSelected(startButton);

        
    }
    void Awake()
    {
        //tabGroup.OnTabSelected(startButton);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseOptionsMenu()
    {
        OptionMenu.SetActive(false);
        pauseMenu.SetActive(true);

    }

    public void startLevel1()
    {
        SceneManager.LoadScene(1);

    }
    public void startLevel2()
    {
        SceneManager.LoadScene(2);

    }
    public void startLevel3()
    {
        SceneManager.LoadScene(3);

    }
    public void startLevel4()
    {
        SceneManager.LoadScene(4);

    }
}
