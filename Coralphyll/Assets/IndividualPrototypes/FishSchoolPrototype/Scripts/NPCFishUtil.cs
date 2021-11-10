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

    public int AddToSchool(Follower go) //Kanske döpa om (till AddTOInventory)
    {
        if(listOfFishes.Count >= arrayOfTargets.Length || listOfFishes.Contains(go))//Om det inte finns plats eller om fisken redan finns i listan...
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
            boidsSystemGO = coral.boidsSystem; //GameObject of coral.
            
        }
    }

    public void TransferFish(FishColour fishColour)
    {
        BoidsSystem boidsSystem = boidsSystemGO.GetComponent<BoidsSystem>(); //The corals Boids System

        foreach (Follower f in listOfFishes)
        {
            if (f.GetComponent<NPCFollow>().isFollowingPlayer && coral.Completable && f.GetColour() == fishColour && fishToRemove.Count < coral.fishSlotsAvailable(fishColour))
            {
                fishToRemove.Add(f); 
            } else if (f.GetComponent<NPCFollow>().isFollowingPlayer && !coral.Completable && f.GetColour() == fishColour) //Add fish even if full. remove if safezones should have a limit(obs dont forget to remove coral.Completable in above aswell)
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
            f.transform.SetParent(boidsSystemGO.transform); //Adds fish as child to coral Boid System.

        }
        coral.GetComponent<Coral>().ReceiveFish(fishToRemove);
        fishToRemove.Clear(); //Clear the fish to remove list.
    }
}
