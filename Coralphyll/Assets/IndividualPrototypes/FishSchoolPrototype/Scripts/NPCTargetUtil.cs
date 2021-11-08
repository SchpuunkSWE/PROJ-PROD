using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTargetUtil : MonoBehaviour
{
    [SerializeField]
    private List<Follower> listOfFishes = new List<Follower>();
    private List<Follower> fishToRemove = new List<Follower>();
    private List<Follower> followersToDeposit = new List<Follower>();

    [SerializeField]
    private GameObject[] arrayOfTargets; //Populera i editorn

    private GameObject boidsSystemGO;

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
            boidsSystemGO = other.GetComponentInParent<Coral>().boidsSystem; //GameObject of coral.
        }
    }

    public void TransferFollower(Follower fish)
    {
        followersToDeposit.Add(fish);
        Debug.Log(followersToDeposit.Count);
    }

    public void DepositFish()
    {
        Coral currentCoral = GetComponent<Coral>();
        currentCoral.GetComponent<Coral>().ReceiveFish(followersToDeposit);
        Debug.Log("DepositFish Reached");
        followersToDeposit.Clear();
        //currentCoral.GetComponent<Coral>().ReceiveFish(allfollowers);
    }//N�r man har deposit:at klart m�ste followersToDeposit t�mmas igen - g�ra i korallen kanske (?)

    public void TransferFish(Follower.Colour colour)
    {
        BoidsSystem boidsSystem = boidsSystemGO.GetComponent<BoidsSystem>();

        foreach (Follower f in listOfFishes)
        {
            if (f.GetComponent<NPCFollow>().isFollowingPlayer && f.GetColour() == colour)
            {
                fishToRemove.Add(f);
            }

            //if(f.GetColour()) //Om fisken är av rätt färg
            //{
            //fishesToRemove.Add(f);
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
        Coral currentCoral = GetComponent<Coral>();
        currentCoral.GetComponent<Coral>().ReceiveFish(fishToRemove);
        fishToRemove.Clear(); //Clear the fish to remove list.
    }
}
