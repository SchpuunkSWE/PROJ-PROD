using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UI_SoundSystem : MonoBehaviour , IPointerEnterHandler
{
    public AudioClip AudioClip ;
    private AudioSource audioSource ;

    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        if( audioSource == null )
            audioSource = GetComponent<AudioSource>();
        if( audioSource == null )
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.PlayOneShot( AudioClip ) ;
    }
}
