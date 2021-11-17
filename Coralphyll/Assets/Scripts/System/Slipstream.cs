using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slipstream : MonoBehaviour
{
    [SerializeField]
    private float newSpeed = 40;

    [SerializeField]
    private float newMaxVelocity = 50;

    private Controller3DKeybinds player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponentInParent<Controller3DKeybinds>();
            player.Speed = newSpeed; //Sets speed to the new value.
            player.MaxVelocityValue = newMaxVelocity; //Sets MaxVelocity value to the new value. 
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
    }
}
