using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipStream_Teleport : MonoBehaviour
{
 [SerializeField]
    private float newSpeed = 40;

    [SerializeField]
    private float newMaxVelocity = 50;

    [SerializeField]
    private Transform goalPosition;

    private Controller3DKeybinds player;

    [SerializeField]
    private bool inStream = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponentInParent<Controller3DKeybinds>();
            //player.Speed = newSpeed; //Sets speed to the new value.
            player.MaxVelocityValue = newMaxVelocity; //Sets MaxVelocity value to the new value. 
            inStream = true;

        }
    }
    private void Update()
    {
        if (inStream)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, goalPosition.position, newSpeed * Time.deltaTime);
            inStream = Vector3.Distance(player.transform.position, goalPosition.position) > 10f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        float oldSpeed = player.OGSpeed;
        float oldVelocity = player.OGMaxVelocityValue;
        player = other.GetComponentInParent<Controller3DKeybinds>();
        if (other.CompareTag("Player"))
        {
            player.Speed = oldSpeed; //sets the speed to the usual speed
            player.MaxVelocityValue = oldVelocity; //sets maxVelocity to the usual maxVelocity.
        }

        inStream = false;
    }
}
