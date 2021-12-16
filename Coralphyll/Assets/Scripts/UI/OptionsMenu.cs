using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject OptionMenu;
    //lägg in enemy outline script
    //lägg in hint script
    //lägg in offscreen indicator
    //private NavigationArrow navigationArrow;

    public bool isStartMenu;
    public GameObject exitButton;
    // public TabGroup tabGroup;
    //public TabButton startButton;
    // Start is called before the first frame update
    public GameObject enemyOutlineToggle;
    public GameObject hintToggle;
    public GameObject indicatorToggle;
    public GameObject navArrowToggle;
    public GameObject audioIndicator;


    void Start()
    {
        //tabGroup.OnTabSelected(startButton);
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        setToggles();
        //navigationArrow = GetComponent<NavigationArrow>();


    }
    void Awake()
    {
        //tabGroup.OnTabSelected(startButton);
        if (isStartMenu)
        {
            exitButton.SetActive(false);
        }

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

    public void EnemyOutline(bool enemyOutline)
    {
        PlayerPrefs.SetInt("EnemyOutline", BoolToInt(enemyOutline));

    }

    public void HintSystem(bool hintSystem)
    {
        PlayerPrefs.SetInt("HintSystem", BoolToInt(hintSystem));
    }
    public void OffScreenIndicator(bool offScreen)
    {
        PlayerPrefs.SetInt("OffscreenIndicator", BoolToInt(offScreen));
    }

    public void NavigationArrow(bool navArrow)
    {
        PlayerPrefs.SetInt("NavigationArrow", BoolToInt(navArrow));
        GameObject navigationArrow = GameObject.FindGameObjectWithTag("Arrow"); //Find gameObject with tag Arrow. In this case this should be ArrowParent. 
        if (navArrowToggle.GetComponent<Toggle>().isOn) //Check if the toggle is toggled.
        {
            navigationArrow.transform.GetChild(0).gameObject.SetActive(true); //Activate the child object to the object we found before. In this case it should be the Arrow.
        }
        else
        {
            navigationArrow.transform.GetChild(0).gameObject.SetActive(false); //Inactivate the child object. 
        }      
    }
    public void ToggleAudioIndicator(bool audioInd)
    {
        PlayerPrefs.SetInt("AudioIndicator", BoolToInt(audioInd));
        if (audioIndicator.GetComponent<Toggle>().isOn) //Check if the toggle is toggled.
        {
            GetComponent<Audio_Accessibility>().ToggleAudioAccessibilityOn();
        }
        else
        {
            GetComponent<Audio_Accessibility>().ToggleAudioAccessibilityOff();
        }
        
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

    private int BoolToInt(bool boolean)
    {
        if (boolean)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    private bool IntToBool(int i)
    {
        if (i == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void setToggles()
    {
        enemyOutlineToggle.GetComponent<Toggle>().isOn = IntToBool(PlayerPrefs.GetInt("EnemyOutline"));
        hintToggle.GetComponent<Toggle>().isOn = IntToBool(PlayerPrefs.GetInt("HintSystem"));
        indicatorToggle.GetComponent<Toggle>().isOn = IntToBool(PlayerPrefs.GetInt("OffscreenIndicator"));
        navArrowToggle.GetComponent<Toggle>().isOn = IntToBool(PlayerPrefs.GetInt("NavigationArrow"));
        audioIndicator.GetComponent<Toggle>().isOn = IntToBool(PlayerPrefs.GetInt("AudioIndicator"));
    }

    public void ToggleTerrainNavIndicator()
    {
        GameObject o = GameObject.Find("BonkController");
        o.GetComponent<BonkController>().switchActiveIndicator();
    }
    public void ToggleTerrainNavSound()
    {
        GameObject o = GameObject.Find("BonkController");
        o.GetComponent<BonkController>().switchActiveSound();
    }
}
