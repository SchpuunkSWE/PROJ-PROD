using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryAidScript : MonoBehaviour
{

    public GameObject ObjectivePanel;
    public bool ObjectivesPanelActive = false;
    //public bool ControlsPanelsActive = false;

    void Start()
    {

    }

    void Update()
    {

        //Opening the ObjectivesPanel
        if (Input.GetKeyDown(KeyCode.L))
        {
            ObjectivesPanelActive = !ObjectivesPanelActive;
            //if L Key pressed is True it will set it to false And the other way around.

            Time.timeScale = ObjectivesPanelActive ? 0 : 1;
            ObjectivePanel.SetActive(ObjectivesPanelActive); // if the booelan is true

        }


        //Opening the ControlsPanel
        /*
             if (Input.GetKeyDown(KeyCode.C))
             {

                 ControlsPanelsActive = !ControlsPanelsActive;
                 //if L Key pressed is True it will set it to false And the other way around.

                 Time.timeScale = ControlsPanelsActive ? 0:1;
                 ControlsPanel.SetActive(ControlsPanelsActive); // if the booelan is true
             }

         }*/

    }
}

