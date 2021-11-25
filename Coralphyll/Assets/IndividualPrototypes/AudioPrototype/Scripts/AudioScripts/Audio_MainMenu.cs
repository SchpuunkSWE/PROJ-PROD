using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
        PlayMainMenuTheme();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayMainMenuTheme()
    {
        AkSoundEngine.PostEvent("MusicState_MainMenu", gameObject);
    }
}
