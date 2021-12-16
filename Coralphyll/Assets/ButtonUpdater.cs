using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUpdater : MonoBehaviour
{
    private Button[] buttons;

    [SerializeField]
    private Keybindings keybindings;

    void Start()
    {
        buttons = GetComponentsInChildren<Button>();
    }
    // Update is called once per frame
    void Update()
    {
        buttons[0].GetComponentInChildren<Text>().text = keybindings.keybindingsChecks[2].keyCode.ToString
        ();
        buttons[1].GetComponentInChildren<Text>().text = keybindings.keybindingsChecks[5].keyCode.ToString
        ();
        buttons[2].GetComponentInChildren<Text>().text = keybindings.keybindingsChecks[1].keyCode.ToString
        ();
        buttons[3].GetComponentInChildren<Text>().text = keybindings.keybindingsChecks[7].keyCode.ToString
        ();
        buttons[5].GetComponentInChildren<Text>().text = keybindings.keybindingsChecks[3].keyCode.ToString
        ();
        buttons[6].GetComponentInChildren<Text>().text = keybindings.keybindingsChecks[4].keyCode.ToString
        ();
        buttons[7].GetComponentInChildren<Text>().text = keybindings.keybindingsChecks[0].keyCode.ToString
        ();
        buttons[8].GetComponentInChildren<Text>().text = keybindings.keybindingsChecks[6].keyCode.ToString
        ();
    }
}