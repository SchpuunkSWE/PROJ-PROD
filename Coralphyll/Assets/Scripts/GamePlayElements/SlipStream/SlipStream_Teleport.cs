using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipStream_Teleport : MonoBehaviour
{
    [SerializeField]
    private float newPlayerSpeed = 40;

    // [SerializeField]
    // private float newMaxVelocity = 50;

    [SerializeField]
    private Transform goalPosition;

    private Controller3DKeybinds player;

    [SerializeField]
    private bool inStream = false;

    [SerializeField]
    private float newFishSpeed = 60f;

    [SerializeField]
    private float originalFishSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponentInParent<Controller3DKeybinds>();

            //player.velocity = Vector3.zero;
            player.velocity = player.velocity.normalized * 0.2f;

            inStream = true;

            //Fetch original fish speed (I have to find a better way to do this? hehe)
            List<Follower> followers = player.gameObject.GetComponent<NPCFishUtil>().getListOfFishes();
            if(followers.Count > 0){
                Follower ogFish = followers[0];
                originalFishSpeed = ogFish.gameObject.GetComponent<NPCFollow>().GetFollowSpeed();
            }

            //Increase speed of follower fishes as well so that they don't fall too far behind
            foreach (Follower fish in followers)
            {
                fish.gameObject.GetComponent<NPCFollow>().SetFollowSpeed(newFishSpeed);
            }
        }
    }

    private void Update()
    {
        if (inStream)
        {
            Vector3.SmoothDamp(player.transform.position, goalPosition.position, ref player.velocity, 0.5f, 60f);
            inStream = Vector3.Distance(player.transform.position, goalPosition.position) > 1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //TODO: Do I even need lines 63-70?
            float oldSpeed = player.OGSpeed;
            float oldVelocity = player.OGMaxVelocityValue;
            player = other.GetComponentInParent<Controller3DKeybinds>();
        
            player.Speed = newPlayerSpeed; //sets the speed to the usual speed

            player.MaxVelocityValue = oldVelocity; //sets maxVelocity to the usual maxVelocity.

            //Reset follower fish speed
            foreach (Follower fish in player.gameObject.GetComponent<NPCFishUtil>().getListOfFishes())
            {
                fish.gameObject.GetComponent<NPCFollow>().SetFollowSpeed(originalFishSpeed);
            }

            inStream = false;
        }
    }
}
