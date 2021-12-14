using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Cutscenes_Events : MonoBehaviour
{

    [SerializeField] private GameObject master;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SharkBite()
    {
        AkSoundEngine.PostEvent("Cutscene_level2_SharkBite", master);
    }
    public void PlayNarrationLevel2()
    {
        AkSoundEngine.PostEvent("Cutscene_level2_Voice", master);
    }
}
