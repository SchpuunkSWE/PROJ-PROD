using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Scriptable Objects/Player Data", order = 1)]
public class PlayerData : ScriptableObject
{
    [Header("Movement")]
    public float thrustAmount;
    //[HideInInspector]
    public float thrustInput;

    public float yawSpeed;
    public float pitchSpeed;
    //[HideInInspector]
    public Vector3 steeringInput;

    public float leanAmountX;
    public float leanAmountY;

    public void UpdateInputData(Vector3 newSteering, float newThrust)
    {
        steeringInput = newSteering;
        thrustInput = newThrust;
    }
}
