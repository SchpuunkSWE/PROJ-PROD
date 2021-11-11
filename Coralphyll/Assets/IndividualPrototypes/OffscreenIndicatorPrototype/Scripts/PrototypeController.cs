using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeController : MonoBehaviour
{
    public GameObject offscreenIndicatorCanvas;
    //public GameObject alertIndicator;
    //public GameObject alertObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void ActivateBoth()
    {
        offscreenIndicatorCanvas.SetActive (true);
        alertObject.SetActive(true);
    }*/

    public void ActivateOffscreenIndicator()
    {
        offscreenIndicatorCanvas.SetActive(true);
        //alertIndicator.SetActive(false);
        //alertObject.SetActive(false);
    }

    public void DeactivateOffscreenIndicator()
    {
        offscreenIndicatorCanvas.SetActive(false);
        //alertIndicator.SetActive(true);
        //alertObject.SetActive(true);
    }
}
