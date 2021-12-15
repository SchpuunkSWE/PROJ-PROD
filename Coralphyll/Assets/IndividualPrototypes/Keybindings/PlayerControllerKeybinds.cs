using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerKeybinds : MonoBehaviour
{
    public Controller3DKeybinds playerController;

    private static PlayerControllerKeybinds player;

    protected Animator anim;
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

        anim = GetComponentInChildren<Animator>();
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
            {
                PlayerAxisY(1f);
                anim.SetBool("up", true);
            }
            else
            {
                PlayerAxisY(Input.GetAxisRaw("SwimUp"));
                anim.SetBool("up", true);
            }
        }
        if (inputManager.GetKey(KeybindingActions.SwimDown) || Input.GetAxisRaw("Dive") > 0.01f)
        {
            if (inputManager.GetKey(KeybindingActions.SwimDown))
            {
                PlayerAxisY(-1f);
                anim.SetBool("down", true);
            }
            else
            {
                PlayerAxisY(-Input.GetAxisRaw("Dive"));
                anim.SetBool("down", true);
            }
                
        }
        if(inputManager.GetKey(KeybindingActions.Forward) || Input.GetAxisRaw("Vertical") > 0.01f)
        {
            if (inputManager.GetKey(KeybindingActions.Forward))
            {
                PlayerAxisZ(1f);
                anim.SetBool("forward", true);
            }
            else
            {
                PlayerAxisZ(Input.GetAxisRaw("Vertical"));
                anim.SetBool("forward", true);
            }
        }
        if(inputManager.GetKey(KeybindingActions.Back) || Input.GetAxisRaw("Vertical") < 0.01f)
        {
            if (inputManager.GetKey(KeybindingActions.Back))
            {
                PlayerAxisZ(-1f);
                anim.SetBool("backward", true);
            }
            else
            {
                PlayerAxisZ(Input.GetAxisRaw("Vertical"));
                anim.SetBool("backward", true);
            }

        }
        if(inputManager.GetKey(KeybindingActions.Right) || Input.GetAxisRaw("Horizontal") > 0.01f)
        {
            if (inputManager.GetKey(KeybindingActions.Right))
            {
                PlayerAxisX(1f);
                anim.SetBool("right", true);
            }
            else
            {
                PlayerAxisX(Input.GetAxisRaw("Horizontal"));
                anim.SetBool("right", true);
            }
        }
        if(inputManager.GetKey(KeybindingActions.Left) || Input.GetAxisRaw("Horizontal") < 0.01f)
        {
            if (inputManager.GetKey(KeybindingActions.Left))
            {
                PlayerAxisX(-1f);
                anim.SetBool("left", true);
            }
            else
            {
                PlayerAxisX(Input.GetAxisRaw("Horizontal"));
                anim.SetBool("left", true);
            }
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
        anim.SetBool("twirl", false);
    }

    private void PlayerBoost()
    {
        if(playerController.isBoostReady)
        {
            playerController.StartBoost();
            anim.SetBool("twirl", true);
        }
    }
}
