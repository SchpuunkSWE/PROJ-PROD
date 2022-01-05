using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFishUtil : MonoBehaviour
{
    [SerializeField]
    private List<Follower> listOfFishes = new List<Follower>();
    private List<Follower> fishToRemove = new List<Follower>();

    [SerializeField]
    private GameObject[] arrayOfTargets; //Populera i editorn

    [SerializeField]
    private GameObject boidsSystemPrefab; //Set in editor

    private bool runFishLogOnce = false; //Prevent fish log from running multiple times
    private bool runFirstCoralLogOnce = false; //Prevent coral log from running multiple times

    private GameObject boidsSystemGO;

    private Coral coral;

    private FishColour fish;

    private NavigationArrow navArrow;

    public GameObject[] ArrayOfTargets { get => arrayOfTargets; set => arrayOfTargets = value; }

    #region Singleton Quickversion
    public static NPCFishUtil NPCFishUtilInstance;

    private void Awake()
    {
        NPCFishUtilInstance = this;
        navArrow = transform.gameObject.GetComponent<NavigationArrow>();
    }

    #endregion

    public void LoopFollowTargets(int value)
    {
        int count = 0;
        for (int i = 0; i < arrayOfTargets.Length; i++)
        {
            if (count < value)
            {
                arrayOfTargets[i].SetActive(true);
            }
            else
            {
                arrayOfTargets[i].SetActive(false);
            }

            count++;
        }
    }
    private void Start()
    {
        SelectNavArrowTarget();
    }

    private void FixedUpdate()
    {
        SelectNavArrowTarget();
    }
    public int AddToSchool(Follower fol) //Kanske döpa om (till AddTOInventory)
    {
        if (listOfFishes.Count >= arrayOfTargets.Length || listOfFishes.Contains(fol))//If the list is full or already contains the fish...
        {
            return -1; //Return default value because positionInList cannot be set to null
        }
        //If the method has not been returned...
        listOfFishes.Add(fol); //Add fish to the list.
        return listOfFishes.IndexOf(fol); //Return the index of the fish.
    }

    public GameObject GetTargetPositionObject(int i) //Get TargetObject from array.
    {
        return arrayOfTargets[i];
    }

    public List<Follower> getListOfFishes()
    {
        return listOfFishes;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coral"))
        {
            Debug.Log("Coral Tagged");

            if (!runFirstCoralLogOnce)
            {
                Logger.LoggerInstance.CreateTextFile("#FoundFirstCoral");
                runFirstCoralLogOnce = true;
            }

            coral = other.GetComponentInParent<Coral>();
            boidsSystemGO = coral.boidsSystemGO; //GameObject of coral.

            AIController.CanFollowPlayer = false;

            TransferFish(FishColour.BLUE);
            TransferFish(FishColour.RED);
            TransferFish(FishColour.YELLOW);
            coral.ReceiveFish();

        }

        if (other.CompareTag("SafeZone"))
        {
            Debug.Log("SafeZone Tagged");
            coral = other.GetComponentInParent<Coral>();
            boidsSystemGO = coral.boidsSystemGO; //GameObject of SafeZone.
            AIController.CanFollowPlayer = false;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Coral"))
        {
            AIController.CanFollowPlayer = true;

        }

        if (other.CompareTag("SafeZone"))
        {
            AIController.CanFollowPlayer = true;
        }
    }
    public void TransferFish(FishColour fishColour)
    {
        BoidsSystem boidsSystem = boidsSystemGO.GetComponent<BoidsSystem>(); //The corals Boids System

        foreach (Follower f in listOfFishes)
        {
            if (f.GetComponent<NPCFollow>().isFollowingPlayer && f.GetColour() == fishColour && fishToRemove.Count < coral.fishSlotsAvailable(fishColour))
            {
                fishToRemove.Add(f);
            } //else if (f.GetComponent<NPCFollow>().isFollowingPlayer && !coral.Completable && f.GetColour() == fishColour) //Add fish even if full. remove if safezones should have a limit(obs dont forget to remove coral.Completable in above aswell)
            //{
            //    fishToRemove.Add(f);
            //}
        }
        foreach (Follower f in fishToRemove)
        {
            listOfFishes.Remove(f); //Removes fishes from the list of fishes 
            boidsSystem.AddAgent(f.transform.gameObject); //Adds agent/fish to the agent list.
            f.GetComponent<NPCFollow>().isFollowingPlayer = false; //Set fish to no longer follow player.
            f.GetComponent<BoidsAgent>().enabled = true; //Reenable Boids Agent script on fish.
            f.transform.SetParent(boidsSystemGO.transform); //Adds fish as child to coral Boid System.
            f.transform.gameObject.tag = "Untagged"; //Changes the tag of the fish to Untagged to avoid being a target for the arrow
        }
        fishToRemove.Clear(); //Clear the fish to remove list.       
        if (FishCounter.fishCounterInstance != null)
        {
            FishCounter.fishCounterInstance.RecountFishes = true;
        }

        UpdateTargetPoints();
    }

    public bool PickUpFish(Follower follower)
    {
        NPCFollow nPCFollow = follower.GetComponent<NPCFollow>();
        BoidsSystem boidsSystem = follower.GetComponentInParent<BoidsSystem>(); //Retrieves the Boids System to which the fish is a child.
        int positionInList = nPCFollow.PositionInList;
        positionInList = AddToSchool(follower.transform.gameObject.GetComponent<Follower>()); //Adds the fish to the list and returns the place in the list it receives.
        if (positionInList >= 0) //If we get back a value above 0 ...
        {
            nPCFollow.PositionInList = positionInList;
            nPCFollow.fishTarget = GetTargetPositionObject(positionInList); //We set the fish's target to the targetObject that has the same position in the array as the fish has in its list.
            boidsSystem.RemoveAgent(follower.gameObject); //Removes agent from the list of agents.
            follower.transform.SetParent(null);
            nPCFollow.isFollowingPlayer = true; //We set the status of the fish to follow the player.
            follower.Collectable = false; //So that you can only pick up the fishes ones.
            follower.RGB.detectCollisions = false; //Turn off collision on fish.
            follower.GetComponent<BoidsAgent>().enabled = false; //Disable Boids Agent script on fish.
            //follower.transform.gameObject.tag = "Untagged"; //Changes the tag of the fish to Untagged to avoid being a target for the arrow

            if (!runFishLogOnce)
            {
                Logger.LoggerInstance.CreateTextFile("#FirstFishPickedUp");
                runFishLogOnce = true;
            }

            return true;
        }
        return false;
    }

    public void FindAndPickUpFish(FishColour fishColour)
    {
        BoidsSystem boidsSystem = boidsSystemGO.GetComponent<BoidsSystem>(); //The corals Boids System
        List<Follower> toRemoveFromSafezone = new List<Follower>(); //Made a new list for fish to remove from the safezone
        Debug.Log(toRemoveFromSafezone);
        foreach (GameObject go in boidsSystem.agents)
        {
            Follower f = go.GetComponent<Follower>();
            if (f.GetColour() == fishColour && (listOfFishes.Count < arrayOfTargets.Length || listOfFishes.Contains(f)))
            {
                toRemoveFromSafezone.Add(f);
                Debug.Log("Added fish");
                Debug.Log(toRemoveFromSafezone);
            }
        }
        foreach (Follower f in toRemoveFromSafezone)
        {
            Debug.Log("Picking up fish");
            PickUpFish(f); //Reuse the method where we pick up fish.
            coral.UpdateProgress(); //Update the UI.

        }

    }

    public void DropFish()
    {
        if (listOfFishes.Count > 0)
        {
            var newBoidsSystem = Instantiate(boidsSystemPrefab, transform.position, Quaternion.identity);
            BoidsSystem boidsSystem = newBoidsSystem.GetComponent<BoidsSystem>();

            if (FishCounter.fishCounterInstance != null)
            {
                FishCounter.fishCounterInstance.AddSchool(boidsSystem);
            }

            foreach (Follower f in listOfFishes)
            {
                if (f.GetComponent<NPCFollow>().isFollowingPlayer)
                {
                    fishToRemove.Add(f);
                }

            }
            foreach (Follower f in fishToRemove)
            {
                NPCFollow nPCFollow = f.GetComponent<NPCFollow>();
                listOfFishes.Remove(f); //Removes fish from the list of fishes 
                boidsSystem.AddAgent(f.transform.gameObject); //Adds agent/fish to the agent list.
                nPCFollow.isFollowingPlayer = false; //Set fish to no longer follow player.
                nPCFollow.fishTarget = null;
                f.GetComponent<BoidsAgent>().enabled = true; //Reenable Boids Agent script on fish.
                f.transform.SetParent(newBoidsSystem.transform); //Adds fish as child to the new Boids System.
                StartCoroutine(MakeFishCollectible(f));
                Debug.Log("StartCoroutine KÖRD");
            }
            fishToRemove.Clear(); //Clear the fish to remove list.
        }
    }

    private IEnumerator MakeFishCollectible(Follower follower)
    {
        Debug.Log("Coroutine Waiting");
        yield return new WaitForSeconds(5f);
        Debug.Log("Coroutine started");
        follower.Collectable = true; //So that you can pick up fish again.
        follower.RGB.detectCollisions = true; //Turn on collision on fish.      
        follower.transform.gameObject.tag = "NPCFish"; //Changes the tag of the fish back to NPCFish so it can be a target for the arrow
    }

    public void KillFish()
    {
        foreach (Follower f in listOfFishes)
        {
            if (f.GetComponent<NPCFollow>().isFollowingPlayer)
            {
                fishToRemove.Add(f);
            }
        }
        Follower fish = fishToRemove[0];
        listOfFishes.Remove(fish);

        //Destroy(fish.gameObject);
        fish.gameObject.SetActive(false); //M
        ObjectPooler.poolerInstance.poolDictionary[fish.GetColour().ToString()].Enqueue(fish.gameObject);

        fishToRemove.Clear(); //Clear the fish to remove list.
        FishCounter.fishCounterInstance.RecountFishes = true;
        fish.Collectable = true;
        fish.GetComponent<NPCFollow>().isFollowingPlayer = false;
        fish.GetComponent<NPCFollow>().fishTarget = null;
        fish.GetComponent<BoidsAgent>().enabled = true; //Disable Boids Agent script on fish.
        fish.GetComponent<BoidsAgent>().owner = null;
        fish.RGB.detectCollisions = true; //Turn on collision on fish.
        fish.transform.SetParent(null); //Sets parent to null

        UpdateTargetPoints();
    }

    public void KillAllFish()
    {
        if (listOfFishes.Count > 0)
        {
            foreach (Follower f in listOfFishes)
            {
                if (f.GetComponent<NPCFollow>().isFollowingPlayer)
                {
                    fishToRemove.Add(f);
                }
            }

            foreach (Follower f in fishToRemove)
            {
                listOfFishes.Remove(f);
                //Destroy(f.gameObject);
                f.gameObject.SetActive(false);
                f.GetComponent<NPCFollow>().isFollowingPlayer = false;
                f.GetComponent<NPCFollow>().fishTarget = null;
                f.GetComponent<BoidsAgent>().enabled = true; //Disable Boids Agent script on fish.
                f.GetComponent<BoidsAgent>().owner = null;
                f.Collectable = true;
                f.RGB.detectCollisions = true; //Turn off collision on fish.
                f.transform.SetParent(null); //Sets parent to null
            }

            fishToRemove.Clear(); //Clear the fish to remove list.
            FishCounter.fishCounterInstance.RecountFishes = true;
        }
    }

    private void CheckFishColour()
    {
        List<FishColour> fishColours = new List<FishColour>();
        string plannedTarget = "NPCFish"; //Default tag.

        foreach (Follower f in listOfFishes)
        {
            if (f.GetComponent<NPCFollow>().isFollowingPlayer && !fishColours.Contains(f.GetColour())) //Checks if fish is following player and if the fish colour already exists in fishColours list.
            {
                fishColours.Add(f.GetColour()); //Adds the fish colour to the list.
            }
        }

        foreach (FishColour fishColour in fishColours)
        {
            switch (fishColour)
            {
                case FishColour.YELLOW:
                    if (GameObject.FindGameObjectWithTag("YellowFishTag") != null) //Check so that the tag exists. 
                    {
                        plannedTarget = "YellowFishTag"; //sets plannedTarget to YellowFishTag. 
                    }
                    else
                    {
                        navArrow.IgnoreYellow(true);
                    }
                    break;
                case FishColour.RED:
                    if (GameObject.FindGameObjectWithTag("RedFishTag") != null)
                    {
                        plannedTarget = "RedFishTag";
                    }
                    else
                    {
                        navArrow.IgnoreRed(true);
                    }
                    break;
                case FishColour.BLUE:
                    if (GameObject.FindGameObjectWithTag("BlueFishTag") != null)
                    {
                        plannedTarget = "BlueFishTag";
                    }
                    else
                    {
                        navArrow.IgnoreBlue(true);
                    }
                    break;
            }
        }
        navArrow.SetTargetTag(plannedTarget); //Set the tag that the arrow should point at to plannedTarget.
    }
    private void SelectNavArrowTarget()
    {
        if (navArrow == null)
        {
            return;
        }

        if (GameController.Instance.IslevelCompleted)// If the level is completed...
        {
            navArrow.SetTargetTag("Exit"); //...Set the tag that the arrow should point at to Exit.
            return;
        }

        if (listOfFishes.Count < 1) // If the list contains less than 1 fish...
        {
            navArrow.SetTargetTag("NPCFish"); //...Set the tag that the arrow should point at to NPCFish.
            return;
        }

        CheckFishColour(); //Otherwise run the CheckFishColour method.
        //navArrow.SetTargetTag("Coral"); //Otherwise set tag to coral.
    }

    private void UpdateTargetPoints()
    {
        foreach (Follower f in listOfFishes)
        {
            NPCFollow nPCFollow = f.GetComponent<NPCFollow>();
            //int posInList = listOfFishes.IndexOf(f); //Get the index of the fish in listOfFishes. 
            //nPCFollow.PositionInList = posInList; //Set fish pos in list. 
            nPCFollow.fishTarget = GetTargetPositionObject(listOfFishes.IndexOf(f)); //Change fish target so that it's the same as it's index in list. 
        }
    }

}


