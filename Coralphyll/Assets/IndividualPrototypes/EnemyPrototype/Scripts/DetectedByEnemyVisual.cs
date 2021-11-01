using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedByEnemyVisual : MonoBehaviour
{
    public GameObject uiObject;
    // Start is called before the first frame update
    void Start()
    {
        //uiObject.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        uiObject.SetActive(true);
    }

    private void OnTriggerExit()
    {
        uiObject.SetActive(false);
    }
}
