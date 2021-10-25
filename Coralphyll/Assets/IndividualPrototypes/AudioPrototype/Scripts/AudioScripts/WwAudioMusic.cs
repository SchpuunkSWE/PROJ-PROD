using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwAudioMusic : MonoBehaviour
{
    public string wwise_stateGroup_gameState = "MusicState_Initiate";
   // public string MusicPlay = "Music_initiate"; 
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
       // AkSoundEngine.PostEvent(MusicPlay, gameObject);
        AkSoundEngine.PostEvent(wwise_stateGroup_gameState, gameObject);
    }
    
}
