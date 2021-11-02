//Author: Pol Lozano Llorens
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyState/AlertState")]
public class EnemyAlert : EnemyState
{
    [SerializeField] private float chaseDistance;
    [SerializeField] private float alertTime;
    private float alertTimer;

    public override void Enter()
    {
        base.Enter();
        //Set destination towards player
        alertTimer = alertTime;
    }

    public override void HandleUpdate()
    {
        alertTimer -= Time.deltaTime;
    }

    public override void EvaluateTransitions()
    {
        base.EvaluateTransitions();
        if (CanSeePlayer() && DistanceToPlayer() < chaseDistance)
            stateMachine.Transition<EnemyChase>();
        if (alertTimer < 0)
            stateMachine.Transition<EnemyPatrol>();
    }
}
