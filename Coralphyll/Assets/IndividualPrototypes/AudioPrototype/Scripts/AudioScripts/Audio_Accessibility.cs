using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Accessibility : MonoBehaviour
{
    // 了ishes, 又hark, 七orals, 又ome indicator of how far up to the surface you are.

    Coral[] corals;
   // AIController[] sharks;
   // TrashPile[] trashPiles;
    BoidsSystem[] fishes;
    private bool toggle = true;
    private float distance = 0f;
    private float pingTimer;
    private float distanceTemp;
    private Coral closestCoral;
    private bool coralToggle;
    [SerializeField] private GameObject coralPingObj;
    // Start is called before the first frame update
     void Start()
    {
        toggle = true;
       // sharks = FindObjectsOfType<AIController>();
       // trashPiles = FindObjectsOfType<TrashPile>();
        corals = FindObjectsOfType<Coral>();
        fishes = FindObjectsOfType<BoidsSystem>();
    }
    void FixedUpdate(){
       // Debug.Log("CORALTOGGLE ISS" + coralToggle);
        if (coralToggle == true)
        {
            //Debug.Log("AUDIO ACCESSSSSSS" + corals.Length + " asdfasd " + fishes.Length);
            FindClosestCoral();
            CoralPing();
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (toggle)
            {
                ToggleAudioAccessibilityOn();
            }
            else
            {
                ToggleAudioAccessibilityOff();
            }
            toggle = !toggle;
        }
    corals[i].transform.position
    }*/
    public void FindClosestCoral()
    {
        float distanceTemp2 = float.PositiveInfinity;
        for (int i = 0; i < corals.Length; i++)
        {
            if (corals[i].GetComponent<WwAudioEmitter>() != null)
            {
                distanceTemp = Vector3.Distance(this.transform.position, corals[i].transform.position);
                    // Debug.Log("Player is at: " + transform.position + " And coral is at: " + corals[i].transform.position + " and shortest distance is now: "+ distance);
                if (distanceTemp < distanceTemp2)
                {
                    closestCoral = corals[i];
                    distance = distanceTemp;
                }
                distanceTemp2 = distanceTemp;
            }
        }

    }
    /* private void StopCoralPing()
     {
         coralPingObj.GetComponent<WwAudioEmitter>().SetName("Coral");
         coralPingObj.GetComponent<WwAudioEmitter>().SetStopName("Coral_Stop");
     }*/
    public void CoralPing()
    {

        coralPingObj.transform.position = Vector3.Lerp(transform.position, closestCoral.transform.position, 0.5f);
        float frequency = (distance / 60f) + 0.5f;
        //Debug.Log("Distance is: " + distance + " and fraction is: "+ frequency + " and ping timer is: " + pingTimer);
        if (distance <= 100f)
        {
            if (Time.realtimeSinceStartup - pingTimer >= frequency)
            {
                pingTimer = Time.realtimeSinceStartup;
                AkSoundEngine.PostEvent("Coral_Ping", coralPingObj);
            }
        }
    }
    public void ToggleAudioAccessibility()
    {
       // Debug.Log("TOGGLE IS: " + toggle);
        if (toggle)
        {
            ToggleAudioAccessibilityOn();
        }
        else
        {
            ToggleAudioAccessibilityOff();
        }
        toggle = !toggle;
    }
    public void ToggleAudioAccessibilityOn()
    {
        coralToggle = true;
        /* for (int i = 0; i < sharks.Length; i++)
         {
             sharks[i].GetComponent<WwAudioEmitter>().SetName("Shark_Accessibility");
             sharks[i].GetComponent<WwAudioEmitter>().SetStopName("Shark_Accessibility_Stop");
         }
                for (int i = 0; i < trashPiles.Length; i++)
         {
             trashPiles[i].GetComponent<WwAudioEmitter>().SetName("Trashpile_Accessibility");
             trashPiles[i].GetComponent<WwAudioEmitter>().SetStopName("Trashpile_Accessibility_Stop");
         }
         */
        /*for (int i = 0; i < corals.Length; i++)
        {
                if (corals[i].GetComponent<WwAudioEmitter>() != null)
                {
                    Debug.Log("Coral accessibility sound reactivated ");
                    corals[i].GetComponent<WwAudioEmitter>().SetName("Coral_Accessibility");
                    corals[i].GetComponent<WwAudioEmitter>().SetStopName("Coral_Accessibility_Stop");
                }
        }
                coralPingObj.GetComponent<WwAudioEmitter>().SetName("Coral_Accessibility");
        coralPingObj.GetComponent<WwAudioEmitter>().SetStopName("Coral_Accessibility_Stop");
        */
        if (fishes!=null)
        {
            for (int i = 0; i < fishes.Length; i++)
            {
                if (fishes[i].GetComponent<WwAudioEmitter>() != null)
                {
                    string tempType = fishes[i].GetComponent<WwAudioEmitter>().GetEmitterType();
                    switch (tempType)
                    {
                        case "RedFish":
                            Debug.Log("Redfish");
                            fishes[i].GetComponent<WwAudioEmitter>().SetName("NPC_Friendly_Red");
                            fishes[i].GetComponent<WwAudioEmitter>().SetStopName("NPC_Friendly_Red_Stop");
                            break;
                        case "YellowFish":
                            fishes[i].GetComponent<WwAudioEmitter>().SetName("NPC_Friendly_Yellow");
                            fishes[i].GetComponent<WwAudioEmitter>().SetStopName("NPC_Friendly_Yellow_Stop");
                            break;
                        case "BlueFish":
                            fishes[i].GetComponent<WwAudioEmitter>().SetName("NPC_Friendly_Blue");
                            fishes[i].GetComponent<WwAudioEmitter>().SetStopName("NPC_Friendly_Blue_Stop");
                            break;
                    }
                }

            }
        }
        

    }
    public void ToggleAudioAccessibilityOff()
    {
        coralToggle = false;
        /*
        for (int i = 0; i < sharks.Length; i++)
        {
            sharks[i].GetComponent<WwAudioEmitter>().SetName("NPC_Enemy_Shark");
            sharks[i].GetComponent<WwAudioEmitter>().SetStopName("NPC_Enemy_Shark_Stop");
        }
        for (int i = 0; i < trashPiles.Length; i++)
        {
            trashPiles[i].GetComponent<WwAudioEmitter>().SetName("Garbage_Play");
            trashPiles[i].GetComponent<WwAudioEmitter>().SetStopName("Garbage_Stop");
        }
        */
        /* for (int i = 0; i < corals.Length; i++)
         {
                 if (corals[i].GetComponent<WwAudioEmitter>() != null)
                 {
                     corals[i].GetComponent<WwAudioEmitter>().SetName("Coral");
                     corals[i].GetComponent<WwAudioEmitter>().SetStopName("Coral_Stop");
                 }
         }
                coralPingObj.GetComponent<WwAudioEmitter>().SetName("Coral");
         coralPingObj.GetComponent<WwAudioEmitter>().SetStopName("Coral_Stop");
        */
        if(fishes!=null)
        {
            for (int i = 0; i < fishes.Length; i++)
            {
                if (fishes[i].GetComponent<WwAudioEmitter>() != null)
                {
                    fishes[i].GetComponent<WwAudioEmitter>().SetName("NPC_Friendly_Fish_Generic");
                    fishes[i].GetComponent<WwAudioEmitter>().SetStopName("NPC_Friendly_Fish_Generic_Stop");
                }
            }
        }

    }
}
