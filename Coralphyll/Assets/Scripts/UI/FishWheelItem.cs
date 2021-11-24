using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishWheelItem : MonoBehaviour
{
    public Color hoverColor;
    public Color baseColor;
    public Image background;
    public GameObject gc;
    private GameController gameControllerSc;
    public int color;
    

    // Start is called before the first frame update
    void Start()
    {
        background.color = baseColor;

        
    }

    // Update is called once per frame
 

    public void Select()
    {
        background.color = hoverColor;
        Debug.Log("hovering over" + color);


    }

    public void DeSelect()
    {
        background.color = baseColor;

    }

    public void Clicked(){

         Debug.Log("clicked mouse!");
            //If color selected is Yellow
            if(color == 0){
                Debug.Log("I am yellow button");
                gameControllerSc = gc.GetComponent<GameController>();
                gameControllerSc.DepositYellowFishButton();
                 Debug.Log("I deposit yellow");
            }
            if(color == 1){
                Debug.Log("I am yellow button");
                gameControllerSc = gc.GetComponent<GameController>();
                gameControllerSc.PickUpYellowFishBtn();
                Debug.Log("I pick up yellow");
            }
            //If color selected is Red
            if(color == 2){
                Debug.Log("I am Red button");
                gameControllerSc = gc.GetComponent<GameController>();
                gameControllerSc.DepositRedFishButton();
                Debug.Log("I deposit Red");
               
            }
            if(color == 3){
                Debug.Log("I am Red button");
                gameControllerSc = gc.GetComponent<GameController>();
                gameControllerSc.PickUpRedFishBtn();
                Debug.Log("I pick up Red");
               
            }
            //If color selected is Blue
            if(color == 4){
                Debug.Log("I am Bluebutton");
                gameControllerSc = gc.GetComponent<GameController>();
                gameControllerSc.DepositBlueFishButton();
                Debug.Log("I deposit Blue");
            }
            if(color == 5){
                Debug.Log("I am Bluebutton");
                gameControllerSc = gc.GetComponent<GameController>();
                gameControllerSc.PickUpBlueFishBtn();
                Debug.Log("I pick up Blue");
            }

    }
}
