using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moray_Trigger : MonoBehaviour
{
    private Moray moray;
    private Controller3DKeybinds player;
    private Transform lungePoint;
    private bool lunging = false;
    private bool chasing = false;
    private float waitTime = 1f;

    private void Awake()
    {
        moray = GetComponentInChildren<Moray>();
        lungePoint = GetComponentInChildren<Transform>();
    }

    private void Update()
    {
        if (lunging)
        {
            moray.Lunge(lungePoint.gameObject);
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

    }

    private IEnumerator WaitBeforeChase()
    {
        yield return new WaitForSeconds(waitTime);
        chasing = true;
    }
}
