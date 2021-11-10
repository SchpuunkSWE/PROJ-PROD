using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Follower : MonoBehaviour
{
    //public enum Colour { RED, BLUE, YELLOW};

    [SerializeField]
    private FishColour fishColour;

    [SerializeField]
    private bool collectable = true;

    public bool Collectable { get => collectable; set => collectable = value; }

    [SerializeField]
    private GameObject parent;

    [SerializeField]
    private Collider col;

    public bool isClickable = false;

    private Rigidbody rgb;

    public Rigidbody RGB { get => rgb; }

    private Coral coral;

    public FishColour GetColour()
    {
        return this.fishColour;
    }

    private void Awake()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rgb = GetComponent<Rigidbody>();
        coral = GetComponent<Coral>();
    }

    IEnumerator MakeFishCollectable()
    {
        Debug.Log("Corutine started");
        collectable = true;
        rgb.detectCollisions = true;

        yield return new WaitForSeconds(0.2f);
    }

    public void StartRutine()
    {
        if (coral.IsSafezone)
        {
            StartCoroutine("MakeFishCollectable");
        }
    }
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

    //private void OnMouseDown()
    //{
    //    //Used to control whether player can add fishes to list to deposit or not
    //    if (isClickable)
    //    {
    //        Debug.Log(this.GetInstanceID() + " Says: I was clicked and my colour is: " + fishColour.ToString());
    //        //Debug.Log(this.GetInstanceID());

    //        //add clicked fish to followersToDeposit (see PlayerFollowers-script)
    //        parent.GetComponent<PlayerFollowers>().TransferFollower(this);

    //        isClickable = false;
    //    }
    //}
}
