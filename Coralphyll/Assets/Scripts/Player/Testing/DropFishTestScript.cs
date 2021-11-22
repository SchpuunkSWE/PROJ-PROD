using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFishTestScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            gameObject.GetComponent<NPCFishUtil>().DropFish();
        }

    }
}
