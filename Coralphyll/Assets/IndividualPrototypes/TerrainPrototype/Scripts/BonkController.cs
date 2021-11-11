using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonkController : MonoBehaviour
{
    bool overlapping;

    AudioSource audioSource;
    public AudioClip bonk1;

    public GameObject indicator;


    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();

        overlapping = true;
        Debug.Log("Enter");

        audioSource.PlayOneShot(bonk1);

        indicator.SetActive(false);
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.LogError("Start");
        if (other.gameObject.layer == LayerMask.NameToLayer("Collidable"))
        {
            overlapping = true;
            Debug.Log("Enter");

            indicator.SetActive(true);
            audioSource.PlayOneShot(bonk1);
        }
        else
            Debug.Log(other.gameObject.layer);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collidable"))
        {
            overlapping = false;
            Debug.Log("Enter FALSE");
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
