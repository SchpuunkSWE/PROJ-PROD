//Author: Molly Röle
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MorayState/ReturnToLairState")]
public class MorayReturnToLair : MorayState
{
    private float allowedDistance = 0.2f;
    public override void Enter()
    {
        base.Enter();
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        AIMorayController.UpdatePosition(GetLairPos(), baseSpeed);
    }

    public override void EvaluateTransitions()
    {
        base.EvaluateTransitions();
        //When back at lair, transition to Idle State
        if(Vector3.Distance(GetMorayPos().position, GetLairPos()) < allowedDistance)
        {
            stateMachine.Transition<MorayIdle>();
        }
    }

    public override void Exit()
    {
        base.Exit(); 
    }
}
