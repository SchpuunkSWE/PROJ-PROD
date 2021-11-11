using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VisualAidSettingsMenu : MonoBehaviour
{
    VolumeProfile volumeProfile;
    public Volume volume;
    //public bool overrideFog;
    //public Fog fog;
    public DepthOfField dof;
    //public ColorAdjustments colorAdjustments;
    public LiftGammaGain lgg;
    private Vector4 defaultGammaValue;

    public SliderSettings brightnessSlider; 

    private void Awake()
    {
        //get volume profile
        volumeProfile = volume.sharedProfile;
        
        //get fog override
        /*if(volumeProfile.TryGet<Fog>(out Fog actualFog))
        {
            fog = actualFog; 
        }*/

        //get dof override
        if(volumeProfile.TryGet<DepthOfField>(out DepthOfField actualDof))
        {
            dof = actualDof;
        }

        //get color adjustments
        /*if (volumeProfile.TryGet<ColorAdjustments>(out ColorAdjustments actualColorAdjustments))
        {
            colorAdjustments = actualColorAdjustments;
        }*/

        //get LiftGammaGain
        if (volumeProfile.TryGet<LiftGammaGain>(out LiftGammaGain actualLgg))
        {
            lgg = actualLgg;
        }

        //get default Gamma Value
        defaultGammaValue = lgg.gamma.value;

        //listen to the sliders values
        brightnessSlider.slider.onValueChanged.AddListener(delegate { SetBrightness(brightnessSlider.slider.value); });
    }

    void OnApplicationQuit()
    {
        //set everything back to default

        //turn on fog again if it's turned off
        /*if (!fog.enabled.value)
        {
            fog.enabled.value = true;
        }*/

        //set brightness to 0 again
        //colorAdjustments.postExposure.value = 0;
        lgg.gamma.value = defaultGammaValue;

        //turn on depth of field
        dof.active = true;
    }

    public void SetBrightness (Vector4 currentValue)
    {
        //To see the brightness value in the console
        //Debug.Log(brightness); 

        //Change the brightness according to the value
        Vector4 finalBrightnessValue;
        finalBrightnessValue = ConvertValue(brightnessSlider.slider.minValue, brightnessSlider.slider.maxValue, brightnessSlider.minSettingsValue, brightnessSlider.maxSettingsValue, currentValue);
        //access the profile and override it with the new result

        //colorAdjustments.postExposure.value = finalBrightnessValue;
        lgg.gamma.value = finalBrightnessValue;
        brightnessSlider.txtSlider.text = Mathf.RoundToInt(currentValue).ToString();
    }

    /*public void SetFog (bool isFog)
    {
        fog.enabled.value = isFog;
    }*/

    public void SetDof (bool isDof)
    {
        dof.active = isDof; 
    }

    public void SetHighContrastMode(bool isHighContrastMode)
    {
        //set highcontrastmode according to the toggle
    }

    //getting the ratio between our virtual and actual ranges
    float ConvertValue(float virtualMin, float virtualMax, float actualMin, float actualMax, float currentValue)
    {
        float ratio = (actualMax - actualMin) / (virtualMax - virtualMin);
        float returnValue = (currentValue * ratio) - (virtualMin * ratio) + actualMin;
        return returnValue;
    }

}
