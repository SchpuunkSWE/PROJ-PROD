using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_cinemamode : MonoBehaviour
{



    public void CinemaMode()
    {
        FindObjectOfType<Audio_Pause>().CinemaMode();
    }
    public void CinemaModeOff()
    {
        FindObjectOfType<Audio_Pause>().CinemaModeOff();
    }
}
