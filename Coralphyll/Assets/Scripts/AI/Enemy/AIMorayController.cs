//Author: Molly Röle
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMorayController : MonoBehaviour
{
    [SerializeField]
    private Transform lungePoint;

    [SerializeField]
    private LayerMask playerLayer;

    [SerializeField] 
    private State[] states;

    private GameObject player;
    private Vector3 lairLocation;
    private Quaternion originalRotation;
    private StateMachine stateMachine;


    private void Awake()
    {
        lairLocation = transform.position; //Cache original location
        originalRotation = transform.rotation;
        stateMachine = new StateMachine(this, states);
        player = PlayerControllerKeybinds.Player.gameObject;
    }

    public GameObject GetPlayerObject()
    {
        return player;
    }
    public LayerMask GetPlayerLayer()
    {
        return playerLayer;
    }

    public Vector3 GetLairLocation()
    {
        return lairLocation;
    }

    public Transform GetLungePoint()
    {
        return lungePoint;
    }

    public Quaternion GetOriginalRotation()
    {
        return originalRotation;
    }

    public void UpdatePosition(Vector3 targetPos, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    //public void UpdateRotation(Quaternion targetRotation, float speed)
    //{
    //    Debug.Log("Current Rot: " + transform.rotation);
    //    Debug.Log("Target Rot:" + targetRotation);
    //    //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);
    //    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    //}//TODO: felsök denna

    public void ResetRotation()
    {
        transform.rotation = originalRotation;
    }

    public void Update() => stateMachine?.HandleUpdate();
    public void FixedUpdate() => stateMachine?.HandleFixedUpdate();
}
