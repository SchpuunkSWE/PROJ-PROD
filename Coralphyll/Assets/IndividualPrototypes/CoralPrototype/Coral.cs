using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coral : MonoBehaviour
{
    //Tweak how many fish of each colour the coral needs in inspector
    [SerializeField]
    private int yellowFishesNeeded;
    [SerializeField]
    private int redFishesNeeded;
    [SerializeField]
    private int blueFishesNeeded;

    [SerializeField]
    Text yellowFishesText;
    [SerializeField]
    Text redFishesText;
    [SerializeField]
    Text blueFishesText;

    private int yellowFishesAmount;
    private int redFishesAmount;
    private int blueFishesAmount;


    private bool complete = false;

    private void Awake()
    {
        yellowFishesAmount = 0;
        redFishesAmount = 0;
        blueFishesAmount = 0;
    }

    private void Start()
    {
        yellowFishesText.text = yellowFishesText.text + yellowFishesAmount + "/" + yellowFishesNeeded;
        redFishesText.text = redFishesText.text + redFishesAmount + "/" + redFishesNeeded;
        blueFishesText.text = blueFishesText.text + blueFishesAmount + "/" + blueFishesNeeded;
    }

    private void Update()
    {
        
    }

    private void ReceiveFish(string fishColour) //Take fish-object later 
    { 
        switch (fishColour)
        {
            case "yellow":
                yellowFishesAmount++;
                break;
            case "red":
                redFishesAmount++;
                break;
            default:
                blueFishesAmount++;
                break;
        }
        ////Increase counter depending on colour of fish
        //if(fish.GetColour() == Color.yellow)
        //{
        //    yellowFishesAmount++;
        //}else if (fish.GetColour() == Color.red) {
        //    redFishesAmount++;
        //}
        //else
        //{
        //    blueFishesAmount++;
        //}


        //call some display-method
        UpdateProgress();

        //Check completion
        CheckProgress();
    }

    private void UpdateProgress()
    {
        //update yellow bar
        //update blue bar
        //update red bar
    }

    private void CheckProgress()
    {
        //Íf all different colour-needs are met, coral is "complete"
        if((yellowFishesAmount == yellowFishesNeeded) && (redFishesAmount == redFishesNeeded) && (blueFishesAmount == blueFishesNeeded))
        {
            complete = true;
            SpreadColour();
        }
    }

    private void SpreadColour()
    {
        // Spread colour/Increase saturation
    }
}
