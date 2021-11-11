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

        Transform target = GetClosestTarget(tagName);

        Vector3 direction = target.position - arrow.transform.position; //Räknar ut vart pil ska titta.

        arrow.transform.rotation = Quaternion.Slerp(arrow.transform.rotation, Quaternion.LookRotation(direction), 5f * Time.deltaTime); //Ser till att NPC roterar mot sitt mål.

        float dist = Vector3.Distance(arrow.transform.position, target.position);
        if (dist < 5f)
        {
            StartCoroutine(FadeOutMaterial(1f));
            Debug.Log("Coroutine started");
        }
        //
        //arrow.transform.LookAt(GetClosestTarget(tagName)); //Ser till att pilen pekar mot närmsta target
        //}

    }

    private void Awake()
    { 
        //StartCoroutine(FadeOutMaterial(1f));
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

    IEnumerator FadeOutMaterial(float fadeSpeed)
    {
        Debug.Log("FadeOutMaterial started");
        Renderer rend = arrow.transform.GetComponentInChildren<Renderer>();
        Color matColor = rend.material.color;
        float alphaValue = rend.material.color.a;

        while (rend.material.color.a > 0f)
        {
            alphaValue -= Time.deltaTime / fadeSpeed;
            rend.material.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);
            yield return null;
        }
        rend.material.color = new Color(matColor.r, matColor.g, matColor.b, 0f);
        Debug.Log("Material faded");
    }

    private void CalculateDistance(Transform target)
    {
        //float dist = Vector3.Distance(target.position, arrow.transform.position);
    }
}
