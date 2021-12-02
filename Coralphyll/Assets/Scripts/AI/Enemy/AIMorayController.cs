using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMorayController : MonoBehaviour
{
    [HideInInspector]
    public Transform LungePoint;

    [HideInInspector]
    public GameObject Player;

    [HideInInspector]
    public Vector3 LairLocation;

    [SerializeField] 
    private State[] states;

    private StateMachine stateMachine;


    private void Awake()
    {
        LairLocation = transform.position; //Cache original location
        stateMachine = new StateMachine(this, states);
        Player = PlayerControllerKeybinds.Player.gameObject;
        LungePoint = GetComponentInChildren<Transform>();
    }

    public void Update() => stateMachine?.HandleUpdate();
    public void FixedUpdate() => stateMachine?.HandleFixedUpdate();
}
