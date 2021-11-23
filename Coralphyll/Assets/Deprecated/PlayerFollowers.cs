using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerFollowers : MonoBehaviour
{
    [SerializeField]
    private List<Follower> allfollowers;

    private List<Follower> followersToDeposit = new List<Follower>();

    [HideInInspector]
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
        currentCoral.GetComponent<Coral>().ReceiveFish();
        Debug.Log("DepositFish Reached");
        followersToDeposit.Clear();
        //currentCoral.GetComponent<Coral>().ReceiveFish(allfollowers);
    }//N�r man har deposit:at klart m�ste followersToDeposit t�mmas igen - g�ra i korallen kanske (?)

    public void KillFish()
    {
        //specify color??
        //right now im just killing the first fish on the list
        var fishToRemove = allfollowers[0];
        Destroy(fishToRemove.gameObject);
        allfollowers.Remove(fishToRemove);
    }

    private void Update()
    {
        allfollowers = GetComponent<NPCFishUtil>().getListOfFishes();
    //    if (nearCoral)
    //    {
    //        if (Input.GetKeyDown(KeyCode.M))
    //        {
    //            Debug.Log("M was pressed!");
    //            DepositFish();
    //        }
    //    }
    }
}


//Eventuellt: �ndra fr�n lista av Follower till lista av gameobjects och n�r man beh�ver grejer i follower,
//g�r isf gamobject.getcomponent<Follower>().blabla