using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeZone : MonoBehaviour
{
    //Tweak how many fish of each colour the coral needs in inspector.
    [SerializeField]
    private int maxYellowFishes;
    [SerializeField]
    private int maxRedFishes;
    [SerializeField]
    private int maxBlueFishes;

    [SerializeField]
    private GameObject panel; //Set in inspector.

    public GameObject boidsSystem; //Set in inspector.

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

    private MeshRenderer mRenderer;

    private void Awake()
    {
        yellowFishesAmount = 0;
        redFishesAmount = 0;
        blueFishesAmount = 0;

        panel.SetActive(false);
    }

    private void Start()
    {
        SetUITexts();
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            //Activate Coral UI Panel
            panel.SetActive(true);

            //Fetch all player's followers
            //List<Follower> playerFollowers = other.GetComponent<NPCFishUtil>().getListOfFishes();

            Debug.Log("Trigger Entered!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            panel.SetActive(false);
            //Debug.Log("Trigger Exited!");

        }
    }
    private void SetUITexts()
    {
        yellowFishesText.text = yellowBaseTxt + yellowFishesAmount + "/" + maxYellowFishes;
        redFishesText.text = redBaseTxt + redFishesAmount + "/" + maxRedFishes;
        blueFishesText.text = blueBaseTxt + blueFishesAmount + "/" + maxBlueFishes;
    }

    public void SafeZoneReceiveFish(List<Follower> fishes) //Counter for fish recieved.
    {
        Debug.Log("ReceiveFish Reached");
        foreach (Follower fish in fishes)
        {
            switch (fish.GetColour())
            {
                case FishColour.YELLOW:
                    yellowFishesAmount++;
                    break;
                case FishColour.RED:
                    redFishesAmount++;
                    break;
                case FishColour.BLUE:
                    blueFishesAmount++;
                    break;
            }
        }
        Debug.Log(yellowFishesAmount + ", " + redFishesAmount + ", " + blueFishesAmount);

        //call some display-method
        UpdateProgressSafeZone();
    }

    private void UpdateProgressSafeZone()
    {
        SetUITexts();
    }

    public int fishSlotsAvailableInSafeZone(FishColour fishColour) //Calculates remaining slots for a specific fish colour.
    {
        switch (fishColour)
        {
            case FishColour.YELLOW:
                return maxYellowFishes - yellowFishesAmount;
            case FishColour.RED:
                return maxRedFishes - redFishesAmount;
            case FishColour.BLUE:
                return maxBlueFishes - blueFishesAmount;
            default:
                return 0;
        }
    }
}
