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
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        GotLungeTarget(sightRange);
    }

    public override void EvaluateTransitions()
    {
        base.EvaluateTransitions();
        //raycasta rakt fram fr�n mur�nan, om n�got kommer emellan s� byt till lunge state
        if (GotLungeTarget(sightRange))
        {
            stateMachine.Transition<MorayLunge>();
        }
    }
}
