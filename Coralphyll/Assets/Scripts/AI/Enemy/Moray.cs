using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moray : MonoBehaviour
{
    private float lungeSpeed = 50f;
    private float chaseSpeed = 2f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void LungeAttack(GameObject target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, lungeSpeed * Time.deltaTime);
        transform.LookAt(target.transform);
    }

    public void Chase(GameObject target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, chaseSpeed * Time.deltaTime);
        transform.LookAt(target.transform);
    }
}
