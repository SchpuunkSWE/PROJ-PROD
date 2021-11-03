using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameController gc;

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GC").GetComponent<GameController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("CheckPoint updated");
            //gc.lastCheckPointPos = transform.position; //sets the most recent checkPoints position to the curretn checkPoint
            gc.SetLastCheckPointPos(transform.position);
        }
    }
}
