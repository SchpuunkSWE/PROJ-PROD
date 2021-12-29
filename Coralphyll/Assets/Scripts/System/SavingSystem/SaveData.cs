using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveData : MonoBehaviour
{

    public int level;
    public int coralsDone;
    // public bool[] levelCoralsActive; //Array to save current state of corals in scene // maybe dont need


    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SaveCoralProgress()
    {

        // i dunno how to do this

    }
    
}
