using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;



public class SliderSettings : MonoBehaviour
{
    public Slider slider;
    public Text txtSlider;
    [Tooltip("The maximum value for the settings. It's not viewable for the player")]
    public float maxSettingsValue;
    [Tooltip("The minimum value for the settings. It's not viewable for the player")]
    public float minSettingsValue;

    public Volume volume;
    VolumeProfile volumeProfile;
    public bool enableFog;
    public bool overrideFog;

    void Start()
    {
       //volumeProfile = volume.sharedProfile;
    }

    private void Update()
    {
        
    }

    void Exposure()
    {

    } 

    void Fog()
    {
        if (!volumeProfile.TryGet<Fog>(out var fog))
        {
            fog = volumeProfile.Add<Fog>(false);
        }

        fog.enabled.overrideState = overrideFog;
        fog.enabled.value = enableFog;
    }

}
