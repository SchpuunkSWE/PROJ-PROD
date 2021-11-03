using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVolumeController : MonoBehaviour
{
    public GameObject volControls;
    private bool controlsActive = false;

    public void ToggleMenu()
    {
        volControls.SetActive(controlsActive);
        controlsActive = !controlsActive;
    }
}
