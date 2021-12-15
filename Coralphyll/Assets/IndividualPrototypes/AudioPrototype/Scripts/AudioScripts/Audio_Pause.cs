using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void PauseFunction()
    {
        if (GameObject.FindGameObjectWithTag("CinemachineCamera"))
        {
            PauseCinematic();
        }
        else
        {
            PauseMusic();
            PauseSFX();
        }
    }
    public void ResumeFunction()
    {
        if (GameObject.FindGameObjectWithTag("CinemachineCamera"))
        {
            ResumeCinematic();
        }
        else
        {
            ResumeMusic();
            ResumeSFX();
        }
    }

    public void CinemaMode()
    {

    }


    public void PauseCinematic()
    {
        AkSoundEngine.PostEvent("PauseEverything", GameObject.FindGameObjectWithTag("CinemachineCamera"));
    }
    public void ResumeCinematic()
    {
        AkSoundEngine.PostEvent("ResumeEverything", GameObject.FindGameObjectWithTag("CinemachineCamera"));
    }
    public void PauseMusic()
    {
        AkSoundEngine.PostEvent("PauseEverything_01", GameObject.FindGameObjectWithTag("MainCamera"));
    }
    public void ResumeMusic()
    {
        AkSoundEngine.PostEvent("ResumeEverything_01", GameObject.FindGameObjectWithTag("MainCamera"));
    }
    public void PauseSFX()
    {
        AkSoundEngine.PostEvent("PauseEverything_02", GameObject.FindGameObjectWithTag("MainCamera"));
    }
    public void ResumeSFX()
    {
        AkSoundEngine.PostEvent("ResumeEverything_02", GameObject.FindGameObjectWithTag("MainCamera"));
    }

}
