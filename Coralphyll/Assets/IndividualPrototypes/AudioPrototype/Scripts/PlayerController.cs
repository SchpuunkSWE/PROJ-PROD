using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController player;
    public static PlayerController Player
    {
        get
        {
            if (player == null)
            {
                player = FindObjectOfType<PlayerController>();
            }
            return player;
        }
    }

    public Controller3D playerController;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerDive();
        }
    }
    public void PlayerJump()
    {
        playerController.JumpFunction();
    }
    public void PlayerDive()
    {
        playerController.DiveFunction();
    }
}
