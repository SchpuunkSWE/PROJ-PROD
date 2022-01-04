using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using XInputDotNetPure;
using static Audio_Events;

public class BonkController : MonoBehaviour
{
    bool overlapping;
    bool overlappingSide;

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
        enableTerrainSound = true;
        enableTerrainIndicator = true;

        indicator = GameObject.Find("Indicator");

        indicator.SetActive(false);

    }

    void Update()
    {
        if(overlapping && enableTerrainSound)
        {
            // GamePad.SetVibration(playerIndex, .1f, .1f);
            AkSoundEngine.PostEvent("FishEat", gameObject);
        }
        else if (overlappingSide && enableTerrainSound)
        {
            AkSoundEngine.PostEvent("NPC_DropOff", gameObject);
        }

        //if(!overlapping)
        //{
        //    GamePad.SetVibration(playerIndex, .0f, .0f);
        //}
    }

    public void switchActiveIndicator()
    {
        enableTerrainIndicator = !enableTerrainIndicator;

    }

    public void switchActiveSound()
    {

        enableTerrainSound = !enableTerrainSound;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collidable"))
        {
            overlapping = true;

            if (enableTerrainIndicator)
            {
                indicator.SetActive(true);
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


    public void SideOverlapping(bool isTouching)
    {

        if (isTouching)
        {
            overlappingSide = true;
            indicator.SetActive(true);
        }
        else
        {
            overlappingSide = false;
            indicator.SetActive(false);

        }

    }

}
