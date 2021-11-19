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
       inputManager.GetKeyUp(KeybindingActions.Right) || inputManager.GetKeyUp(KeybindingActions.Left)
       || Input.GetAxisRaw("Vertical") == 0)
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
        if (inputManager.GetKey(KeybindingActions.Forward) || Input.GetAxisRaw("Vertical") > 0)
        {
            if (inputManager.GetKey(KeybindingActions.Forward))
                PlayerForward();
            else
                PlayerForwardAxis(Input.GetAxisRaw("Vertical"));
        }
        if(inputManager.GetKey(KeybindingActions.Back) || Input.GetAxisRaw("Vertical") < 0)
        {
            if(inputManager.GetKey(KeybindingActions.Back))
                PlayerBack();
            else
                PlayerForwardAxis(Input.GetAxisRaw("Vertical"));
        }
        if(inputManager.GetKey(KeybindingActions.Right) || Input.GetAxisRaw("Horizontal") > 0)
        {
            if (inputManager.GetKey(KeybindingActions.Right))
                PlayerRight();
            else
                PlayerRightAxis(Input.GetAxisRaw("Horizontal"));
        }
        if(inputManager.GetKey(KeybindingActions.Left) || Input.GetAxisRaw("Horizontal") < 0)
        {
            if(inputManager.GetKey(KeybindingActions.Left))
                PlayerLeft();
            else
                PlayerRightAxis(Input.GetAxisRaw("Horizontal"));
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

    public void PlayerForwardAxis(float axisInput)
    {
        playerController.ForwardAxisFunction(axisInput);
    }

    public void PlayerRightAxis(float axisInput)
    {
        playerController.RightAxisFunction(axisInput);
    }
}
