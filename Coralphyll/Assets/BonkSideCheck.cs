using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonkSideCheck : MonoBehaviour
{
    bool overlapping;

    void Start()
    {
        overlapping = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (overlapping){
            print("OUTER THING YEP");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collidable"))
        {
            overlapping = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collidable"))
        {
            overlapping = false;

        }
    }
}


