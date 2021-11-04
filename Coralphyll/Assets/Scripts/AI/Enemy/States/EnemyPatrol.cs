//Author: Pol Lozano Llorens
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyState/PatrolState")]
public class EnemyPatrol : EnemyState
{
    [SerializeField] private float chaseDistance;
    [SerializeField] private float hearingRange;
    [SerializeField] private float stoppingDistance;

    private Vector3 patrolPoint;

    public override void Enter()
    {
        base.Enter();
        //patrolPoint = GetPath(0);
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        //Set destination for movement
        if (DistanceToPoint(patrolPoint) < stoppingDistance)
        {
            //patrolPoint = GetPath().Next()
        }
    }

    public override void EvaluateTransitions()
    {
        base.EvaluateTransitions();
        if (CanSeePlayer() && DistanceToPlayer() < chaseDistance)
        {
            stateMachine.Transition<EnemyChase>();
        }
        if(DistanceToPlayer() < hearingRange)
        {
            stateMachine.Transition<EnemyAlert>();
        }
    }
}
