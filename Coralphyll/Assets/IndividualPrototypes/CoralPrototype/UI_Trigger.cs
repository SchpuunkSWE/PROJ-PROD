using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Trigger : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    private GameObject myCoral;

    private void Awake()
    {
        panel.SetActive(false);
        myCoral = gameObject.transform.parent.gameObject; //Fetch the parent coral gameobject of this gameobject (aka the coral which this trigger is attached to)
    }

    private void OnTriggerEnter(Collider other)
    {


        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerFollowers>().nearCoral = true;
            other.gameObject.GetComponent<PlayerFollowers>().currentCoral = myCoral;
            //Activate Coral UI Panel
            panel.SetActive(true);

            //Fetch all player's followers
            List<Follower> playerFollowers = other.GetComponent<NPCTargetUtil>().getListOfFishes();

            Debug.Log("Trigger Entered!");

            //Make all player's followers clickable
            setClickable(playerFollowers);

        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerFollowers>().nearCoral = false;
            panel.SetActive(false);
            //Debug.Log("Trigger Exited!");
            //Sätt även spelarens fiskar till non-clickable
            setClickable(other.GetComponent<NPCTargetUtil>().getListOfFishes());
        }
    }

    private void setClickable(List<Follower> followers)
    {     
        //Set every fish in the players followers to clickable
        foreach(Follower fish in followers)
        {
            if (!fish.isClickable)
            {
                fish.isClickable = true;
                Debug.Log("I was made clickable!");
            }
            else
            {
                fish.isClickable = false;
                Debug.Log("I was made non-clickable!");
            }
            //fish.isClickable = true;
            //Debug.Log(fish.GetInstanceID()+ " Says: I was made clickable!");
        }
    }

}
