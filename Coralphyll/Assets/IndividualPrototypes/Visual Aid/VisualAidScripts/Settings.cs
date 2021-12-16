using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{
    [Header("Dropdowns")]
    public Dropdown resolutionDimension;
    public Dropdown display;

    //private variables
    private Resolution[] storeResolutions;
    private FullScreenMode screenMode;

    private int countRes;

    #region Resolution and Display
    //Add resolutions to dropdown based on the user's computer

    void AddResolution(Resolution[] res)
    {
        countRes = 0;
        // Display resolutions at the current screen refresh rate
        for(int i = 0; i < res.Length; i++)
        {
            if (res[i].refreshRate == Screen.currentResolution.refreshRate
                && res[i].width > 800 && res[i].height > 800)
            {
                storeResolutions[countRes] = res[i];
                countRes++;
            }
        }

        // Adding the resolutions to the dropdown
        for(int i = 0; i < countRes; i++)
        {
            resolutionDimension.options.Add(new Dropdown.OptionData(ResolutionToString(storeResolutions[i])));
        }

    }

    //Determines what screen mode that we should use
    void ScreenOptions(string mode)
    {
        if(mode == "Full Screen")
        {
            screenMode = FullScreenMode.ExclusiveFullScreen;
        }else if(mode == "Windowed")
        {
            screenMode = FullScreenMode.Windowed;
        }
        else
        {
            screenMode = FullScreenMode.FullScreenWindow;
        }

        Screen.fullScreenMode = screenMode;
    }

    //Determine current resolution value upon starting the game
    void ResolutionInitialize(Resolution[] res)
    {
        for(int i = 0; i < res.Length; i++)
        {
            if(Screen.width == res[i].width && Screen.height == res[i].height)
            {
                resolutionDimension.value = i;
            }
        }
        resolutionDimension.RefreshShownValue();
    }

    //Determine current screen mode upon starting the game
    void ScreenInitialize()
    {
        if(Screen.fullScreenMode == FullScreenMode.ExclusiveFullScreen)
        {
            display.value = 0;
            screenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else if (Screen.fullScreenMode == FullScreenMode.Windowed)
        {
            display.value = 1;
            screenMode = FullScreenMode.Windowed;
        }
        else
        {
            display.value = 2;
            screenMode = FullScreenMode.FullScreenWindow;
        }

        display.RefreshShownValue();
    }

    //Converts resolution numbers into a string
    string ResolutionToString(Resolution screenRes)
    {
        return screenRes.width + "x" + screenRes.height;
    }

#endregion 

    // Start is called before the first frame update
    void Start()
    {
        Resolution[] resolutions = Screen.resolutions;
        //Array.Reverse(resolutions); It can't find array?
        storeResolutions = new Resolution[resolutions.Length];

        ScreenInitialize();
        AddResolution(resolutions);
        ResolutionInitialize(storeResolutions);

        //Resolutions and Display Settings
        display.onValueChanged.AddListener(delegate { ScreenOptions(display.options[display.value].text); });
        resolutionDimension.onValueChanged.AddListener(delegate
        {
            Screen.SetResolution(storeResolutions[resolutionDimension.value].width, storeResolutions[resolutionDimension.value].height, screenMode);
        });
    }

}
