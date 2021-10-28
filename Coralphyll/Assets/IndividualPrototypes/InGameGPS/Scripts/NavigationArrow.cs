using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationArrow : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow;
    [SerializeField]
    private string tagName; 

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
     
            arrow.transform.LookAt(GetClosestTarget(tagName)); //Ser till att pilen pekar mot fiskstimmet 
        //}
   
    }
    public Transform GetClosestTarget(string targetTag)
    {
        GameObject[] arrayOfTargets = GameObject.FindGameObjectsWithTag(targetTag); 
        Transform closestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in arrayOfTargets)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                closestTarget = potentialTarget.transform;
            }
        }
        return closestTarget;
    }

    public void SetTargetTag(string s)
    {
         tagName = s;
    }
}
