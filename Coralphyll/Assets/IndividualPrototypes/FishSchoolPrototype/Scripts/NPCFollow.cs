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
                    //followSpeed = 0.2f; //S�tter farten NPC r�r sig i

                    //rgb.AddForce(Vector3.forward * followThrust);
                    //rgb.velocity = Vector3.ClampMagnitude(rgb.velocity, followSpeed);
                    transform.position = Vector3.MoveTowards(transform.position, fishTarget.transform.position, followSpeed); //G�r s� att NPC r�r sig mot spelaren
                }
                //else
                //{
                //    followSpeed = 0; //Om spelaren inte �r i n�rheten ska NPC vara st� stilla.
                //}
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NPCTargetUtil listScript = other.gameObject.GetComponent<NPCTargetUtil>(); //H�mtar det andra scriptet s� vi kommer �t det
            positionInList = listScript.AddToSchool(transform.gameObject.GetComponent<Follower>()); //L�gger till fisken till listan och returnerar platsen i listan den f�r
            if(positionInList >= 0) //Om vi f�r tillbaka ett v�rde �ver 0... 
            {            
                fishTarget = listScript.GetTargetPositionObject(positionInList); //Vi s�tter fiskens target till det targetObject som har samma pos i arrayen som fisken har i sin lista
                isFollowingPlayer = true; //Vi s�tter fiskens status till att f�lja spelaren
            }
        }
    }
}
