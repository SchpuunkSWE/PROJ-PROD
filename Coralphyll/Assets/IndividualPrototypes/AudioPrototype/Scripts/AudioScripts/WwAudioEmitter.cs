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
            AkSoundEngine.PostEvent(StopEvent, this.gameObject);
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
    /*private void OnTriggerStay(Collider other)
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
    }*/

    public void SetName(string newName)
    {
        AkSoundEngine.PostEvent(StopEvent, this.gameObject);
        EventName = newName;
        AkSoundEngine.PostEvent(EventName, this.gameObject);
    }
    public void SetType(string newName)
    {
        emitterType = newName;
    }
    public void SetStopName(string newName)
    {
        StopEvent = newName;
    }
    
    public string getName()
    {
        return EventName;
    }
    public string GetEmitterType()
    {
       return emitterType;
    }
    public string GetStopName()
    {
        return StopEvent;
    }

    public void StopFunction()
    {
        AkSoundEngine.PostEvent(StopEvent, this.gameObject);
    }
}
