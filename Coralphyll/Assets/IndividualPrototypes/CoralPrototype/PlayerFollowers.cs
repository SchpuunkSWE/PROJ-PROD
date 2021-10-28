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
    }//N�r man har deposit:at klart m�ste followersToDeposit t�mmas igen - g�ra i korallen kanske (?)

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


//Eventuellt: �ndra fr�n lista av Follower till lista av gameobjects och n�r man beh�ver grejer i follower,
//g�r isf gamobject.getcomponent<Follower>().blabla