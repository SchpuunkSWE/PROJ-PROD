using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTargetUtil : MonoBehaviour
{
    [SerializeField]
    private List<Follower> listOfFishes = new List<Follower>();
    private List<Follower> fishesToRemove = new List<Follower>();
    [SerializeField]
    private GameObject[] arrayOfTargets; //Populate in the editor
    private NavigationArrow navArrow;

    private void Awake()
    {
        navArrow = transform.gameObject.GetComponent<NavigationArrow>();
        SelectNavArrowTarget();
    }

    public int AddToSchool(Follower fol) //Kanske döpa om (till AddTOInventory)
    {
        if(listOfFishes.Count >= arrayOfTargets.Length || listOfFishes.Contains(fol))//If the list is full or if the fish already exists in the list
        {
            SelectNavArrowTarget();
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

    public void DepositFishes()
    {
        foreach (Follower f in listOfFishes)
        {
            if (!f.gameObject.activeSelf) //If the fish is inactive...
            {
                fishesToRemove.Add(f); //... add the fish to the removal list.
            }
        }
        foreach (Follower f in fishesToRemove)
        {
            listOfFishes.Remove(f);
        }
        SelectNavArrowTarget();
    }

    //  if (f.transform.parent.childCount< 0)
    //{
    //    Debug.Log("We dont have children");
    //    f.transform.parent.gameObject.SetActive(false);
    //}
}
