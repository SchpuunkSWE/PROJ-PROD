using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TBOB
{
    [System.Serializable]
    public class SliderSettings
    {
        public Slider slider;
        public Text txtSlider;
        [Tooltip("The maximum value for the settings. It's not viewable for the player")]
        public float maxSettingsValue;
        [Tooltip("The minimum value for the settings. It's not viewable for the player")]
        public float minSettingsValue;

        public GameObject postProcess; 

    }
     
}
