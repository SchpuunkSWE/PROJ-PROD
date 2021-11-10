using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    private GameObject fishTarget;
    [SerializeField]
    private float allowedDistance = 0.15f;    
    [SerializeField]
    private float followSpeed = 2f;    

    private int positionInList = -1;
    private float targetDistance;

    private RaycastHit shot;
    public bool isFollowingPlayer = false;

    //[SerializeField]
    //private bool collectable = true;

    //private Rigidbody rgb;

    private Follower follower;

    void Awake()
    {
        ////Fetch the Rigidbody from the GameObject with this script attached
        //rgb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        FollowPlayer();
        //StayInSchool();
    }

    private void FollowPlayer()
    {
        if (isFollowingPlayer)
        {
            Vector3 direction = (fishTarget.transform.position + fishTarget.transform.TransformDirection(Vector3.forward)) - transform.position; //Räknar ut vart NPC ska titta.
            
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 10f * Time.deltaTime); //Ser till att NPC roterar mot sitt mål.

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
            {
                targetDistance = shot.distance;

                if (targetDistance >= allowedDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, fishTarget.transform.position, followSpeed); //G�r s� att NPC r�r sig mot spelaren.
                }
            }
        }
    }

    //private void StayInSchool() //Failsafe to reset velocity of fish if flung out of BoidSystem
    //{
    //    if (gameObject.GetComponentInParent<BoidsSystem>() == null)
    //    {
    //        return; 
    //    }
    //    BoidsSystem boidsSystem = gameObject.GetComponentInParent<BoidsSystem>();
    //    float dist = Vector3.Distance(boidsSystem.gameObject.transform.position, transform.position);
    //    if (!(isFollowingPlayer) && dist > boidsSystem.Radius + 2f)
    //    {
    //        rgb.velocity.Set(0f, 0f, 0f); 
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        follower = GetComponent<Follower>();
        if (other.CompareTag("Player") && follower.Collectable == true)
        {
            NPCFishUtil listScript = other.gameObject.GetComponent<NPCFishUtil>(); //H�mtar det andra scriptet från spelare s� vi kommer �t det.
            positionInList = listScript.AddToSchool(transform.gameObject.GetComponent<Follower>()); //L�gger till fisken till listan och returnerar platsen i listan den f�r.
            if(positionInList >= 0) //Om vi f�r tillbaka ett v�rde �ver 0... 
            {            
                fishTarget = listScript.GetTargetPositionObject(positionInList); //Vi s�tter fiskens target till det targetObject som har samma pos i arrayen som fisken har i sin lista.
                GetComponentInParent<BoidsSystem>().RemoveAgent(gameObject); //Tar bort agent från listan av agents.
                isFollowingPlayer = true; //Vi s�tter fiskens status till att f�lja spelaren.
                follower.Collectable = false; //So that you can only pick up the fishes ones.
                follower.RGB.detectCollisions = false; //Turn off collision on fish.
                GetComponent<BoidsAgent>().enabled = false; //Disable Boids Agent script on fish.
            }
        }
    }
}
