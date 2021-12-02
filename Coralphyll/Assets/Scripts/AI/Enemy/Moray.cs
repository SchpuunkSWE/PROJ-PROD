using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moray : MonoBehaviour
{
    private float lungeSpeed = 50f;
    private float chaseSpeed = 2f;
    private float attackDistance = 3f;
    private float chaseDistance = 10f;
    private float lairDistance = 0.2f;
    private bool ready = true;
    private Vector3 lairLocation; //Cache original location
    private Moray_Trigger mt;
    void Start()
    {
        mt = GetComponentInParent<Moray_Trigger>();
        //Set lair-location to be original spawn location
        lairLocation = transform.position;
    }

    
    void Update()
    {
        //If in lair, able to attack
        //readyToAttack = InRange(lairLocation, lairDistance);
    }

    public void Lunge(GameObject target)
    {
        if (ready)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, lungeSpeed * Time.deltaTime);
            transform.LookAt(target.transform);
        }
        else
        {
            Debug.Log("Not acting pga moving back to lair");
        }

    }

    public void Chase(GameObject target)
    {
        if (ready)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, chaseSpeed * Time.deltaTime);
            transform.LookAt(target.transform);

            if (InRange(target.transform.position, attackDistance))
            {
                Attack();
            }

            if (!InRange(target.transform.position, chaseDistance))
            {
                ReturnToLair();
                mt.SetCanChase(false);
            }
        }
        else
        {
            Debug.Log("Not acting pga moving back to lair");
        }

    }

    private bool InRange(Vector3 targetPos, float distance)
    {
        return Vector3.Distance(transform.position, targetPos) <= distance;
    }

    private void Attack()
    {
        Debug.Log("Attacking!");
    } 

    private void ReturnToLair()
    {
        ////set bool to prevent moray from attacking during this movement
        //ready = false;

        //transform.position = Vector3.MoveTowards(transform.position, lairLocation, chaseSpeed * Time.deltaTime);
        //transform.LookAt(lairLocation);
        ////reset bool when back at lairLocation
        //if (InRange(lairLocation, lairDistance))
        //{
        //    ready = true;
        //    Debug.Log("Back at lair");
        //}
        ready = false;
        while(!InRange(lairLocation, lairDistance))
        {
            transform.position = Vector3.MoveTowards(transform.position, lairLocation, chaseSpeed * Time.deltaTime);
            //transform.LookAt(lairLocation);
        }
        ready = true;
        Debug.Log("Back at lair");
    }


    //If moray hits player when lunging
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Attack();
        }
    }


    /*
     * TODO: 
     * Reset so that moray can't chase before having lunged (set some bool "canChase" at ontriggerenter/ontriggerexit)
     * Find a way to use movetowards with neither if-statement (only does once) nor while-loop(does every frame which is too much)     
     */
}
