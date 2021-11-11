using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeybindButtonTextUpdate : MonoBehaviour
{
    public Text text;
    private string originaltext;
    public Keybindings keybindings;
    public int index;

    public void Start()
    {
        originaltext = text.text;
    }

    public void Update()
    {
        text.text = originaltext + keybindings.keybindingsChecks[index].keyCode.ToString();
    }
}
