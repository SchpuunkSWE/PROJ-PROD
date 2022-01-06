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
    public GameObject audioIndicatorToggle;

    public GameObject  navigationSoundToggle, navigationIndicatorToggle, textToSpeachToggle, enableOutlineToggle;
    public Slider mainAudioSlider, musicSlider, soundEffectsSlider, ambienceSlider;
    public Slider textSizeSlider, brightnessSlider, contrastSlider, outlineWidthSlider;


    public bool voiceAssist = false;
    public int checkNoOfEnemies;
    public OptionsData OD;
    public UI_SoundSystem soundSystem;




    void Start()
    {
        
        voiceAssist = false;
        //tabGroup.OnTabSelected(startButton);
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
       // activateVoiceAssist(voiceAssist);
        setToggles();
        setSliders();
        
        
        //navigationArrow = GetComponent<NavigationArrow>();
        
        

    }
    void Awake()
    {
        voiceAssist = false;
        //tabGroup.OnTabSelected(startButton);
        if (isStartMenu)
        {
            exitButton.SetActive(false);
        }

       // setToggles();
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
        OD.enemyOutline = enemyOutlineToggle.GetComponent<Toggle>().isOn;
        //PlayerPrefs.SetInt("EnemyOutline", BoolToInt(enemyOutline));
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        

        if (enemyOutlineToggle.GetComponent<Toggle>().isOn)
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].transform.GetChild(0).transform.GetChild(1).transform.GetChild(2).gameObject.SetActive(true);
            }

        }
        else
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].transform.GetChild(0).transform.GetChild(1).transform.GetChild(2).gameObject.SetActive(false);
            }
        }

    }

    public void navigationSound(bool boolean){
        OD.navigationSound = navigationSoundToggle.GetComponent<Toggle>().isOn;
    }
    public void navigationIndicator(bool boolean){
        OD.navigationIndicator = navigationIndicatorToggle.GetComponent<Toggle>().isOn;
    }

    public void audioIndicator(bool boolean){
        OD.audioIndicator = audioIndicatorToggle.GetComponent<Toggle>().isOn;
    }
    public void mainAudio(float floatnumber){
        OD.mainAudio = mainAudioSlider.value;
    }
    public void music(float floatnumber){
        OD.music = musicSlider.value;
    }

    public void soundEffects(float floatnumber){
       OD.soundEffects = soundEffectsSlider.value;
    }

    public void ambience(float floatnumber){
        OD.ambience = ambienceSlider.value;
    }

    public void textSize(float floatnumber){
    
        OD.textSize = textSizeSlider.value;
      
    }
    public void brightness(float floatnumber){
        OD.brightness = brightnessSlider.value;
    }
    public void Contrast(float floatnumber){
        OD.contrast = contrastSlider.value;
    }
    public void OutlineWidth(float floatnumber){
        OD.outlineWidth = outlineWidthSlider.value;
    }
    
    public void EnableOutline(bool boolean){
        OD.enableOutline = enableOutlineToggle.GetComponent<Toggle>().isOn;
    }

    public void OutlineColor(bool boolean){
        //OD.mainAudio = slider;
    }

    public void HintSystem(bool hintSystem)
    {
        OD.gameplayTutorial = hintToggle.GetComponent<Toggle>().isOn;
        //PlayerPrefs.SetInt("HintSystem", BoolToInt(hintSystem));



        GameObject TutorialCanvas = GameObject.FindGameObjectWithTag("Tutorial");
       // checkNoOfTutorialTriggers = CountTutorialTriggers();

        if (hintToggle.GetComponent<Toggle>().isOn && !isStartMenu)
        {
            for (int i = 0; i < TutorialCanvas.transform.childCount; i++)
            {
                TutorialCanvas.transform.GetChild(i).gameObject.SetActive(true);
                Debug.Log("Saheel");
            }
                    }
        else
        {
            for (int i = 0; i < TutorialCanvas.transform.childCount; i++)
            {

                TutorialCanvas.transform.GetChild(i).gameObject.SetActive(false);
            }
        }



    }

    public void OffScreenIndicator(bool offScreen)
    {
        OD.offscreenIndicator = indicatorToggle.GetComponent<Toggle>().isOn;
        //PlayerPrefs.SetInt("OffscreenIndicator", BoolToInt(offScreen));
        GameObject CanvasOffScreenIndicators = GameObject.FindGameObjectWithTag("OSIndicator"); // Find gameobject with tag that gets children during playmode that are the offscreen indicators
        checkNoOfEnemies = CountEnemies(); //Check how many enemies there are in the scene that the offscreen indicators checks

        if (indicatorToggle.GetComponent<Toggle>().isOn && !isStartMenu) // If the toggle is on, the offscreen indicator shows 
        {
            for (int i = 0; i < checkNoOfEnemies; i++) //Checks in scene for every enemy 
            {
                CanvasOffScreenIndicators.transform.GetChild(i).gameObject.SetActive(true);
            }
            
        }
        else  //If the toggle is off, the offscreen indicators does not show
        {
            for (int i = 0; i < checkNoOfEnemies; i++) 
            {
                CanvasOffScreenIndicators.transform.GetChild(i).gameObject.SetActive(false);
            }


        }
    }

    public void NavigationArrow(bool navArrow)
    {
        //PlayerPrefs.SetInt("NavigationArrow", BoolToInt(navArrow));
        
        OD.navigationArrow = navArrowToggle.GetComponent<Toggle>().isOn;
        
        GameObject navigationArrow = GameObject.FindGameObjectWithTag("Arrow"); //Find gameObject with tag Arrow. In this case this should be ArrowParent. 
        if (navArrowToggle.GetComponent<Toggle>().isOn && !isStartMenu) //Check if the toggle is toggled.
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
        GameObject.FindObjectOfType<Audio_Accessibility>().ToggleAudioAccessibility();
        /*PlayerPrefs.SetInt("AudioIndicator", BoolToInt(audioInd));
        if (audioIndicator.GetComponent<Toggle>().isOn) //Check if the toggle is toggled.
        {
            GetComponent<Audio_Accessibility>().ToggleAudioAccessibilityOn();
        }
        else
        {
            GetComponent<Audio_Accessibility>().ToggleAudioAccessibilityOff();
        }*/

    }
    public void activateVoiceAssist (bool boolean){
        OD.textToSpeach = textToSpeachToggle.GetComponent<Toggle>().isOn;
       if(OD.textToSpeach){
           voiceAssist = true;

       }
       else{
           voiceAssist = false;
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
        enemyOutlineToggle.GetComponent<Toggle>().isOn = OD.enemyOutline;
        hintToggle.GetComponent<Toggle>().isOn = OD.gameplayTutorial;
        indicatorToggle.GetComponent<Toggle>().isOn = OD.offscreenIndicator;
        navArrowToggle.GetComponent<Toggle>().isOn = OD.navigationArrow;
        audioIndicatorToggle.GetComponent<Toggle>().isOn = OD.audioIndicator;
        navigationSoundToggle.GetComponent<Toggle>().isOn = OD.navigationSound;
        navigationIndicatorToggle.GetComponent<Toggle>().isOn = OD.navigationIndicator;
        textToSpeachToggle.GetComponent<Toggle>().isOn = OD.textToSpeach;
        enableOutlineToggle.GetComponent<Toggle>().isOn = OD.enableOutline;
        
    }

    public void setSliders()
    {
        mainAudioSlider.value = OD.mainAudio;
        musicSlider.value = OD.music;
        soundEffectsSlider.value = OD.soundEffects;
        ambienceSlider.value = OD.ambience;
        textSizeSlider.value = OD.textSize;
        brightnessSlider.value = OD.brightness;
        contrastSlider.value = OD.contrast;
        outlineWidthSlider.value = OD.outlineWidth;

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

    public int CountEnemies() // count number of enemies in every scene
    {
        GameObject[] noOfEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        return noOfEnemies.Length;
    }


}
