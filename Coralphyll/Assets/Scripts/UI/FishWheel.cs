using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FishWheel : MonoBehaviour
{
    public Vector2 normalisedMousePosition;
    public GameObject exitButton;
    public GameObject FishWheelPanel;
    public float currentAngle;
    public float offsetAngle;
    public int selection;
    private int previousSelection;
    public float exitArea;
    public float exitRadius;
    

    

   

    public GameObject[] menuItems;

    private FishWheelItem itemSc;
    private FishWheelItem previousItemSc;

    public bool exitHovering;
    public bool panelEnabled;


    // Start is called before the first frame update
    void Start()
    {
       exitHovering = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(panelEnabled)
        {
            Debug.Log("panel is enabled");
            //make the 0 position in the middle off the screen
            //ändra något med att dela först. för nu är den baserad på upplösningen.
            normalisedMousePosition = new Vector2(Input.mousePosition.x - Screen.width/2, Input.mousePosition.y - Screen.height/2);
            // calculate current angle from center of the screen
            currentAngle = Mathf.Atan2(normalisedMousePosition.y, normalisedMousePosition.x)*Mathf.Rad2Deg;
            currentAngle = (currentAngle+360 + offsetAngle)%360;
            selection = (int) currentAngle/120;

            // om x^2 + y^2 är mindre än exit radius ^2 ska exit väljas. 
            if(normalisedMousePosition.x * normalisedMousePosition.x + normalisedMousePosition.y * normalisedMousePosition.y >= exitRadius * exitRadius)
            {
                exitHovering = false;
                
                if(selection != previousSelection) {
                previousItemSc = menuItems[previousSelection].GetComponent<FishWheelItem>();
                previousItemSc.DeSelect();
                previousSelection = selection;
                itemSc = menuItems[selection].GetComponent<FishWheelItem>();
                itemSc.Select();

                }
                else{
                    // fixa så att exitknappen till previous
                    //fixa så att  exitknappen ljus
                    // fixa så att så att de andra deselectas
            
        
                    
                    previousItemSc.DeSelect();

                }
            } else{
               // previousItemSc = menuItems[previousSelection].GetComponent<FishWheelItem>();
               // previousItemSc.DeSelect();
                exitHovering = true;

            }
            // if the exit button is hovered.

            

            if(Input.GetMouseButtonDown(0)){
                itemSc = menuItems[selection].GetComponent<FishWheelItem>();
                if(exitHovering){
                    panelEnabled = false;
                    FishWheelPanel.SetActive(false);
                    

                } else 
                {
                    itemSc.Clicked();

                }
                

            }
        }
        
    }

}
