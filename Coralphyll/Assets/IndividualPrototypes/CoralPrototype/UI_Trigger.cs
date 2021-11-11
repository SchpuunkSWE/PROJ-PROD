using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Trigger : MonoBehaviour
{
    [SerializeField]
    private GameObject coralPanel; //Set in inspector

    [SerializeField]
    private GameObject safezonePanel; //Set in inspector

    private GameObject myCoral;

    private void Awake()
    {
        coralPanel.SetActive(false);
        safezonePanel.SetActive(false);
        myCoral = gameObject.transform.parent.gameObject; //Fetch the parent coral gameobject of this gameobject (aka the coral which this trigger is attached to)
    }

    private void OnTriggerEnter(Collider other)
    {


        if(other.tag == "Player")
        {
            //other.gameObject.GetComponent<PlayerFollowers>().nearCoral = true;
            //other.gameObject.GetComponent<PlayerFollowers>().currentCoral = myCoral;
            
            myCoral.GetComponent<Coral>().UpdateProgress();
            if (myCoral.GetComponent<Coral>().IsSafezone) //If the gamobject is checked as a safezone...
            {
                safezonePanel.SetActive(true); //... Activate the UI for the safezone...
            }
            else
            {
                coralPanel.SetActive(true); //...Otherwise activate UI for coral
            }

            Debug.Log("Trigger Entered!");

            //Make all player's followers clickable
            //setClickable(playerFollowers);

        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //other.gameObject.GetComponent<PlayerFollowers>().nearCoral = false;
            safezonePanel.SetActive(false);
            coralPanel.SetActive(false);
            //Debug.Log("Trigger Exited!");
            //Sätt även spelarens fiskar till non-clickable
            //setClickable(other.GetComponent<PlayerFollowers>().GetAllFollowers());
        }
    }

    //private void setClickable(List<Follower> followers)
    //{     
    //    //Set every fish in the players followers to clickable
    //    foreach(Follower fish in followers)
    //    {
    //        if (!fish.isClickable)
    //        {
    //            fish.isClickable = true;
    //            Debug.Log("I was made clickable!");
    //        }
    //        else
    //        {
    //            fish.isClickable = false;
    //            Debug.Log("I was made non-clickable!");
    //        }
    //        //fish.isClickable = true;
    //        //Debug.Log(fish.GetInstanceID()+ " Says: I was made clickable!");
    //    }
    //}

}
