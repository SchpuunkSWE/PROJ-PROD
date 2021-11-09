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

    [HideInInspector]
    public GameObject currentCoral;

    private GameObject coralBoidsSystemGO;

    private GameObject safeZoneBoidsSystemGO;

    private Coral coral;

    private SafeZone safeZone;

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
            coralBoidsSystemGO = coral.boidsSystem; //GameObject of coral.
            
        }

        if (other.CompareTag("SafeZone"))
        {
            Debug.Log("SafeZone Tagged");
            safeZone = other.GetComponent<SafeZone>();
            safeZoneBoidsSystemGO = safeZone.boidsSystem; //GameObject of safezone.
        }
    }

    public void TransferFishToCoral(FishColour fishColour)
    {
        BoidsSystem coralBoidsSystem = coralBoidsSystemGO.GetComponent<BoidsSystem>(); //The corals Boids System

        foreach (Follower f in listOfFishes)
        {
            if (f.GetComponent<NPCFollow>().isFollowingPlayer && f.GetColour() == fishColour && fishToRemove.Count < coral.fishSlotsAvailableInCoral(fishColour))
            {
                fishToRemove.Add(f); 
            }

        }
        foreach (Follower f in fishToRemove)
        {
            listOfFishes.Remove(f); //Removes fishes from the list of fishes 
            coralBoidsSystem.AddAgent(f.transform.gameObject); //Adds agent/fish to the agent list.
            f.GetComponent<NPCFollow>().isFollowingPlayer = false; //Set fish to no longer follow player.
            f.GetComponent<BoidsAgent>().enabled = true; //Reenable Boids Agent script on fish.
            f.transform.SetParent(coralBoidsSystemGO.transform); //Adds fish as child to coral Boid System.

        }
        coral.GetComponent<Coral>().CorralReceiveFish(fishToRemove);
        fishToRemove.Clear(); //Clear the fish to remove list.
    }

    public void TransferFishToSafezone(FishColour fishColour)
    {
        BoidsSystem safeZoneBoidsSystem = safeZoneBoidsSystemGO.GetComponent<BoidsSystem>(); //The SafeZones Boids System

        foreach (Follower f in listOfFishes)
        {
            if (f.GetComponent<NPCFollow>().isFollowingPlayer && f.GetColour() == fishColour && fishToRemove.Count < coral.fishSlotsAvailableInCoral(fishColour))
            {
                fishToRemove.Add(f);
            }

        }
        foreach (Follower f in fishToRemove)
        {
            listOfFishes.Remove(f); //Removes fishes from the list of fishes 
            safeZoneBoidsSystem.AddAgent(f.transform.gameObject); //Adds agent/fish to the agent list.
            f.GetComponent<NPCFollow>().isFollowingPlayer = false; //Set fish to no longer follow player.
            f.GetComponent<BoidsAgent>().enabled = true; //Reenable Boids Agent script on fish.
            f.transform.SetParent(safeZoneBoidsSystemGO.transform); //Adds fish as child to safezone Boid System.

        }
        safeZone.GetComponent<SafeZone>().SafeZoneReceiveFish(fishToRemove);
        fishToRemove.Clear(); //Clear the fish to remove list.
    }
}
