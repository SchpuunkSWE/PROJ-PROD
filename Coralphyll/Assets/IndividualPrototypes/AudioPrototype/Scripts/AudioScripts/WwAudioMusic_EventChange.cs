using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwAudioMusic_EventChange : MonoBehaviour
{
    public string wwise_stateGroup_gameState_combat = "MusicState_Combat";
    public string wwise_stateGroup_gameState_exploring = "MusicState_Exploring";
    public bool isInCollider;
    public GameObject akGameObj;
    void Start()
    {
        //  AkSoundEngine.StopPlayingID
        AkSoundEngine.RegisterGameObj(akGameObj);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if (other.tag != "Player")
        {
            return;
        }
        isInCollider = true;
        AkSoundEngine.PostEvent(wwise_stateGroup_gameState_combat, akGameObj);

    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if (other.tag != "Player" || !isInCollider)
        {
            return;
        }
        isInCollider = false;
        AkSoundEngine.PostEvent(wwise_stateGroup_gameState_exploring, akGameObj);

    }
}
