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

    private GameObject boidsSystemGO;

    private Coral coral;

    private NavigationArrow navArrow;

    private void Awake()
    {
        if(navArrow != null)
        {
            navArrow = transform.gameObject.GetComponent<NavigationArrow>();
        }
        SelectNavArrowTarget();
    }

    public int AddToSchool(Follower fol) //Kanske döpa om (till AddTOInventory)
    {
        if(listOfFishes.Count >= arrayOfTargets.Length || listOfFishes.Contains(fol))//If the list is full or if the fish already exists in the list...
        {
            return -1; //returns default value because positionInList can not be set to null
        }
        //If the method has not been returned...
        listOfFishes.Add(fol);
        fol.transform.gameObject.tag = "Untagged"; //Changes the tag of the fish to Untagged to avoid being a target for the arrow
        SelectNavArrowTarget();
        return listOfFishes.IndexOf(fol);
    }

    public GameObject GetTargetPositionObject(int i) //Gets TargetObject from array
    {
        return arrayOfTargets[i];
    }

    public List<Follower> getListOfFishes()
    {
        return listOfFishes;
    }
    private void SelectNavArrowTarget()
    {
        if (listOfFishes.Count < arrayOfTargets.Length) // If the list is not full...
        {
            navArrow.SetTargetTag("Fish"); //... Set the tag that the arrow should point at to Fish
        }
        else
        {
            navArrow.SetTargetTag("Coral"); // Otherwise set it to coral
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coral"))
        {
            Debug.Log("Coral Tagged");
           
            coral = other.GetComponentInParent<Coral>();    
            boidsSystemGO = coral.boidsSystemGO; //GameObject of coral.
            if (coral.IsSafezone)
            {
                AIController.CanFollowPlayer = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Coral"))
        {
            coral = other.GetComponentInParent<Coral>();
            if (coral.IsSafezone)
            {
                AIController.CanFollowPlayer = true;
            }
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

        coral.GetComponent<Coral>().ReceiveFish();
        fishToRemove.Clear(); //Clear the fish to remove list.
        SelectNavArrowTarget();
    }

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
}
