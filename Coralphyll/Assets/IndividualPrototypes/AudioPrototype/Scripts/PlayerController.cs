using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
