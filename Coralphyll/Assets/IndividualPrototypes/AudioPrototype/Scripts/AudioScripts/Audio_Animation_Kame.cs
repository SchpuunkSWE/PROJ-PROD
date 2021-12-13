using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Animation_Kame : MonoBehaviour
{
    public float playerSpeed;
    public float time;
    private Controller3DKeybinds playerInfo;
    Animator anim;
    void Start()
    {
            AkSoundEngine.RegisterGameObj(gameObject);
            playerInfo = GetComponentInParent<Controller3DKeybinds>();
        anim = GetComponent<Animator>();
        if(AudioScene.Levels < 2)
        {
            AddEvent(0, 0.2f, "swimSound", 1);
        }


    }
    void AddEvent(int Clip, float time, string functionName, float floatParameter)
    {
        anim = GetComponent<Animator>();
        AnimationEvent animationEvent = new AnimationEvent();
        animationEvent.functionName = functionName;
        animationEvent.floatParameter = floatParameter;
        animationEvent.time = time;
        AnimationClip clip = anim.runtimeAnimatorController.animationClips[Clip];
        clip.AddEvent(animationEvent);
    }

    private void Update()
    {
        playerSpeed = playerInfo.velocity.magnitude;
        CheckPlayerVelocity();
        AkSoundEngine.SetRTPCValue("RTPC_SpeedOfCharacter", playerSpeed);
        AkSoundEngine.SetRTPCValue("RTPC_PlayerDepth", (int)transform.position.z);
        //Debug.Log("Player depth: "+ (int)transform.position.y);
        time = time + Time.deltaTime;
    }
    public void swimSound()
    {
        if(playerSpeed > 3f && playerSpeed < 20f)
        {
            if (playerSpeed < 21.5f)
            {
                Fs_player_swim();
            }
            if (playerSpeed > 21.5f)
            {
                Fs_player_sprint();
            }
        }
    }
    public void Fs_player_swim()
    {
        Debug.Log("Test swim");
        AkSoundEngine.PostEvent("fs_player_swim", transform.parent.gameObject);
    }
    public void CheckPlayerVelocity()
    {
        //anim.speed = (1f + (1 * (playerSpeed / 10f)));
    }

    public void Fs_player_sprint()
    {
        Debug.Log("Test sprint");
        AkSoundEngine.PostEvent("fs_player_swim_sprint", transform.parent.gameObject);
    }


}
