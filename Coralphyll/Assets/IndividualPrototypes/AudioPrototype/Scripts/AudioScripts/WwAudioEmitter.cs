using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwAudioEmitter : MonoBehaviour
{

    public string EventName = "SFX_3D_Emitter";
    public string StopEvent = "SFX_3D_Emitter_stop";
    private bool IsInCollider = false;
    // Start is called before the first frame update
    void Start()
    {
        //  AkSoundEngine.StopPlayingID
        AkSoundEngine.RegisterGameObj(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if (other.tag!="Player" || IsInCollider)
        {
            return;
        }
        IsInCollider = true;
        AkSoundEngine.PostEvent(EventName, gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited");
        if (other.tag != "Player" || !IsInCollider)
        {
            return;
        }
        AkSoundEngine.PostEvent(StopEvent, gameObject);
        IsInCollider = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" || IsInCollider)
        {
            return;
        }
        IsInCollider = true;
        AkSoundEngine.PostEvent(EventName, gameObject);
    }

}
