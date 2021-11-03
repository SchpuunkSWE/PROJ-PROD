using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;

    [SerializeField]
    private Vector3 lastCheckPointPos;

    private void Awake()
    {
        if(instance == null)  
        {
            instance = this;
            DontDestroyOnLoad(instance); //Makes the GameController survive between scenes
        }
        else
        {
            Destroy(gameObject); //Ensures that there is only one GameController per scene
        }
    }


    public Vector3 GetLastCheckPointPos()
    {
        return lastCheckPointPos;
    }
    public void SetLastCheckPointPos(Vector3 newPos)
    {
        lastCheckPointPos = newPos;
    }
}
