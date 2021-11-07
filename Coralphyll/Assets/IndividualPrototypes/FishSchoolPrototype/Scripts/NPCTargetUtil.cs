using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTargetUtil : MonoBehaviour
{
    [SerializeField]
    private List<Follower> listOfFishes = new List<Follower>();
    private List<Follower> fishesToRemove = new List<Follower>();
    [SerializeField]
    private GameObject[] arrayOfTargets; //Populera i editorn

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
            GameObject boidsSystemGO = other.GetComponentInParent<Coral>().boidsSystem; //GameObject of coral.
            BoidsSystem boidsSystem = boidsSystemGO.GetComponent<BoidsSystem>();
            foreach (Follower f in listOfFishes)
            {
                if (f.GetComponent<NPCFollow>().isFollowingPlayer)
                {
                    fishesToRemove.Add(f);
                }
                
                //if(f.GetColour()) //Om fisken är av rätt färg
                //{
                //fishesToRemove.Add(f);
                //}
            }
            foreach (Follower f in fishesToRemove)
            {
                listOfFishes.Remove(f); //Removes fishes from the list of fishes
                boidsSystem.AddAgent(f.transform.gameObject); //Adds agent/fish to the agent list. 
                f.GetComponent<NPCFollow>().isFollowingPlayer = false; //Set fish to no longer follow player.
                f.GetComponent<BoidsAgent>().enabled = true; //Reenable Boids Agent script on fish.
                f.transform.SetParent(boidsSystemGO.transform); //Adds fish as child to coral Boid System.
            }

            fishesToRemove.Clear(); //Clear the fishes to remove list.
        }
    }
}
