using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class player_animation_events : MonoBehaviour
{

    [SerializeField] private AK.Wwise.State playerLife;
    [SerializeField] private AK.Wwise.State playerDead;

    public string playerSwim = "fs_player_swim";
    public string playerSwimSprint = "fs_player_swim_sprint";
    public string RTPC_SpeedOfCharacter = "RTPC_SpeedOfCharacter";
    public string RTPC_playerAlive = "RTPC_PlayerAlive";
    public string wwise_stateGroup_playerLife = "playerLife";

    public float playerSpeed;
    public float playerAlive = 1;
    public float time;
    private Controller3D playerInfo;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
        playerInfo = GetComponent<Controller3D>();
        anim = GetComponent<Animator>();
        AkSoundEngine.SetRTPCValue(RTPC_playerAlive, playerAlive);
        AkSoundEngine.SetState(wwise_stateGroup_playerLife, "Alive");
}
    private void Update()
    {
        playerSpeed = playerInfo.velocity.magnitude;
        CheckPlayerVelocity();
        AkSoundEngine.SetRTPCValue(RTPC_SpeedOfCharacter, playerSpeed);
        time = time + Time.deltaTime;
       /* if (time > 15f)
        {
            AkSoundEngine.SetState(wwise_stateGroup_playerLife, "Dead");
        }*/
    }
    public void Fs_player_swim()
    {
        AkSoundEngine.PostEvent(playerSwim, gameObject);
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
        AkSoundEngine.PostEvent(playerSwimSprint, gameObject);
    }

}
