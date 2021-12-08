using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPile : MonoBehaviour
{    
    [SerializeField] 
    private float timeAllowed = 5f; //Time player is allowed in trash pile before they die.
    [SerializeField]
    private float playerSlowedSpeed = 5f; //The speed player gets when in Trash Pile.
    [SerializeField]
    private float decreasedMaxVelocity = 2.5f;
    [SerializeField] 
    private AIPath path;
    [SerializeField]
    private float trashPileSpeed = 1f;
    [SerializeField] 
    private float stoppingDistance;
    [SerializeField] 
    private GameObject trashPileDarkAnimGO; //Animation to play when player enters trash pile.
    private Animator anim;

    private Controller3DKeybinds playerController;
    private float timeWhenEntered; //Which point in time the player came into contact with trash pile.
    private bool inTrashPile = false; //Bool to see if player is currently in contact with trash pile.
    private Transform patrolPoint;
    //private Animator anim; //Reference to animator on gameobject
  
    private void Start()
    {
        playerController = FindObjectOfType(typeof(Controller3DKeybinds)) as Controller3DKeybinds;
        //path = GetComponent<AIPath>();
        patrolPoint = path.GetPath[0];
        Debug.Log("Start patrolpoint: " + patrolPoint);

        anim = trashPileDarkAnimGO.GetComponent<Animator>();


    }

    private void Update()
    {
        KillTimer();
        MoveTrashPile();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {           
            inTrashPile = true;
            trashPileDarkAnimGO.SetActive(true);
            anim.SetTrigger("TriggerTrashBlackScreen");
            timeWhenEntered = Time.time;
            SlowPlayer();
        }

        //if (other.tag == "Enemy")
        //{
        //    other.GetComponent<AIController>().IsDazed = true;
        //}
    }

    private void OnTriggerExit(Collider other) //Checks if player has left the mire
    {
        if (other.CompareTag("Player"))
        {
            inTrashPile = false;
            trashPileDarkAnimGO.SetActive(false);
            RestorePlayerSpeed();
        }
    }

    private void KillTimer()
    {
        if (inTrashPile)
        {
            float timeInTrashPile = Time.time - timeWhenEntered;
            Debug.Log("time in trash pile " + timeInTrashPile);

            if (timeInTrashPile >= timeAllowed)
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
                inTrashPile = false;
            }
        }
    }

    private void SlowPlayer()
    {
        playerController.Speed = playerSlowedSpeed;
        playerController.MaxVelocityValue = decreasedMaxVelocity;
    }

    private void RestorePlayerSpeed()
    {
        playerController.Speed = playerController.OGSpeed;
        playerController.MaxVelocityValue = playerController.OGMaxVelocityValue;
    }
    private void MoveTrashPile()
    {
        if (Vector3.Distance(transform.position, patrolPoint.position) < stoppingDistance)
        {
            patrolPoint = path.Next();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoint.position, trashPileSpeed * Time.deltaTime);
    }
}
