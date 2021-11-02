using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInpuBehaviour : MonoBehaviour
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

    [Header("Data Output")]
    public PlayerData playerData;
    
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
    }
}
