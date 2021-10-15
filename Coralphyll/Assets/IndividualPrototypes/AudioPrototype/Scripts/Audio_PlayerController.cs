using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio_PlayerController : MonoBehaviour
{
    private Controller3D playerController;
    private GameObject player;
    public AudioClip[] playerAudioSwimSounds;
    public AudioClip[] environmentAmbienceSounds;
    [SerializeField] private float playerVelocity;
    [SerializeField] private AudioSource[] sources;
   // private Vector3 playerVelocityVector;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<Controller3D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMotion();
    }

    private void PlayerMotion()
    {
        playerVelocity = playerController.velocity.magnitude;
        if (playerVelocity > 2f)
        {
            Debug.Log("Velocity is: " + playerVelocity);
            PlaySound("SwimBeat");
        }

    }
    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "SwimBeat":
                if (!sources[0].isPlaying)
                {
                    PlaySoundDelayed(3f / playerVelocity);
                    Debug.Log("Wait time: " + (3f / playerVelocity));
                    sources[0].PlayOneShot(playerAudioSwimSounds[0]);
                }
                break;
            default:
                break;
        }
    }
    private IEnumerator PlaySoundDelayed(float wait)
    {
        yield return new WaitForSeconds(wait);
    }
}
