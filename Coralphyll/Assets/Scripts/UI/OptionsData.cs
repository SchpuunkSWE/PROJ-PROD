using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OptionsData", menuName = "OptionsDataScriptableObj")] 

public class OptionsData : ScriptableObject
{

    //Accessibility

    public bool gameplayTutorial, navigationIndicator, navigationSound, enemyOutline, offscreenIndicator, navigationArrow, audioIndicator;
    
    
}
