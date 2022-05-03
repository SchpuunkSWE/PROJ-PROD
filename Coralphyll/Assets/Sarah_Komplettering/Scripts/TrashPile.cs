using System.Collections;
using UnityEngine.UI;
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
    private Image fadeImage; //UI Image to fade.
    private float alpha; //Alpha value of the image.

    private Controller3DKeybinds playerController;
    private float timeWhenEntered; //Which point in time the player came into contact with trash pile.
    private bool inTrashPile = false; //Bool to see if player is currently in contact with trash pile.
    private Transform patrolPoint;
    private bool trashRemovesPlayerBoost = false;

    public float TimeAllowed { get => timeAllowed; set => timeAllowed = value; }
    public float TrashPileSpeed { get => trashPileSpeed; set => trashPileSpeed = value; }
    public float PlayerSlowedSpeed { get => playerSlowedSpeed; set => playerSlowedSpeed = value; }
    public bool TrashRemovesPlayerBoost { get => trashRemovesPlayerBoost; set => trashRemovesPlayerBoost = value; }

    private void Start()
    {
        playerController = FindObjectOfType(typeof(Controller3DKeybinds)) as Controller3DKeybinds;
        patrolPoint = path.GetPath[0];
        Debug.Log("Start patrolpoint: " + patrolPoint);
    }

    private void Update()
    {
        if (inTrashPile)
        {
            KillTimer();
        }
        MoveTrashPile();
    }

    public void RemovePlayerBoost(Collider playerCol, bool value)
    {
        playerCol.GetComponent<Controller3DKeybinds>().IsBoostReady = value;
    }
    private void OnTriggerEnter(Collider other) //Check if player is in the trashPile.
    {
        if (other.tag == "Player")
        {           
            inTrashPile = true;
            StartCoroutine(FadeOut());
            timeWhenEntered = Time.time;
            SlowPlayer();
            if (trashRemovesPlayerBoost)
            {
                RemovePlayerBoost(other, false);
            }
        }
    }

    private void OnTriggerExit(Collider other) //Check if player has left the trashPile.
    {
        if (other.CompareTag("Player"))
        {
            inTrashPile = false;
            StartCoroutine(FadeIn());
            RestorePlayerSpeed();

            if (trashRemovesPlayerBoost)
            {
                RemovePlayerBoost(other, true);
            }
        }
    }

    private void KillTimer()
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

    private IEnumerator FadeIn()
    {
        alpha = fadeImage.color.a;

        while (alpha > 0 && !inTrashPile)
        {
            alpha -= Time.deltaTime / timeAllowed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0);
            Debug.Log("Fade in Alpha " + alpha);
        }
    }

    private IEnumerator FadeOut()
    {
        alpha = fadeImage.color.a;

        while (alpha < 1 && inTrashPile)
        {
            alpha += Time.deltaTime / timeAllowed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0);
            Debug.Log("Fade out Alpha " + alpha);
        }
    }
}

