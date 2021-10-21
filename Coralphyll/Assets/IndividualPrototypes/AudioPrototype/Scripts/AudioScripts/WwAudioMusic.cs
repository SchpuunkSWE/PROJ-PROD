using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwAudioMusic : MonoBehaviour
{
    public string EventName = "Music_default";

    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
        AkSoundEngine.PostEvent(EventName, gameObject);
    }

}
