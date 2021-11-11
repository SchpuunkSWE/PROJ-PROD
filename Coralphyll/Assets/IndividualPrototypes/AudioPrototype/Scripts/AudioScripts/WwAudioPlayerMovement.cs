using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwAudioPlayerMovement : MonoBehaviour
{
    AkSoundEngine akSoundEngine;

    void Start()
    {
        akSoundEngine = GetComponent<AkSoundEngine>();

    }
}
