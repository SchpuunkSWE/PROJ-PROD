using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OptionsData", menuName = "OptionsDataScriptableObj")] 

public class OptionsData : ScriptableObject
{

    //Accessibility

    public bool gameplayTutorial, navigationIndicator, navigationSound, enemyOutline, offscreenIndicator, navigationArrow, audioIndicator;
    
    //Audio

    public float mainAudio, music, soundEffects, ambience;

    //Visual

    public float textSize, brightness, contrast, outlineWidth;

    public bool textToSpeach, enableOutline;

    //unity color för mollys prototyp
    public Color outlineColor;
    
}
