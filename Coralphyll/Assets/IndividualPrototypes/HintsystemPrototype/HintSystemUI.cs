using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintSystemUI : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject hintSystemCanvas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = true;

    }

}
