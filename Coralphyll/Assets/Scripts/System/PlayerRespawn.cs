using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    //[SerializeField]
    //private Transform player;

    //[SerializeField]
    //private Transform checkPoint;

    private GameController gc;

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GC").GetComponent<GameController>(); //reference to the GameController script
        //transform.position = gc.lastCheckPointPos; //sets the player's position to the most recent checkpoints
        transform.position = gc.GetLastCheckPointPos(); //sets the player's position to the most recent checkpoints
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            //RespawnPlayer();
            ReloadScene();


        }
    }
    //private void RespawnPlayer()
    //{
    //    gameObject.transform.position = checkPoint.transform.position;
    //}

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reloads the current scene
    }
}
