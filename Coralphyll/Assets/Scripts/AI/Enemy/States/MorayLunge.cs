using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MorayState/LungeState")]
public class MorayLunge : MorayState
{
    [SerializeField]
    private float lungeSpeed = 50f;
    public override void Enter()
    {
        base.Enter();
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        SetMorayPos(Vector3.MoveTowards(GetMorayPos().position, GetPlayerPos().position, lungeSpeed * Time.deltaTime));
        //GetMorayPos().transform.LookAt(GetPlayerPos());
    }

    public override void EvaluateTransitions()
    {
        base.EvaluateTransitions();
        //Om tr�ffat spelaren/�tit en fisk:
            //Simma tillbaka till lair
        //Om inte tr�ffat spelaren/�tit en fisk:
            //Stalk/f�lj efter en kort bit
    }
}
