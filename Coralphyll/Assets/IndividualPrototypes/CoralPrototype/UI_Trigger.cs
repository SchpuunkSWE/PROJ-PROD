using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Trigger : MonoBehaviour
{
    [SerializeField]
    private GameObject coralPanel; //Set in inspector

    [SerializeField]
    private GameObject inGameCanvas;

    [SerializeField]
    private GameObject safezonePanel; //Set in inspector

    private GameObject myCoral;
    private bool uiOpened;
    //public GameObject fishWheelPanel;
    //public GameObject fishWheelButtonPanel;

    private void Awake()
    {
        coralPanel.SetActive(false);
        safezonePanel.SetActive(false);
        //fishWheelPanel.SetActive(false);
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
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.lockState = CursorLockMode.None;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                uiOpened = coralPanel.activeSelf;
                coralPanel.SetActive(true); 

                //...Otherwise activate UI for coral
                //fishWheelPanel.SetActive(true);
                //fishWheelButtonPanel.SetActive(true);
                //fishWheelPanel.GetComponent<FishWheel>().panelEnabled= true;
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

            if (myCoral.GetComponent<Coral>().IsSafezone) //If the gamobject is checked as a safezone...
            {
                safezonePanel.SetActive(false); //... Activate the UI for the safezone...
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            if(!uiOpened){
               coralPanel.SetActive(false); 
            }
            
            inGameCanvas.GetComponent<UI_GlobalProgression>().setDefaultCoralImageColor();
            //fishWheelPanel.SetActive(false);
            //fishWheelPanel.GetComponent<FishWheel>().exitHovering = true;
            //fishWheelPanel.GetComponent<FishWheel>().panelEnabled= false;
            //Debug.Log("Trigger Exited!");
            //S�tt �ven spelarens fiskar till non-clickable
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
