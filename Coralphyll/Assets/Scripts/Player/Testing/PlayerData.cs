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
    //[HideInInspector]
    public Vector3 steeringInput;

    public float leanAmountX;
    public float leanAmountY;

    public float diveForce;

    public bool diving;
    public bool swimmingUp;
    public bool turning;

    public void UpdateInputData(Vector3 newSteering, float newThrust)
    {
        steeringInput = newSteering;
        thrustInput = newThrust;
    }

    public void UpdateBoolData(bool swimUp, bool dive, bool isTurning)
    {
        diving = dive;
        swimmingUp = swimUp;
        turning = isTurning;
    }
}
