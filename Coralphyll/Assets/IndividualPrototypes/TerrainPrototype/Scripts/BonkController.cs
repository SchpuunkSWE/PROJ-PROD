using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using static Audio_Events;

public class BonkController : MonoBehaviour
{
    bool overlapping;

    AudioSource audioSource;
    public AudioClip bonk1;

    public GameObject indicator;

    private GameObject Thing1;


    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    private void Awake()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
    }

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();

        overlapping = false;
        Debug.Log("Enter");

        audioSource.PlayOneShot(bonk1);

        indicator.SetActive(false);

        Thing1 = GameObject.FindGameObjectWithTag("Player");


    }

    void Update()
    {
        if(overlapping)
        {
            Debug.Log("START VIBRATE");
            GamePad.SetVibration(playerIndex, .1f, .1f);
            AkSoundEngine.PostEvent("FishEat", gameObject);
        }

        if(!overlapping)
        {
            GamePad.SetVibration(playerIndex, .0f, .0f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //Debug.LogError("Start");
        if (other.gameObject.layer == LayerMask.NameToLayer("Collidable"))
        {
            overlapping = true;
            //Debug.Log("Enter");

            indicator.SetActive(true);
            audioSource.PlayOneShot(bonk1);
        }
        //else
            //Debug.Log(other.gameObject.layer);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collidable"))
        {
            overlapping = false;
           // Debug.Log("Enter FALSE");
            indicator.SetActive(false);
        }
    }

   // private void OnCollisionEnter(Collision collision)
   // {
        //if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Collidable"))
       // {
    //        Debug.Log("Collided");
        //}
   // }

  //  private void OnCollisionExit(Collision collision)
   // {
   //     Debug.Log("Left Collided");
   // }
}
