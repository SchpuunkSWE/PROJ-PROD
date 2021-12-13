using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwAudioEmitter : MonoBehaviour
{
    public string emitterType;
    public string EventName;
    public string StopEvent;
    private bool IsInCollider = false;
    private bool constantEmitter;
    // Start is called before the first frame update
    void Start()
    {
        //  AkSoundEngine.StopPlayingID
        AkSoundEngine.RegisterGameObj(this.gameObject);
        if (emitterType == "Trash")
        {

            AkSoundEngine.PostEvent(EventName, this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!constantEmitter)
        {
            if (other.tag != "Player" || IsInCollider)
            {
                return;
            }
            IsInCollider = true;
            AkSoundEngine.PostEvent(EventName, this.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!constantEmitter)
        {
            if (other.tag != "Player" || !IsInCollider)
            {
                return;
            }
            AkSoundEngine.PostEvent(StopEvent, gameObject);
            IsInCollider = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!constantEmitter)
        {
            if (other.tag != "Player" || IsInCollider)
            {
                return;
            }
            IsInCollider = true;
            AkSoundEngine.PostEvent(EventName, gameObject);
        }
    }

}
