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

    private GameObject boidsSystemGO;

    private Coral coral;

    private FishColour fish;


    public int AddToSchool(Follower go) //Kanske döpa om (till AddTOInventory)
    {
        if (listOfFishes.Count >= arrayOfTargets.Length || listOfFishes.Contains(go))//Om det inte finns plats eller om fisken redan finns i listan...
        {
            return -1; //returner default v�rde eftersom positionInList inte kan s�ttas till null
        }
        //Om metoden inte har returnerats...
        listOfFishes.Add(go);
        return listOfFishes.IndexOf(go);
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

            coral = other.GetComponentInParent<Coral>();
            boidsSystemGO = coral.boidsSystemGO; //GameObject of coral.

            AIController.CanFollowPlayer = false;

            TransferFish(FishColour.BLUE);
            TransferFish(FishColour.RED);
            TransferFish(FishColour.YELLOW);
            coral.GetComponent<Coral>().ReceiveFish();
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
        }

        
        fishToRemove.Clear(); //Clear the fish to remove list.
    }

    //public void TransferFish() //Use this one when we dont need to specify which colour of fish we send in
    //{
    //    BoidsSystem boidsSystem = boidsSystemGO.GetComponent<BoidsSystem>(); //The corals Boids System

    //    foreach (Follower f in listOfFishes)
    //    {
    //        if (f.GetComponent<NPCFollow>().isFollowingPlayer && f.GetColour() == fish && fishToRemove.Count < coral.fishSlotsAvailable(fish))
    //        {
    //            fishToRemove.Add(f);
    //        }

    //    }
    //    foreach (Follower f in fishToRemove)
    //    {
    //        listOfFishes.Remove(f); //Removes fishes from the list of fishes 
    //        boidsSystem.AddAgent(f.transform.gameObject); //Adds agent/fish to the agent list.
    //        f.GetComponent<NPCFollow>().isFollowingPlayer = false; //Set fish to no longer follow player.
    //        f.GetComponent<BoidsAgent>().enabled = true; //Reenable Boids Agent script on fish.
    //        f.transform.SetParent(boidsSystemGO.transform); //Adds fish as child to coral Boid System.
    //    }

    //    coral.GetComponent<Coral>().ReceiveFish();
    //    fishToRemove.Clear(); //Clear the fish to remove list.
    //}

    public void PickUpFish(GameObject player, Follower follower)
    {
        NPCFishUtil listScript = player.gameObject.GetComponent<NPCFishUtil>(); //H�mtar det andra scriptet från spelare s� vi kommer �t det.
        NPCFollow nPCFollow = follower.GetComponent<NPCFollow>();
        int positionInList = nPCFollow.PositionInList;
        positionInList = listScript.AddToSchool(follower.transform.gameObject.GetComponent<Follower>()); //L�gger till fisken till listan och returnerar platsen i listan den f�r.
        if (positionInList >= 0) //Om vi f�r tillbaka ett v�rde �ver 0... 
        {
            nPCFollow.PositionInList = positionInList;
            nPCFollow.fishTarget = listScript.GetTargetPositionObject(positionInList); //Vi s�tter fiskens target till det targetObject som har samma pos i arrayen som fisken har i sin lista.
            follower.GetComponentInParent<BoidsSystem>().RemoveAgent(follower.gameObject); //Tar bort agent från listan av agents.
            nPCFollow.isFollowingPlayer = true; //Vi s�tter fiskens status till att f�lja spelaren.
            follower.Collectable = false; //So that you can only pick up the fishes ones.
            follower.RGB.detectCollisions = false; //Turn off collision on fish.
            follower.GetComponent<BoidsAgent>().enabled = false; //Disable Boids Agent script on fish.
        }
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
        var newBoidsSystem = Instantiate(boidsSystemPrefab, transform.position, Quaternion.identity);
        BoidsSystem boidsSystem = newBoidsSystem.GetComponent<BoidsSystem>();

        foreach (Follower f in listOfFishes)
        {
            if (f.GetComponent<NPCFollow>().isFollowingPlayer)
            {
                fishToRemove.Add(f);
            }

        }
        foreach (Follower f in fishToRemove)
        {
            listOfFishes.Remove(f); //Removes fishes from the list of fishes 
            boidsSystem.AddAgent(f.transform.gameObject); //Adds agent/fish to the agent list.
            f.GetComponent<NPCFollow>().isFollowingPlayer = false; //Set fish to no longer follow player.
            f.GetComponent<BoidsAgent>().enabled = true; //Reenable Boids Agent script on fish.
            f.transform.SetParent(newBoidsSystem.transform); //Adds fish as child to the new Boids System.
            StartCoroutine(MakeFishCollectible(f));
            Debug.Log("StartCoroutine KÖRD");

            //Destroy(f.GetComponent<BoidsAgent>().owner.gameObject); //Destroy the Boidssystem that the fish has.
            //FishCounter.fishCounterInstance.RemoveSchool(f.GetComponent<BoidsAgent>().owner);
            //FishCounter.fishCounterInstance.RecountFishes = true;

            //Destroy(f.gameObject, 5);

        }
        fishToRemove.Clear(); //Clear the fish to remove list.
    }

    private IEnumerator MakeFishCollectible(Follower follower)
    {
        Debug.Log("Coroutine Waiting");
        yield return new WaitForSeconds(5f);
        Debug.Log("Coroutine started");
        follower.Collectable = true; //So that you can pick up fish again.
        follower.RGB.detectCollisions = true; //Turn on collision on fish.        
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
        Destroy(fish.gameObject);
        fishToRemove.Clear(); //Clear the fish to remove list.
    }
}

