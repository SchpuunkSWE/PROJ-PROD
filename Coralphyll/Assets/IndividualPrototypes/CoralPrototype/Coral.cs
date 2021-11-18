using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coral : MonoBehaviour
{
    //Tweak how many fish of each colour the coral needs in inspector
    [SerializeField]

    private int thisCoralNr;
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
    private GameController gameController;
    public UI_GlobalProgression gp;

    [SerializeField]
    private ParticleSystem CompletedParticles;

    [SerializeField]
    private ParticleSystem IncompletedParticles;

    [SerializeField]
    private bool complete = false;

    [SerializeField]
    private bool completable = false; //Set in inspector for Corals that can be completed.(Dont check for safezones)

    [SerializeField]
    private bool isSafezone = false; //Set/check in inspector for Safezones(Dont check for Corals)
    public bool IsSafezone { get => isSafezone; }

    [SerializeField]
    private GameObject spawnableDecor;

    public bool Completable { get => completable; }


    public GameObject boidsSystemGO;

    private void Awake()
    {
        //gameController = GameObject.FindGameObjectWithTag("GC").GetComponent<GameController>(); - try this if u can't set it in the inspector for some reason
        yellowFishesAmount = 0;
        redFishesAmount = 0;
        blueFishesAmount = 0;

        mRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        //SetUITexts();
    }
    private void SetUITexts()
    {
       // yellowFishesText.text = yellowBaseTxt + yellowFishesAmount + "/" + yellowFishesNeeded;
       // redFishesText.text = redBaseTxt + redFishesAmount + "/" + redFishesNeeded;
      //  blueFishesText.text = blueBaseTxt + blueFishesAmount + "/" + blueFishesNeeded;
    }

    private void GiveGlobalProgression()
    {
        gp.GetComponent<UI_GlobalProgression>().setGlobalProgression(thisCoralNr,0,yellowFishesAmount,yellowFishesNeeded);
        gp.GetComponent<UI_GlobalProgression>().setGlobalProgression(thisCoralNr,1,redFishesAmount,redFishesNeeded);
        gp.GetComponent<UI_GlobalProgression>().setGlobalProgression(thisCoralNr,2,blueFishesAmount,blueFishesNeeded);
        

    }

    public void ReceiveFish() 
    {
        Debug.Log("ReceiveFish Reached");
        //foreach (Follower fish in fishes) //Counter for fish recieved.(We have a better counter below)
        //{
        //    switch (fish.GetColour())
        //    {
        //        case FishColour.YELLOW:
        //            yellowFishesAmount++;
        //            break;
        //        case FishColour.RED:
        //                redFishesAmount++;
        //            break;
        //        case FishColour.BLUE:
        //                blueFishesAmount++;
        //            break;
        //    }
        //}
        Debug.Log(yellowFishesAmount + ", " + redFishesAmount + ", " + blueFishesAmount);

        //call some display-method
        UpdateProgress();

        //"Ta bort" fiskarna fr�n spelarens lista 
        //foreach (Follower fish in fishes)
        //{
        //    fish.gameObject.SetActive(false);
        //    Debug.Log("Hid fish " + fish.GetInstanceID());
        //}

        //Check completion
        CheckProgress();
    }

    public void UpdateProgress()
    {
        blueFishesAmount = CountFish(FishColour.BLUE);
        yellowFishesAmount = CountFish(FishColour.YELLOW);
        redFishesAmount = CountFish(FishColour.RED);
        //SetUITexts();
        GiveGlobalProgression();

    }

    private void CheckProgress()
    {
        //�f all different colour-needs are met, coral is "complete"
        if (completable && ((yellowFishesAmount >= yellowFishesNeeded) && (redFishesAmount >= redFishesNeeded) && (blueFishesAmount >= blueFishesNeeded)))
        {
            complete = true;

            //Set CheckPoint
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);

            //Increment number of completed corals in GameController
            gameController.SetCompletedCoralAmount();

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

        IncompletedParticles.Stop();

        spawnableDecor.SetActive(true);
    }

    public int fishSlotsAvailable(FishColour fishColour) //Calculates remaining slots for a specific fish colour.
    {
        switch (fishColour)
        {
            case FishColour.YELLOW:
                return yellowFishesNeeded - yellowFishesAmount;
            case FishColour.RED:
                return redFishesNeeded - redFishesAmount;
            case FishColour.BLUE:
                return blueFishesNeeded - blueFishesAmount;
            default:
                return 0;
        }
    }

    private int CountFish(FishColour fishColour)  //A counter that counts the fish/agents in the gamobjects Boids System and returns the value
    {
        BoidsSystem boidsSystem = boidsSystemGO.GetComponent<BoidsSystem>();
        int count = 0;
        foreach (GameObject go in boidsSystem.agents)
        {
            Follower f = go.GetComponent<Follower>();
            
            if(f.GetColour() == fishColour)
            {
                count++;
            }
        }

        return count;
    }
}
