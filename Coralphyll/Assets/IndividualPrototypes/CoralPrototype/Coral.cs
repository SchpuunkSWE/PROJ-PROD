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

    private string yellowBaseTxt = "Yellow Fishes: ";
    private string redBaseTxt = "Red Fishes: ";
    private string blueBaseTxt = "Blue Fishes: ";


    private bool complete = false;

    private void Awake()
    {
        yellowFishesAmount = 0;
        redFishesAmount = 0;
        blueFishesAmount = 0;
    }

    private void Start()
    {
        SetUITexts();
    }
    private void SetUITexts()
    {
        yellowFishesText.text = yellowBaseTxt + yellowFishesAmount + "/" + yellowFishesNeeded;
        redFishesText.text = redBaseTxt + redFishesAmount + "/" + redFishesNeeded;
        blueFishesText.text = blueBaseTxt + blueFishesAmount + "/" + blueFishesNeeded;
    }

    public void ReceiveFish(List<Follower> fishes) //Take fish-object later ?
    {
        Debug.Log("ReceiveFish Reached");
        string fishColour;
        foreach (Follower fish in fishes) 
        {
            fishColour = fish.GetColour();

            switch (fishColour)
            {
                case "yellow":
                case "Yellow":
                    yellowFishesAmount++;
                    break;
                case "red":
                case "Red":
                    redFishesAmount++;
                    break;
                default:
                    blueFishesAmount++;
                    break;
            }
        }
        Debug.Log(yellowFishesAmount + ", " + redFishesAmount + ", " + blueFishesAmount);

        //call some display-method
        UpdateProgress();

        //"Ta bort" fiskarna fr�n spelarens lista 
        foreach (Follower fish in fishes)
        {
            fish.gameObject.SetActive(false);
            Debug.Log("Hid fish " + fish.GetInstanceID());
        }

        //Check completion
        CheckProgress();
    }

    private void UpdateProgress()
    {
        //update yellow bar
        //update red bar
        //update blue bar
        SetUITexts();

    }

    private void CheckProgress()
    {
        //�f all different colour-needs are met, coral is "complete"
        if((yellowFishesAmount == yellowFishesNeeded) && (redFishesAmount == redFishesNeeded) && (blueFishesAmount == blueFishesNeeded))
        {
            complete = true;
            SpreadColour();
        }
    }

    private void SpreadColour()
    {
        // Spread colour/Increase saturation
        Debug.Log("Spreading Colour!");
    }


}
