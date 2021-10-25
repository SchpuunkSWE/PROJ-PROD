using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwAudioEmitter : MonoBehaviour
{

    public string EventName;
    public string StopEvent;
    private bool IsInCollider = false;
    // Start is called before the first frame update
    void Start()
    {
        //  AkSoundEngine.StopPlayingID
        AkSoundEngine.RegisterGameObj(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered " + EventName);
        if (other.tag!="Player" || IsInCollider)
        {
            return;
        }
        IsInCollider = true;
        AkSoundEngine.PostEvent(EventName, this.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited " + StopEvent);
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
