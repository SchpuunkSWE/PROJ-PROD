using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class player_animation_events : MonoBehaviour
{
    public float playerSpeed;
    public float time;
    private Controller3D playerInfo;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
        playerInfo = GetComponent<Controller3D>();
        anim = GetComponent<Animator>();
}
    private void Update()
    {
        playerSpeed = playerInfo.velocity.magnitude;
        CheckPlayerVelocity();
        AkSoundEngine.SetRTPCValue("RTPC_SpeedOfCharacter", playerSpeed);
        time = time + Time.deltaTime;
       /* if (time > 15f)
        {
            AkSoundEngine.SetState(wwise_stateGroup_playerLife, "Dead");
        }*/
    }
    public void Fs_player_swim()
    {
        AkSoundEngine.PostEvent("fs_player_swim", gameObject);
    }
    public void CheckPlayerVelocity()
    {
        if (playerSpeed > 2f && playerSpeed < 11.5f)
        {
            anim.SetBool("isSwimming", true);
        }
        else
        {
            anim.SetBool("isSwimming", false);
        }
        if(playerSpeed > 11.5f)
        {
            anim.SetBool("isSprinting", true);
        }
        else
        {
            anim.SetBool("isSprinting", false);
        }
        //Sets the speed of the animation (and in effect the swim sound interval which is set as an
        //Event in the swim animation
        //The calculation returns a percentage value of how fast we are
        //going compared to the max velocity that the players velocity vector is allowed to have, 
        //Which will return a value of between 0~ and 1~. 
        anim.speed = (1f + (1 * (playerSpeed / playerInfo.maxVelocityValue)));
    }
    
    public void fs_player_sprint()
    {
        AkSoundEngine.PostEvent("fs_player_swim_sprint", gameObject);
    }

}
