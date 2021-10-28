using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerFollowers : MonoBehaviour
{
    [SerializeField]
    private List<Follower> allfollowers;

    private List<Follower> followersToDeposit = new List<Follower>();

    public GameObject currentCoral;

    public bool nearCoral = false;

    public List<Follower> GetAllFollowers ()
    {
        return allfollowers;
    }


    //public List<Follower> GetFollowersToDeposit()
    //{
    //    return followersToDeposit;
    //}

    public void TransferFollower(Follower fish)
    {
        followersToDeposit.Add(fish);
        Debug.Log(followersToDeposit.Count);
    }

    public void DepositFish()
    {
        currentCoral.GetComponent<Coral>().ReceiveFish(followersToDeposit);
        Debug.Log("DepositFish Reached");
        followersToDeposit.Clear(); //Bring to dev/first merger


        //currentCoral.GetComponent<Coral>().ReceiveFish(allfollowers);
    }//När man har deposit:at klart måste followersToDeposit tömmas igen - göra i korallen kanske (?)

    //private void Update()
    //{
    //    if (nearCoral)
    //    {
    //        if (Input.GetKeyDown(KeyCode.M))
    //        {
    //            Debug.Log("M was pressed!");
    //            DepositFish();
    //        }
    //    }

    //} //Bring (remove from) to dev/first merger - use deposit btn instead

}


//Eventuellt: Ändra från lista av Follower till lista av gameobjects och när man behöver grejer i follower,
//gör isf gamobject.getcomponent<Follower>().blabla