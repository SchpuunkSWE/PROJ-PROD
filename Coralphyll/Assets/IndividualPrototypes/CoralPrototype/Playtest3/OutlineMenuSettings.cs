using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineMenuSettings : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> coralsInScene;

    [SerializeField]
    private FlexibleColorPicker colourPicker;

    private void Start()
    {
        //Start Disabled
        foreach (GameObject go in coralsInScene)
        {
            go.GetComponentInChildren<Outline>().enabled = false;
        }

        colourPicker.gameObject.SetActive(false);
    }
    public void ToggleOutline(bool toggled)
    {
        
        foreach(GameObject go in coralsInScene)
        {
            if (toggled)
            {
                go.GetComponentInChildren<Outline>().enabled = true;

                //also toggle on colorpicker
                colourPicker.gameObject.SetActive(true);
            }
            else
            {
                go.GetComponentInChildren<Outline>().enabled = false;
                //also toggle off colorpicker
                colourPicker.gameObject.SetActive(false);

            }
        }
    }
    public void SetOutlineWidth(float value)
    {
        foreach(GameObject go in coralsInScene)
        {
            go.GetComponentInChildren<Outline>().ApplyOutlineWidthInput(value);
        }

    }

    public void SetOutlineMode(int value)
    {
        foreach (GameObject go in coralsInScene)
        {
            go.GetComponentInChildren<Outline>().ApplyOutlineModeInput(value);
        }
    }

    private void SetOutlineColour()
    {
        foreach (GameObject go in coralsInScene)
        {
            go.GetComponentInChildren<Outline>().ApplyOutlineColourInput(colourPicker.color);
        }
    }

    private void Update()
    {
        SetOutlineColour();
    }

}
