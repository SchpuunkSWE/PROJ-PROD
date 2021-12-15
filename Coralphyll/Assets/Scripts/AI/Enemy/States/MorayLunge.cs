//Author: Molly Röle
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MorayState/LungeState")]
public class MorayLunge : MorayState
{
    [SerializeField]
    private float lungeSpeed = 50f;
    private float allowedDistance = 0.5f;
    private bool hasLunged = false;
    private bool runOnce = false; //Only log once
    public override void Enter()
    {
        base.Enter();
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        AIMorayController.UpdatePosition(GetLungePoint(), lungeSpeed);
        hasLunged = Vector3.Distance(GetMorayPos().position, GetLungePoint()) <= allowedDistance;
        if (!runOnce)
        {
            Logger.LoggerInstance.CreateTextFile("#FirstTimeMorayLunged");
            runOnce = true;
        }
    }

    public override void EvaluateTransitions()
    {
        base.EvaluateTransitions();
        //If finished lunging and close enough to player, attack
        if(hasLunged)
        {
            if (Vector3.Distance(GetMorayPos().position, GetPlayerPos().position) <= attackDistance)
            {
                stateMachine.Transition<MorayAttack>();
            }
            //If not, start chasing
            else
            {
                stateMachine.Transition<MorayChase>();
            }
        }
    }
}
