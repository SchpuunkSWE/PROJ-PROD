using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerKeybinds1 : MonoBehaviour
{
    public PlayerInputBehaviour playerController;
    private InputManager inputManager;

    void Start()
    {
        inputManager = InputManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.GetKey(KeybindingActions.SwimUp))
        {
            PlayerSwimUp();
        }
        if (inputManager.GetKey(KeybindingActions.SwimDown))
        {
            PlayerDive();
        }
        if (inputManager.GetKey(KeybindingActions.Forward) || inputManager.GetKey(KeybindingActions.Back))
        {
           PlayerThrust();
        }
        //if(inputManager.GetKey(KeybindingActions.Back))
        //{
        //    PlayerBack();
        //}
        if(inputManager.GetKey(KeybindingActions.Right) || inputManager.GetKey(KeybindingActions.Left))
        {
            PlayerSteer();
        }
        //if(inputManager.GetKey(KeybindingActions.Right))
        //{
        //    PlayerRight();
        //}
        //if(inputManager.GetKey(KeybindingActions.Left))
        //{
        //    PlayerLeft();
        //}
        if (inputManager.GetKeyUp(KeybindingActions.SwimUp) || inputManager.GetKeyUp(KeybindingActions.SwimDown)
         || inputManager.GetKeyUp(KeybindingActions.Forward) || inputManager.GetKeyUp(KeybindingActions.Back) ||
        inputManager.GetKeyUp(KeybindingActions.Right) || inputManager.GetKeyUp(KeybindingActions.Left))
        {
            PlayerResetMomentum();
        }
}

    public void PlayerThrust()
    {
        playerController.OnThrust(Input.GetAxisRaw("Vertical"));
    }

    public void PlayerSteer()
    {
        playerController.OnSteering(Input.GetAxisRaw("Horizontal"));
    }

    public void PlayerResetMomentum()
    {
        playerController.ResetMomentum();
    }

    public void PlayerDive()
    {
        playerController.OnDive(true);
    }

    public void PlayerSwimUp()
    {
        playerController.OnSwimUp(true);
    }
}
