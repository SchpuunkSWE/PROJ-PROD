using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_TempScript : MonoBehaviour
{
    private bool IsInCollider = true;
    Audio_Events events;
    void Start()
    {
        //  AkSoundEngine.StopPlayingID
        AkSoundEngine.RegisterGameObj(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" || IsInCollider)
        {
            return;
        }
        IsInCollider = true;
        events = other.GetComponent<Audio_Events>(); 
        events.Audio_LevelState("MainMenu");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" || !IsInCollider)
        {
            return;
        }
       
        events = other.GetComponent<Audio_Events>();
        events.LeaveMainMenu();
        events.Audio_LevelState("Exploring");
        IsInCollider = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" || IsInCollider)
        {
            return;
        }
        IsInCollider = true;
        events = other.GetComponent<Audio_Events>();
        events.Audio_LevelState("MainMenu");
    }
}
