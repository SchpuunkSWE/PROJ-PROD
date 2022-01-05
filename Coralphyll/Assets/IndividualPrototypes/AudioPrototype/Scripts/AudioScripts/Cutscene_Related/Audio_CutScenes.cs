using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio_CutScenes : MonoBehaviour
{

    private string sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().name;
        playCutsceneAudio();
        Debug.Log("Sceneindex is: " + sceneIndex);
    }
    private void playCutsceneAudio()
    {
        switch (sceneIndex)
        {
            case "Level1":
                AkSoundEngine.PostEvent("Cutscene_Level1_Voice", gameObject);
                AkSoundEngine.PostEvent("Cutscene_Level1_Ambience", gameObject);
               // FindObjectOfType<Audio_Pause>().CinemaMode();
                break;
            case "Cutscene_Level1":
                AkSoundEngine.PostEvent("Cutscene_Level1_Voice", gameObject);
                AkSoundEngine.PostEvent("Cutscene_Level1_Ambience", gameObject);
                break;
            case "Level2":
                AkSoundEngine.PostEvent("Cutscene_Level2_Voice", gameObject);
                AkSoundEngine.PostEvent("Cutscene_Level2_Ambience", gameObject);
                break;
            case "Cutscene_Level2":
                AkSoundEngine.PostEvent("Cutscene_Level2_Voice", gameObject);
                AkSoundEngine.PostEvent("Cutscene_Level2_Ambience", gameObject);
                break;
            case "Level3":
               // AkSoundEngine.PostEvent("Cutscene_Level3_Voice", gameObject);
                AkSoundEngine.PostEvent("Cutscene_Level3_Ambience", gameObject);
                break;
            case "Cutscene_Level3":
                // AkSoundEngine.PostEvent("Cutscene_Level3_Voice", gameObject);
                AkSoundEngine.PostEvent("Cutscene_Level3_Ambience", gameObject);
                Debug.Log("Playing");
                break;
            case "Level4":
                AkSoundEngine.PostEvent("Cutscene_Level4_Stinger", gameObject);            
                break;
            case "Cutscene_Level4":
                AkSoundEngine.PostEvent("Cutscene_Level4_Stinger", gameObject);
                break;
            case "Credits":
                AkSoundEngine.PostEvent("Cutscene_PlayCredits", gameObject);
                break;
            default:
                break;
        }
    }
}
