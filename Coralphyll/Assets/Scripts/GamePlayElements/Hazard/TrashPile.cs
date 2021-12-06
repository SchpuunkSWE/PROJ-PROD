using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPile : MonoBehaviour
{
    //private AudioSource audioSource;
    private Controller3DKeybinds playerController;
    //[SerializeField] private AIPath path;
    //[SerializeField] private float stoppingDistance;

    [SerializeField] 
    private float timeAllowed = 5f; //Time player is allowed in trash pile before they die
    [SerializeField]
    private float slowedSpeed = 5f;
    [SerializeField]
    private float decreasedMaxVelocity = 2.5f;
    private float timeWhenEntered; //Which point in time the player came into contact with trash pile
    private bool inTrashPile = false; //Bool to see if player is currently in contact with trash pile
    //[SerializeField] private GameObject trashPileDarkAnimGO; //Animation to play when player enters trash pile

    //private Animator anim; //Reference to animator on gameobject

    private Transform patrolPoint;
    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        playerController = FindObjectOfType(typeof(Controller3DKeybinds)) as Controller3DKeybinds;
        //path = GetComponent<AIPath>();
        //patrolPoint = path.GetPath[0];
        Debug.Log("Start patrolpoint: " + patrolPoint);

        //anim = trashPileDarkAnimGO.GetComponent<Animator>();


    }

    private void Update()
    {
        //FloatAround();
        KillTimer();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {           
            inTrashPile = true;
            //trashPileDarkAnimGO.SetActive(true);
            //anim.SetTrigger("");
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
            //trashPileDarkAnimGO.SetActive(false);
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
        playerController.Speed = slowedSpeed;
        playerController.MaxVelocityValue = decreasedMaxVelocity;
    }

    private void RestorePlayerSpeed()
    {
        playerController.Speed = playerController.OGSpeed;
        playerController.MaxVelocityValue = playerController.OGMaxVelocityValue;
    }
}
