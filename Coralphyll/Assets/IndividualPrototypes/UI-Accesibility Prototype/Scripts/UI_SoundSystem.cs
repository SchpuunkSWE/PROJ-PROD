using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UI_SoundSystem : MonoBehaviour , IPointerEnterHandler
{
    public AudioClip AudioClip ;
    private AudioSource audioSource;
    public StartMenu startMenu;
    public string audioClip;

    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {   if(startMenu.voiceAssist){
            if( audioSource == null )
                audioSource = GetComponent<AudioSource>();
               
            if( audioSource == null )
                audioSource = gameObject.AddComponent<AudioSource>();
                Debug.Log("I got Audiosource");

            AkSoundEngine.PostEvent(audioClip, GameObject.FindGameObjectWithTag("MainCamera"));
            
            audioSource.PlayOneShot( AudioClip ) ;
            Debug.Log("I played script");
        }
    }
}
