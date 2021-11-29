using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPile : MonoBehaviour
{
    //private AudioSource audioSource;
    private Controller3DKeybinds playerController;
    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        playerController = FindObjectOfType(typeof(Controller3DKeybinds)) as Controller3DKeybinds;
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
}
