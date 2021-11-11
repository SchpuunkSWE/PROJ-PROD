using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationArrow : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow;
    [SerializeField]
    private GameObject visualArrow;
    [SerializeField]
    private string tagName;
    [SerializeField]
    private float arrowTransparencyMult = 1f; //Multiplier for transparency, higher values makes arrow visible faster
    [SerializeField]
    private float arrowTransparencyMinRange = 15f; //Minimun range from target for arrow to be visible

    // Update is called once per frame
    void Update()
    {
        Transform target = GetClosestTarget(tagName);

        Vector3 direction = target.position - arrow.transform.position; //Räknar ut vart pil ska titta.

        arrow.transform.rotation = Quaternion.Slerp(arrow.transform.rotation, Quaternion.LookRotation(direction), 5f * Time.deltaTime); //Ser till att NPC roterar mot sitt mål.

        MakeArrowTransparent(target);
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

    private void MakeArrowTransparent(Transform target) 
    {
        Renderer rend = visualArrow.transform.GetComponent<Renderer>();
        Color matColour = rend.material.color;
        float dist = Vector3.Distance(arrow.transform.position, target.position);
        float alphaValue = Mathf.Clamp(((dist * arrowTransparencyMult) - (arrowTransparencyMinRange * arrowTransparencyMult)) /100, 0f, 1f); //Calculates a transparency value between 0-1
        Debug.Log("alpha: " + alphaValue);

        rend.material.color = new Color(matColour.r, matColour.g, matColour.b, alphaValue);
    }
}
