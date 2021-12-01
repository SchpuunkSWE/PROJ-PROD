using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moray_Trigger : MonoBehaviour
{
    private Moray moray;
    private Controller3DKeybinds player;
    private bool lunging = false;
    private bool chasing = false;

    private void Awake()
    {
        moray = GetComponentInChildren<Moray>();
    }

    private void Update()
    {
        if (lunging)
        {
            moray.LungeAttack(player.gameObject);
        }

        if (chasing)
        {
            moray.Chase(player.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponentInParent<Controller3DKeybinds>();
            lunging = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        lunging = false;

        //Pause before chasing
        StartCoroutine(WaitBeforeChase());

        //Debug.Log("Lunging = " + lunging.ToString());
        //Debug.Log("Chaseing = " + chasing.ToString());
    }

    private IEnumerator WaitBeforeChase()
    {
        Debug.Log("Waiting 5 secs");
        yield return new WaitForSeconds(5);
        chasing = true;
    }
}
