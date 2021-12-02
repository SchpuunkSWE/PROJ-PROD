using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MorayState/ChaseState")]
public class MorayChase : MorayState
{
    [SerializeField]
    private float chaseSpeed = 2f;
    public override void Enter()
    {
        base.Enter();
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        SetMorayPos(Vector3.MoveTowards(GetMorayPos().position, GetPlayerPos().position, chaseSpeed * Time.deltaTime));
        GetMorayPos().transform.LookAt(GetPlayerPos());
    }

    public override void EvaluateTransitions()
    {
        base.EvaluateTransitions();
        //Jaga en liten bit, byt sedan till ReturnToLair-state
    }
}
