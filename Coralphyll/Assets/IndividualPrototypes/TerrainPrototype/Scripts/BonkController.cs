using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using XInputDotNetPure;
using static Audio_Events;

public class BonkController : MonoBehaviour
{
    bool overlapping;

    private GameObject indicator;

    private bool enableTerrainSound;
    private bool enableTerrainIndicator;

    //PlayerIndex playerIndex;


    private void Awake()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
    }

    void Start()
    {

        overlapping = false;
        enableTerrainSound = false;
        enableTerrainIndicator = false;

        indicator = GameObject.Find("Indicator");

        indicator.SetActive(false);

    }

    void Update()
    {
        if(overlapping && enableTerrainSound)
        {
            print("EEEEEEEEEEEEEEEEEEEEEEEEEE");
            // GamePad.SetVibration(playerIndex, .1f, .1f);
            AkSoundEngine.PostEvent("FishEat", gameObject);
        }

        //if(!overlapping)
        //{
        //    GamePad.SetVibration(playerIndex, .0f, .0f);
        //}
    }

    public void switchActiveIndicator()
    {
        print("C");
        enableTerrainIndicator = !enableTerrainIndicator;
        if (enableTerrainIndicator)
        {
            print("enableTerrainIndicator");
        }
        if (!enableTerrainIndicator)
        {
            print("NOT enableTerrainIndicator");
        }
    }

    public void switchActiveSound()
    {
        print("D");
        enableTerrainSound = !enableTerrainSound;
        if (enableTerrainSound)
        {
            print("enableTerrainSound");
        }
        if (!enableTerrainSound)
        {
            print("NOT enableTerrainSound");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collidable"))
        {
            overlapping = true;

            if (enableTerrainIndicator)
            {
                indicator.SetActive(true);
                print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            }
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
