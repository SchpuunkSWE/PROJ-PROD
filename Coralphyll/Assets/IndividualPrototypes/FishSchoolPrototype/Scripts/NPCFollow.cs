using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject fishTarget;
    [SerializeField]
    private GameObject theNPC;
    //[SerializeField]
    //private int maxFishes = 9;
    [SerializeField]
    private float allowedDistance = 0.1f;

    private float targetDistance;
    private float followSpeed;
    private RaycastHit shot;
    private bool isFollowing = false;

    //[SerializeField]
    //private List<GameObject> listOfFishes = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (isFollowing)
        {
            transform.LookAt(fishTarget.transform); //Ser till att NPC tittar mot oss
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
            {
                targetDistance = shot.distance;

                if (targetDistance >= allowedDistance)
                {
                    followSpeed = 0.2f; //S�tter farten NPC r�r sig i
                                        //Nedan �r f�r att spela upp animationer
                                        //theNPC.GetComponent<Animation>().Play("Name of animation");
                    transform.position = Vector3.MoveTowards(transform.position, fishTarget.transform.position, followSpeed); //G�r s� att NPC r�r sig mot spelaren
                }
                else
                {
                    followSpeed = 0; //Om spelaren inte �r i n�rheten ska NPC vara st� stilla.
                                     //theNPC.GetComponent<Animation>().Play("Animationen f�r idle");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isFollowing = true;
            //listOfFishes.Add(theNPC);
        }
    }
}
