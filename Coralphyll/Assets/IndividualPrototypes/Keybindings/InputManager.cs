using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [SerializeField]
    private Keybindings keybindings;
    
    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }

    public KeyCode GetKeyForAction(KeybindingActions keybindingAction)
    {
        //Find keycode 
        foreach(Keybindings.KeybindingsCheck keybindingCheck in keybindings.keybindingsChecks)
        {
            if(keybindingCheck.keybindingAction == keybindingAction)
                return keybindingCheck.keyCode;
        }

        return KeyCode.None;
    }

    public bool GetKey(KeybindingActions key)
    {
        //Check for key
        foreach(Keybindings.KeybindingsCheck keybindingCheck in keybindings.keybindingsChecks)
            {
                if(keybindingCheck.keybindingAction == key)
                    return Input.GetKey(keybindingCheck.keyCode);
            }

        return false;
    }

    public bool GetKeyUp(KeybindingActions key)
    {
        //Check for key
        foreach(Keybindings.KeybindingsCheck keybindingCheck in keybindings.keybindingsChecks)
            {
                if(keybindingCheck.keybindingAction == key)
                    return Input.GetKeyUp(keybindingCheck.keyCode);
            }

        return false;

    }

    public bool GetKeyDown(KeybindingActions key)
    {
        //Check for key
        foreach(Keybindings.KeybindingsCheck keybindingCheck in keybindings.keybindingsChecks)
            {
                if(keybindingCheck.keybindingAction == key)
                    return Input.GetKeyDown(keybindingCheck.keyCode);
            }

        return false;
    }
    
    public void SwapToRighthand()
    {
        Debug.Log("Pressed swap to right button");
        keybindings.keybindingsChecks[0].keyCode = KeyCode.Space;
        keybindings.keybindingsChecks[1].keyCode = KeyCode.LeftShift;
        keybindings.keybindingsChecks[2].keyCode = KeyCode.W;
        keybindings.keybindingsChecks[3].keyCode = KeyCode.S;
        keybindings.keybindingsChecks[4].keyCode = KeyCode.D;
        keybindings.keybindingsChecks[5].keyCode = KeyCode.A;

    }

    public void SwapToLefthand()
    {
        Debug.Log("Pressed swap to left button");
        keybindings.keybindingsChecks[0].keyCode = KeyCode.RightControl;
        keybindings.keybindingsChecks[1].keyCode = KeyCode.Insert;
        keybindings.keybindingsChecks[2].keyCode = KeyCode.UpArrow;
        keybindings.keybindingsChecks[3].keyCode = KeyCode.DownArrow;
        keybindings.keybindingsChecks[4].keyCode = KeyCode.RightArrow;
        keybindings.keybindingsChecks[5].keyCode = KeyCode.LeftArrow;
    }
}
