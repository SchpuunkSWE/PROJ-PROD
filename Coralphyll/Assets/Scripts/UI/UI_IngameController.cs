using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_IngameController : MonoBehaviour
{
    private bool informationpanelActive;

    public GameObject globalProgressionPanel;
    // Start is called before the first frame update
    void Start()
    {
        informationpanelActive = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.JoystickButton3))
        {
          openInformationPanel();

        }

        
    }
    void openInformationPanel(){
        if(!informationpanelActive) 
          {
              
              informationpanelActive = true;
              globalProgressionPanel.SetActive(true);
               
              


          } else{
              
            informationpanelActive = false;
            globalProgressionPanel.SetActive(false);
             
          }
    }
}
