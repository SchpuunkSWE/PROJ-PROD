using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using XInputDotNetPure;
using static Audio_Events;

public class BonkController : MonoBehaviour
{
    bool overlapping;

    public GameObject indicator;


    //PlayerIndex playerIndex;


    private void Awake()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
    }

    void Start()
    {

        overlapping = false;

        indicator.SetActive(false);

    }

    void Update()
    {
        if(overlapping)
        {
           // GamePad.SetVibration(playerIndex, .1f, .1f);
            AkSoundEngine.PostEvent("FishEat", gameObject);
        }

        //if(!overlapping)
        //{
        //    GamePad.SetVibration(playerIndex, .0f, .0f);
        //}
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collidable"))
        {
            overlapping = true;

            indicator.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collidable"))
        {
            overlapping = false;
            indicator.SetActive(false);
        }
    }
}
