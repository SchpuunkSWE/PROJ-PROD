using UnityEngine;
using System;
using System.Collections;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [SerializeField]
    private Keybindings keybindings;
    private static readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));
    
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

    public void StartKeySwapRoutine(int keybindingIndex)
    {
        StartCoroutine(SwapKeyBinding(keybindingIndex));
    }

    private IEnumerator SwapKeyBinding(int index)
    {
        bool complete = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        while (!complete)
        {
            if(Input.anyKeyDown)
            {
                foreach (KeyCode keyCode in keyCodes)
                {
                    if (Input.GetKey(keyCode))
                    {
                        keybindings.keybindingsChecks[index].keyCode = keyCode;
                        complete = true;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        break;
                    }
                }
            }
            yield return null;
        }
    }
}
