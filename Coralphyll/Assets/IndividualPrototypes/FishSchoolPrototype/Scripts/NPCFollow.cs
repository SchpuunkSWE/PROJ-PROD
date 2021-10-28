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
    //[SerializeField]
    //private float followThrust = 0.2f;

    private int positionInList = -1;
    private float targetDistance;

    private RaycastHit shot;
    private bool isFollowingPlayer = false;
    //private Rigidbody rgb;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        //rgb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        FollowPlayer();
    }
    //void FixedUpdate()
    //{
    //    FollowPlayer();
    //}

    private void FollowPlayer()
    {
        if (isFollowingPlayer)
        {
            transform.LookAt(fishTarget.transform); //Ser till att NPC tittar mot oss
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
            {
                targetDistance = shot.distance;

                if (targetDistance >= allowedDistance)
                {
                    //followSpeed = 0.2f; //Sätter farten NPC rör sig i

                    //rgb.AddForce(Vector3.forward * followThrust);
                    //rgb.velocity = Vector3.ClampMagnitude(rgb.velocity, followSpeed);
                    transform.position = Vector3.MoveTowards(transform.position, fishTarget.transform.position, followSpeed); //Gör så att NPC rör sig mot spelaren
                }
                //else
                //{
                //    followSpeed = 0; //Om spelaren inte är i närheten ska NPC vara stå stilla.
                //}
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NPCTargetUtil listScript = other.gameObject.GetComponent<NPCTargetUtil>(); //Hämtar det andra scriptet så vi kommer åt det
            positionInList = listScript.AddToSchool(transform.gameObject); //Lägger till fisken till listan och returnerar platsen i listan den får
            if(positionInList >= 0) //Om vi får tillbaka ett värde över 0... 
            {            
                fishTarget = listScript.GetTargetPositionObject(positionInList); //Vi sätter fiskens target till det targetObject som har samma pos i arrayen som fisken har i sin lista
                isFollowingPlayer = true; //Vi sätter fiskens status till att följa spelaren
            }
        }
    }
}
