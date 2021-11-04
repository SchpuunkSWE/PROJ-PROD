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

    private PlayerController playerController; 

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;

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
                meshRenderer.material.color = hasChanged ? Color.black : Color.red;
                hasChanged = !hasChanged;

            
                if (hasChanged)
                {
               
                    //Debug.Log(volume);
                
                    audioSource.volume = 1- fraction;
               
                    audioSource.Play(0);
           
                }

      
            }

            

        }


       
    }
}
