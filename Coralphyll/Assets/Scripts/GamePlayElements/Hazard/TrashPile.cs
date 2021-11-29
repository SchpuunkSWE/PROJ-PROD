using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPile : MonoBehaviour
{
    //private AudioSource audioSource;
    private Controller3DKeybinds playerController;
    [SerializeField] private AIPath path;
    [SerializeField] private float stoppingDistance;

    private Transform patrolPoint;
    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        playerController = FindObjectOfType(typeof(Controller3DKeybinds)) as Controller3DKeybinds;
        //path = GetComponent<AIPath>();
        patrolPoint = path.GetPath[0];
        Debug.Log("Start patrolpoint: " + patrolPoint);


    }

    private void Update()
    {
        //FloatAround();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DeathInfo d = new DeathInfo
            {
                victim = playerController.gameObject,
                killer = this.gameObject
            };
            NPCFishUtil.NPCFishUtilInstance.KillAllFish();
            Debug.Log("fish died");
            EventHandler<DeathEvent>.FireEvent(new DeathEvent(d));
            Debug.Log("player died");
        }

        //if (other.tag == "Enemy")
        //{
        //    other.GetComponent<AIController>().IsDazed = true;
        //}
    }

    private void FloatAround()
    {
        if (Vector3.Distance(transform.position, patrolPoint.position) < stoppingDistance)
        {
            patrolPoint = path.Next();
            Debug.Log("Next path " + path.Next());
        }
        Debug.Log("Current patrolpoint " + patrolPoint);
        transform.position = Vector3.MoveTowards(transform.position, patrolPoint.position, 2 * Time.deltaTime);
        //RotateTowards(patrolPoint);
    }
}
