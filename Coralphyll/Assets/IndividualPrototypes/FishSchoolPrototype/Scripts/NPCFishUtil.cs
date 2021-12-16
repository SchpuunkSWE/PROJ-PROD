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
        for(int i = 0; i < arrayOfTargets.Length; i++)
        {
            if(count < value)
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
        if (listOfFishes.Count >= arrayOfTargets.Length || listOfFishes.Contains(fol))//Om det inte finns plats eller om fisken redan finns i listan...
        {
            return -1; //returner default v�rde eftersom positionInList inte kan s�ttas till null
        }
        //Om metoden inte har returnerats...
        listOfFishes.Add(fol);
        return listOfFishes.IndexOf(fol);
    }

    public GameObject GetTargetPositionObject(int i) //H�mtar TargetObject fr�n array
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
        FishCounter.fishCounterInstance.RecountFishes = true;
    }

    public bool PickUpFish(GameObject player, Follower follower)
    {
        NPCFishUtil listScript = player.gameObject.GetComponent<NPCFishUtil>(); //H�mtar det andra scriptet från spelare s� vi kommer �t det.
        NPCFollow nPCFollow = follower.GetComponent<NPCFollow>();
        BoidsSystem boidsSystem = follower.GetComponentInParent<BoidsSystem>(); //Hämtar Boids Systemet som fisken är child till.
        int positionInList = nPCFollow.PositionInList;
        positionInList = listScript.AddToSchool(follower.transform.gameObject.GetComponent<Follower>()); //L�gger till fisken till listan och returnerar platsen i listan den f�r.
        if (positionInList >= 0) //Om vi f�r tillbaka ett v�rde �ver 0... 
        {
            nPCFollow.PositionInList = positionInList;
            nPCFollow.fishTarget = listScript.GetTargetPositionObject(positionInList); //Vi s�tter fiskens target till det targetObject som har samma pos i arrayen som fisken har i sin lista.
            boidsSystem.RemoveAgent(follower.gameObject); //Tar bort agent från listan av agents.
            follower.transform.SetParent(null);
            nPCFollow.isFollowingPlayer = true; //Vi s�tter fiskens status till att f�lja spelaren.
            follower.Collectable = false; //So that you can only pick up the fishes ones.
            follower.RGB.detectCollisions = false; //Turn off collision on fish.
            follower.GetComponent<BoidsAgent>().enabled = false; //Disable Boids Agent script on fish.

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
            PickUpFish(gameObject, f); //Reuse the method where we pick up fish with the player
            coral.UpdateProgress(); //Update the UI

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
                listOfFishes.Remove(f); //Removes fishes from the list of fishes 
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
        fish.gameObject.SetActive(false);
        fishToRemove.Clear(); //Clear the fish to remove list.
        FishCounter.fishCounterInstance.RecountFishes = true;
        fish.Collectable = true;
        fish.GetComponent<NPCFollow>().isFollowingPlayer = false;
        fish.GetComponent<NPCFollow>().fishTarget = null;
        fish.GetComponent<BoidsAgent>().enabled = true; //Disable Boids Agent script on fish.
        fish.GetComponent<BoidsAgent>().owner = null;
        fish.RGB.detectCollisions = true; //Turn on collision on fish.
        fish.transform.SetParent(null); //Sets parent to null
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

        navArrow.SetTargetTag("Coral"); //Otherwise set tag to coral.
    }
}


