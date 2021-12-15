using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIFishWheel : MonoBehaviour
{ 
    public GameObject fishHandler;
    public GameObject fishWheelPanel;



    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//Kallar på fiskobjectets script som tar emot en sträng fishcolor och ber de scriptet droppa alla röda fiskar
    public void dropFish(string fishcolor){
        //fishHandler.GetComponent(fishHandlerScript).dropFishes(fishcolor);


    }
    public void openWheel(){
        fishWheelPanel.SetActive(true);
    }



    public void exitWheel(){
        //Close panel
        fishWheelPanel.SetActive(false);

    }

    public void dropRedFish(){
        dropFish("red");
    }

    public void dropBlueFish(){
        dropFish("blue");
    }

    public void dropYellowFish(){
        dropFish("yellow");
    }




}
