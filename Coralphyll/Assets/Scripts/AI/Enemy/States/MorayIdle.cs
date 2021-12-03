//Author: Molly Röle
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "MorayState/IdleState")]
public class MorayIdle : MorayState
{
    [SerializeField]
    private float sightRange = 15f;
    public override void Enter()
    {
        base.Enter();
        AIMorayController.ResetRotation();
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
    }

    public override void EvaluateTransitions()
    {
        base.EvaluateTransitions();
        
        //If player is between moray and end of raycast, lunge
        if (GotLungeTarget(sightRange))
        {
            stateMachine.Transition<MorayLunge>();
        }
    }
}
