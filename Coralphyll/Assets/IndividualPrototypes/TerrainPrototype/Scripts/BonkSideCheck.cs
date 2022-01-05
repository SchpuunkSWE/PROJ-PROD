using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonkSideCheck : MonoBehaviour
{
    bool overlapping;
    GameObject bonkCtrl;

    void Start()
    {
        overlapping = false;
        bonkCtrl = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collidable"))
        {
            overlapping = true;
            bonkCtrl.GetComponent<BonkController>().SideOverlapping(overlapping);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collidable"))
        {
            overlapping = false;
            bonkCtrl.GetComponent<BonkController>().SideOverlapping(overlapping);
        }
    }
}


