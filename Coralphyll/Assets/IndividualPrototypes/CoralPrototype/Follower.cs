using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Follower : MonoBehaviour
{
    public enum Colour { RED, BLUE, YELLOW};

    [SerializeField]
    private Colour fishColour;

    [SerializeField]
    private GameObject parent;

    [SerializeField]
    private Collider col;

    public bool isClickable = false;

    public Colour GetColour()
    {
        return this.fishColour;
    }
    //private void Awake()
    //{
    //    col.enabled = false;
    //}
    //private void Update()
    //{
    //    if (isClickable)
    //    {
    //        col.enabled = true;
    //    }
    //}
                                                                                                                                                                                                                                                                                                                                                                                                                  
    private void OnMouseDown()
    {
        //Used to control whether player can add fishes to list to deposit or not
        if (isClickable)
        {
            Debug.Log(this.GetInstanceID() + " Says: I was clicked and my colour is: " + fishColour.ToString());
            //Debug.Log(this.GetInstanceID());

            //add clicked fish to followersToDeposit (see PlayerFollowers-script)
            parent.GetComponent<PlayerFollowers>().TransferFollower(this);

            isClickable = false;
        }
    }
}
