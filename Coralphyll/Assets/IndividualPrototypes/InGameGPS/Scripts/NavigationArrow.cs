using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationArrow : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow;

    

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        //if()
        arrow.transform.LookAt(GetClosestFishSchool()); //Ser till att pilen pekar mot fiskstimmet
        //arrow.transform.LookAt(GetClosestCoral()); //Ser till att pilen pekar mot korallen
    }
    private Transform GetClosestFishSchool()
    {
        GameObject[] arrayOfFishSchools = GameObject.FindGameObjectsWithTag("FishSchool"); 
        Transform bestFishSchoolTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in arrayOfFishSchools)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestFishSchoolTarget = potentialTarget.transform;
            }
        }
        return bestFishSchoolTarget;
    }

    private Transform GetClosestCoral()
    {
        GameObject[] arrayOfCorals = GameObject.FindGameObjectsWithTag("Coral");
        Transform bestCoralTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in arrayOfCorals)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestCoralTarget = potentialTarget.transform;
            }
        }

        return bestCoralTarget;
    }
}
