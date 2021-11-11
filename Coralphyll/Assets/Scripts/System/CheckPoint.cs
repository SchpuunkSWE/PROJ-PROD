using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("CheckPoint updated");
            //gc.lastCheckPointPos = transform.position; //sets the most recent checkPoints position to the curretn checkPoint
            GameController.Instance.SetLastCheckPointPos(transform.position);
        }
    }
}
