using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerKeybinds : MonoBehaviour
{
    public Controller3DKeybinds playerController;

    private static PlayerControllerKeybinds player;
    public static PlayerControllerKeybinds Player
    {
        get
        {
            if (player == null)
            {
                player = FindObjectOfType<PlayerControllerKeybinds>();
            }
            return player;
        }
    }
    private InputManager inputManager;

    void Start()
    {
        inputManager = InputManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.GetKeyUp(KeybindingActions.SwimUp) || inputManager.GetKeyUp(KeybindingActions.SwimDown)
        || inputManager.GetKeyUp(KeybindingActions.Forward) || inputManager.GetKeyUp(KeybindingActions.Back) ||
       inputManager.GetKeyUp(KeybindingActions.Right) || inputManager.GetKeyUp(KeybindingActions.Left))
        {
            PlayerResetMomentum();
        }
        if (inputManager.GetKey(KeybindingActions.SwimUp))
        {
            PlayerSwimUp();
        }
        if (inputManager.GetKey(KeybindingActions.SwimDown))
        {
            PlayerDive();
        }
        if(inputManager.GetKey(KeybindingActions.Forward))
        {
            PlayerForward();
        }
        if(inputManager.GetKey(KeybindingActions.Back))
        {
            PlayerBack();
        }
        if(inputManager.GetKey(KeybindingActions.Right))
        {
            PlayerRight();
        }
        if(inputManager.GetKey(KeybindingActions.Left))
        {
            PlayerLeft();
        }
       
    }

    public void PlayerSwimUp()
    {
        playerController.SwimUpFunction();
    }
    public void PlayerDive()
    {
        playerController.DiveFunction();
    }

    public void PlayerForward()
    {
        playerController.ForwardFunction();
    }

    public void PlayerBack()
    {
        playerController.BackFunction();
    }

    public void PlayerLeft()
    {
        playerController.LeftFunction();
    }

    public void PlayerRight()
    {
        playerController.RightFunction();
    }

    public void PlayerResetMomentum()
    {
        playerController.ResetMomentumFunction();
    }
}
