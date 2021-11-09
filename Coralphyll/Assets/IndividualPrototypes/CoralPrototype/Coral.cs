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

    private MeshRenderer mRenderer;

    [SerializeField]
    private ParticleSystem CompletedParticles;

    [SerializeField]
    private bool complete = false;

    public GameObject boidsSystem;

    private void Awake()
    {
        yellowFishesAmount = 0;
        redFishesAmount = 0;
        blueFishesAmount = 0;

        mRenderer = gameObject.GetComponent<MeshRenderer>();
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

    public void CorralReceiveFish(List<Follower> fishes) //Counter for fish recieved.
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
        UpdateCoralProgress();

        //"Ta bort" fiskarna fr�n spelarens lista 
        //foreach (Follower fish in fishes)
        //{
        //    fish.gameObject.SetActive(false);
        //    Debug.Log("Hid fish " + fish.GetInstanceID());
        //}

        //Check completion
        CheckProgress();
    }

    private void UpdateCoralProgress()
    {
        //update yellow bar
        //update red bar
        //update blue bar
        SetUITexts();

    }

    private void CheckProgress()
    {
        //�f all different colour-needs are met, coral is "complete"
        if ((yellowFishesAmount >= yellowFishesNeeded) && (redFishesAmount >= redFishesNeeded) && (blueFishesAmount >= blueFishesNeeded))
        {
            complete = true;
            SpreadColour();
        }
    }

    private void SpreadColour()
    {
        // Spread colour/Increase saturation
        Debug.Log("Spreading Colour!");
        Debug.Log(mRenderer.material.name);

        Color newCoralColour = new Color(59, 250, 0);

        mRenderer.material.SetColor("_BaseColor", newCoralColour);

        Instantiate(CompletedParticles, gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
    }

    //public void DepositFish(Follower.Colour colour)
    //{       
    //    GameObject player = GameObject.FindGameObjectWithTag("Player");
    //    NPCTargetUtil nPCTargetUtil = player.GetComponent<NPCTargetUtil>();
    //    nPCTargetUtil.TransferFish(colour);
    //}

    public int fishSlotsAvailableInCoral(FishColour fishColour) //Calculates remaining slots for a specific fish colour.
    {
        switch (fishColour)
        {
            case FishColour.YELLOW:
                return yellowFishesNeeded - yellowFishesAmount;
            case FishColour.RED:
                return redFishesNeeded - redFishesAmount ;
            case FishColour.BLUE:
                return blueFishesNeeded - blueFishesAmount;
            default:
                return 0;
        }
    }
}
