using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData
{

    public int level;
    //public int coralsDone;
    // public bool[] levelCoralsActive; //Array to save current state of corals in scene // maybe dont need

    
    public SaveData ()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        
    }

    /*
    private void SaveCoralProgress()
    {
        // i dunno how to do this
    }
    */
}
