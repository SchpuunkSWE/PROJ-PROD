using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MorayState/ReturnToLairState")]
public class MorayReturnToLair : MorayState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        SetMorayPos(Vector3.MoveTowards(GetMorayPos().position, GetLairPos(), baseSpeed * Time.deltaTime));
    }

    public override void EvaluateTransitions()
    {
        base.EvaluateTransitions();
        //N�r tillr�ckligt n�ra(i princip i) lair, byt till idle state
    }
}
