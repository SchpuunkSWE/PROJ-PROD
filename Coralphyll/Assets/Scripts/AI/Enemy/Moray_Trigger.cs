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
    private bool canChase = false;
    private float waitTime = 1f;


    public void SetCanChase(bool value)
    {
        canChase = value;
    }
    private void Awake()
    {
        canChase = false;
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
            canChase = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        lunging = false;
        if (canChase)
        {
            //Pause before chasing
            StartCoroutine(WaitBeforeChase());
        }
    }

    private IEnumerator WaitBeforeChase()
    {
        yield return new WaitForSeconds(waitTime);
        chasing = true;
    }
}
