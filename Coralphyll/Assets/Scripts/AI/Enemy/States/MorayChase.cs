//Author: Molly Röle
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MorayState/ChaseState")]
public class MorayChase : MorayState
{
    [SerializeField]
    private float chaseSpeed = 2f;

    private float chaseDistance = 20f; //changed from 10f
    public override void Enter()
    {
        base.Enter();
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        AIMorayController.UpdatePosition(GetPlayerPos().position, chaseSpeed);
        GetMorayPos().transform.LookAt(GetPlayerPos());
    }

    public override void EvaluateTransitions()
    {
        base.EvaluateTransitions();
        //If close enough to player, attack
        if (Vector3.Distance(GetMorayPos().position, GetPlayerPos().position) <= attackDistance)
        {
            stateMachine.Transition<MorayAttack>();
        }

        //If player gets away, go back to lair
        if (Vector3.Distance(GetMorayPos().position, GetPlayerPos().position) >= chaseDistance)
        {
            stateMachine.Transition<MorayReturnToLair>();
        }
    }
}
