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
    public LiftGammaGain lgg;
    private ColorAdjustments colorAdjustments;
    private Vector4 defaultGammaValue;
    private float defaultContrastValue;

    public SliderSettings brightnessSlider;
    public SliderSettings contrastSlider;

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
        if (volumeProfile.TryGet<ColorAdjustments>(out ColorAdjustments actualColorAdjustments))
        {
            colorAdjustments = actualColorAdjustments;
        }

        //get LiftGammaGain
        if (volumeProfile.TryGet<LiftGammaGain>(out LiftGammaGain actualLgg))
        {
            lgg = actualLgg;
        }

        //get default Gamma Value
        defaultGammaValue = lgg.gamma.value;

        //get default contrast value
        defaultContrastValue = colorAdjustments.contrast.value;

        //listen to the sliders values
        brightnessSlider.slider.onValueChanged.AddListener(delegate { SetBrightness(brightnessSlider.slider.value); });
        contrastSlider.slider.onValueChanged.AddListener(delegate { SetContrast(contrastSlider.slider.value); });
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

        //set contrast to default again
        colorAdjustments.contrast.value = defaultContrastValue;

        //turn on depth of field
        dof.active = true;
    }

    public void SetBrightness (float currentValue)
    {
        //Change the brightness according to the value
        float finalBrightnessValueFloat = ConvertValue(brightnessSlider.slider.minValue, brightnessSlider.slider.maxValue, brightnessSlider.minSettingsValue, brightnessSlider.maxSettingsValue, currentValue);

        //Make a Vector4 using the currentValue
        Vector4 finalBrightnessValueV4 = new Vector4(0, 0, 0, finalBrightnessValueFloat);

        //access the profile and override it with the new result
        //colorAdjustments.postExposure.value = finalBrightnessValue;
        
        //Set the gamma to the new Vector4
        lgg.gamma.value = finalBrightnessValueV4;

        //Set the text by the slider to the correct number
        brightnessSlider.txtSlider.text = currentValue.ToString();
    }

    public void SetContrast(float currentValue)
    {
        //Change the contrast according to the value
        float finalContrastValue = ConvertValue(contrastSlider.slider.minValue, contrastSlider.slider.maxValue, contrastSlider.minSettingsValue, contrastSlider.maxSettingsValue, currentValue);

        //Access the profile and override it with the new result
        colorAdjustments.contrast.value = finalContrastValue;

        //Set the contrast to the new value

        //Set the text by the slider to the correct number
        contrastSlider.txtSlider.text = currentValue.ToString();
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
