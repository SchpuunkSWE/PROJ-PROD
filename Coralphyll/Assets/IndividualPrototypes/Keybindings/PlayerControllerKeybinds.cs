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
       || Mathf.Abs(Input.GetAxisRaw("Vertical")) <= 0.01f || Mathf.Abs(Input.GetAxisRaw("Horizontal")) <= 0.01f)
        {
            PlayerResetMomentum();
        }
        if (inputManager.GetKey(KeybindingActions.SwimUp) || Input.GetAxisRaw("SwimUp") > 0.01f)
        {
            if (inputManager.GetKey(KeybindingActions.SwimUp))
                PlayerAxisY(1f);
            else
                PlayerAxisY(Input.GetAxisRaw("SwimUp"));
        }
        if (inputManager.GetKey(KeybindingActions.SwimDown) || Input.GetAxisRaw("Dive") > 0.01f)
        {
            if (inputManager.GetKey(KeybindingActions.SwimDown))
                PlayerAxisY(-1f);
            else
                PlayerAxisY(-Input.GetAxisRaw("Dive"));
        }
        if(inputManager.GetKey(KeybindingActions.Forward) || Input.GetAxisRaw("Vertical") > 0.01f)
        {
            if (inputManager.GetKey(KeybindingActions.Forward))
                PlayerAxisZ(1f);
            else
                PlayerAxisZ(Input.GetAxisRaw("Vertical"));
        }
        if(inputManager.GetKey(KeybindingActions.Back) || Input.GetAxisRaw("Vertical") < 0.01f)
        {
            if(inputManager.GetKey(KeybindingActions.Back))
                PlayerAxisZ(-1f);
            else
                PlayerAxisZ(Input.GetAxisRaw("Vertical"));

        }
        if(inputManager.GetKey(KeybindingActions.Right) || Input.GetAxisRaw("Horizontal") > 0.01f)
        {
            if (inputManager.GetKey(KeybindingActions.Right))
                PlayerAxisX(1f);
            else
                PlayerAxisX(Input.GetAxisRaw("Horizontal"));
        }
        if(inputManager.GetKey(KeybindingActions.Left) || Input.GetAxisRaw("Horizontal") < 0.01f)
        {
            if (inputManager.GetKey(KeybindingActions.Left))
                PlayerAxisX(-1f);
            else
                PlayerAxisX(Input.GetAxisRaw("Horizontal"));
        }

        if(inputManager.GetKey(KeybindingActions.Boost) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            PlayerBoost();
        }

        if (inputManager.GetKey(KeybindingActions.DropFish) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            gameObject.GetComponent<NPCFishUtil>().DropFish();
        }
    }
       
    

    private void PlayerAxisZ(float input)
    {
        playerController.AxisZFunction(input);
    }

    private void PlayerAxisX(float input)
    {
        playerController.AxisXFunction(input);
    }
    
    private void PlayerAxisY(float input)
    {
        playerController.AxisYFunction(input);
    }

    private void PlayerResetMomentum()
    {
        playerController.ResetMomentumFunction();
    }

    private void PlayerBoost()
    {
        if(playerController.isBoostReady)
            playerController.StartBoost();
    }
}
