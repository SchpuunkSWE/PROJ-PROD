using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float maxDetectionRadius = 10.0f;
    
    private float lastChangeTime;

    private AudioSource audioSource;
    private MeshRenderer meshRenderer;

    private bool hasChanged; 

    private Controller3DKeybinds playerController; 

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerController = FindObjectOfType(typeof(Controller3DKeybinds)) as Controller3DKeybinds;

        meshRenderer = GetComponent<MeshRenderer>(); 


    }

    // Update is called once per frame
    void Update()
    { 
        var distance = Vector3.Distance(transform.position, playerController.transform.position); 
        var fraction = (distance / maxDetectionRadius);

        if (distance <= maxDetectionRadius)
        { 
            if (Time.realtimeSinceStartup - lastChangeTime >= fraction)
            {
                lastChangeTime = Time.realtimeSinceStartup;
                //meshRenderer.material.color = hasChanged ? Color.black : Color.red;
                meshRenderer.material.SetColor("Color_f3b331c7ca4b4188b2d46fb52af77be7", hasChanged ? Color.grey : Color.red);
                hasChanged = !hasChanged;
                
                AkSoundEngine.PostEvent("Mine_Beep", gameObject);



                if (hasChanged)
                {
               
                    //Debug.Log(volume);
                
                    audioSource.volume = 1- fraction;
               
                    audioSource.Play(0);
           
                }

      
            }

            

        }

        else if (hasChanged)
        {
            meshRenderer.material.SetColor("Color_f3b331c7ca4b4188b2d46fb52af77be7", Color.grey );

        }



    }

    private void OnTriggerEnter(Collider other)
    {
       

        if (other.tag == "Player")
        {
           
            Explode();
            AkSoundEngine.PostEvent("Mine_Explosion", gameObject);

        }

        if (other.tag == "Enemy")
        {
            other.GetComponent<AIController>().IsDazed = true;
            AkSoundEngine.PostEvent("Mine_Explosion", gameObject);

        }
    }

    private void Explode()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.DetachChildren();  

        //Respawn Player (Instakill)
        DeathInfo d = new DeathInfo
        {
            victim = playerController.gameObject,
            killer = this.gameObject
        };
        NPCFishUtil.NPCFishUtilInstance.KillAllFish();
        Debug.Log("fish died");
        EventHandler<DeathEvent>.FireEvent(new DeathEvent(d));

        Destroy(gameObject);
    }

}
