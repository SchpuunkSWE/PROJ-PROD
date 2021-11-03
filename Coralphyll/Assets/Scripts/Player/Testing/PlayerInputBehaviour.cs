using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputBehaviour : MonoBehaviour
{

    [Header("Input Smoothing")]
    //Steering
    public float steeringSmoothing;
    private Vector3 rawInputSteering;
    private Vector3 smoothInputSteering;

    //Thrust
    public float thrustSmoothing;
    private float rawInputThrust;
    private float smoothInputThrust;

    //Diving
    public bool swimmingUp;
    public bool diving;

    [Header("Data Output")]
    public PlayerData playerData;

    public void OnSteering(float value)
    {
        rawInputSteering = new Vector3(0, 0, -value);
    }

    public void OnThrust(float value)
    {
        rawInputThrust = value;
    }

    public void OnDive(bool b)
    {
        diving = b;
    }

    public void OnSwimUp(bool b)
    {
        swimmingUp = b;
    }

    public void ResetMomentum()
    {
        rawInputThrust = -rawInputThrust;
        rawInputSteering = Vector3.zero;
        diving = false;
        swimmingUp = false;
    }

    void Update()
    {
        InputSmoothing();
        SetInputData();
    }

    void InputSmoothing()
    {
        //Steering
        smoothInputSteering = Vector3.Lerp(smoothInputSteering, rawInputSteering, Time.deltaTime * steeringSmoothing);

        //Thrust
        smoothInputThrust = Mathf.Lerp(smoothInputThrust, rawInputThrust, Time.deltaTime * thrustSmoothing);
    }

    void SetInputData()
    {
        playerData.UpdateInputData(smoothInputSteering, smoothInputThrust);
        playerData.UpdateBoolData(swimmingUp, diving);
    }
}
