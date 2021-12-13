using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_CutScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("Cutscene_Level1_Voice", gameObject);
        AkSoundEngine.PostEvent("Cutscene_Level1_Ambience", gameObject);
        Debug.Log("Playing");
    }

}
