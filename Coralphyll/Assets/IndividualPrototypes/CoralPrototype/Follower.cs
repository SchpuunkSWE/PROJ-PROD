using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Follower : MonoBehaviour
{
    [SerializeField]
    private string colour;

    [SerializeField]
    private GameObject parent;

    [SerializeField]
    private Collider col;

    public bool isClickable = false;

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public string GetColour()
    {
        return this.colour;
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
            Debug.Log(this.GetInstanceID() + " Says: I was clicked and my colour is: " + colour);
            //Debug.Log(this.GetInstanceID());

            //"Mark" fish by lowering alpha/opacity -- bring to dev/firstmerger
            Color tmp = spriteRenderer.color;
            tmp.a = 0.5f;
            spriteRenderer.color = tmp;

            //add clicked fish to followersToDeposit (see PlayerFollowers-script)
            parent.GetComponent<PlayerFollowers>().TransferFollower(this);

            

            isClickable = false; //Bring to dev/first merger
        }
    }
}
