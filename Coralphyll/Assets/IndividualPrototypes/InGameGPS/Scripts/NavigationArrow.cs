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

    private bool ignoreYellow;
    public bool IgnoreYellow { get => ignoreYellow; set => ignoreYellow = value; }

    private bool ignoreRed;
    public bool IgnoreRed { get => ignoreRed; set => ignoreRed = value; }

    private bool ignoreBlue;
    public bool IgnoreBlue { get => ignoreBlue; set => ignoreBlue = value; }

    // Update is called once per frame
    void Update()
    {
        Transform target = GetClosestTarget(tagName);

        if (target != null)
        {
            Vector3 direction = target.position - arrow.transform.position; //Räknar ut vart pil ska titta.

            arrow.transform.rotation = Quaternion.Slerp(arrow.transform.rotation, Quaternion.LookRotation(direction), 5f * Time.deltaTime); //Ser till att NPC roterar mot sitt mål.

            ChangeArrowColour(target);
            MakeArrowTransparent(target);
        }
    }
    public Transform GetClosestTarget(string targetTag)
    {
        GameObject[] arrayOfTargets = GameObject.FindGameObjectsWithTag(targetTag);
        Transform closestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in arrayOfTargets)
        {
            if (targetTag == "NPCFish")
            {
                if (potentialTarget.GetComponent<Follower>().GetColour().ToString() == "YELLOW" && ignoreYellow //If the fish colour is yellow and ignoreYellow is true...
                        || potentialTarget.GetComponent<Follower>().GetColour().ToString() == "RED" && ignoreRed
                        || potentialTarget.GetComponent<Follower>().GetColour().ToString() == "BLUE" && ignoreBlue)
                {
                    continue; //...Skip to next element in the foreach loop.
                }
            }
            //Otherwise get closests target as usual.
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
        float alphaValue = Mathf.Clamp(((dist * arrowTransparencyMult) - (arrowTransparencyMinRange * arrowTransparencyMult)) / 100, 0f, 1f); //Calculates a transparency value between 0-1
        //Debug.Log("alpha: " + alphaValue);

        rend.material.color = new Color(matColour.r, matColour.g, matColour.b, alphaValue);
    }

    private void ChangeArrowColour(Transform target)
    {
        Renderer rendArrow = visualArrow.gameObject.GetComponent<Renderer>();

        if (tagName == "NPCFish")
        {
            Follower fish = target.GetComponent<Follower>();
            FishColour fishColour = fish.GetColour();

            switch (fishColour)
            {
                case FishColour.YELLOW:
                    rendArrow.material.color = Color.yellow;
                    break;
                case FishColour.RED:
                    rendArrow.material.color = Color.red;
                    break;
                case FishColour.BLUE:
                    rendArrow.material.color = Color.blue;
                    break;
                default:
                    rendArrow.material.color = Color.gray;
                    break;
            }
        }
        else
        {
            rendArrow.material.color = Color.white;
        }
    }

    //public void IgnoreYellow(bool yellow)
    //{
    //    ignoreYellow = yellow;
    //}
    //public void IgnoreRed(bool red)
    //{
    //    ignoreRed = red;
    //}
    //public void IgnoreBlue(bool blue)
    //{
    //    ignoreBlue = blue;
    //}
}
