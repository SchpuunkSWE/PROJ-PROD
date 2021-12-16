using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUpdater : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons;

    [SerializeField]
    private Keybindings keybindings;

    // Update is called once per frame
    void Update()
    {
        buttons[0].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = keybindings.keybindingsChecks[2].keyCode.ToString
        ();
        buttons[1].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = keybindings.keybindingsChecks[5].keyCode.ToString
        ();
        buttons[2].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = keybindings.keybindingsChecks[1].keyCode.ToString
        ();
        buttons[3].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = keybindings.keybindingsChecks[7].keyCode.ToString
        ();
        buttons[4].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = keybindings.keybindingsChecks[3].keyCode.ToString
        ();
        buttons[5].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = keybindings.keybindingsChecks[4].keyCode.ToString
        ();
        buttons[6].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = keybindings.keybindingsChecks[0].keyCode.ToString
        ();
        buttons[7].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = keybindings.keybindingsChecks[6].keyCode.ToString
        ();
    }
}
