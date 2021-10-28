using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class VisualAidSettingsMenu : MonoBehaviour
{
    VolumeProfile volumeProfile;
    public Volume volume;
    public bool overrideFog;
    public Fog fog;
    public DepthOfField dof;
    public ColorAdjustments colorAdjustments;

    public SliderSettings exposureSlider; 

    private void Awake()
    {
        //get volume profile
        volumeProfile = volume.sharedProfile;
        
        //get fog override
        if(volumeProfile.TryGet<Fog>(out Fog actualFog))
        {
            fog = actualFog; 
        }

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

        //listen to the sliders values
        exposureSlider.slider.onValueChanged.AddListener(delegate { SetExposure(exposureSlider.slider.value); });
    }

    void OnApplicationQuit()
    {
        //set everything back to default
        
        //turn on fog again if it's turned off
        if (!fog.enabled.value)
        {
            fog.enabled.value = true;
        }

        //set exposure to 0 again
        colorAdjustments.postExposure.value = 0;

        //turn on depth of field
        dof.active = true;
    }

    public void SetExposure (float currentValue)
    {
        //To see the exposure value in the console
        //Debug.Log(exposure); 

        //Change the exposure according to the value
        float finalExposureValue;
        finalExposureValue = ConvertValue(exposureSlider.slider.minValue, exposureSlider.slider.maxValue, exposureSlider.minSettingsValue, exposureSlider.maxSettingsValue, currentValue);
        //access the profile and override it with the new result
        colorAdjustments.postExposure.value = finalExposureValue;
        exposureSlider.txtSlider.text = Mathf.RoundToInt(currentValue).ToString();
    }

    public void SetFog (bool isFog)
    {
        fog.enabled.value = isFog;
    }

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
