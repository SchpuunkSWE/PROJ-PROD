using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UI_SoundSystem : MonoBehaviour , IPointerEnterHandler
{
    //public AudioClip AudioClip ;
    //private AudioSource audioSource;
    public OptionsMenu optionsMenu;
    public string audioClip;





    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {   if(optionsMenu.voiceAssist){

        AkSoundEngine.PostEvent(audioClip, GameObject.FindGameObjectWithTag("MainCamera"));

            
        Debug.Log("I played script");
        }
    }
}
