using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicateNearbyEnemy : MonoBehaviour
{
    public GameObject indicator;
    public void Start()
    {
        indicator.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            indicator.SetActive(true);
            Debug.Log("Does Something");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            indicator.SetActive(false);
        }
    }
}
