//Author: Molly Röle
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MorayState/AttackState")]
public class MorayAttack : MorayState
{
    [SerializeField] 
    private float fishPerBite = 1;

    bool hasFed = false;
    public override void Enter()
    {
        base.Enter();
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        Attack();
    }
    private void Attack()
    {
        NPCFishUtil fishUtil = AIMorayController.GetPlayerObject().GetComponent<NPCFishUtil>();
        var fishes = fishUtil.getListOfFishes();
        if (fishes.Count > 0)
        {
            for (int i = 0; i < fishPerBite; i++)
                fishUtil.KillFish();
        }
        else
        {
            //Kill player if it has no fishes picked up
            DeathInfo d = new DeathInfo
            {
                victim = AIMorayController.GetPlayerObject(),
                killer = AIMorayController.gameObject
            };
            EventHandler<DeathEvent>.FireEvent(new DeathEvent(d));
        }

        hasFed = true;
    }
    public override void EvaluateTransitions()
    {
        base.EvaluateTransitions();
        if (hasFed)
        {
            stateMachine.Transition<MorayReturnToLair>();
        }
    }
}
