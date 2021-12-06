//Author: Pol Lozano Llorens
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyState/PatrolState")]
public class EnemyPatrol : EnemyState
{
    [SerializeField] private float chaseDistance;
    [SerializeField] private float smellingRange = 20f;
    [SerializeField] private float stoppingDistance;


    private Transform patrolPoint;

    public override void Enter()
    {
        base.Enter();
        AIController.Renderer.material.color = Color.green;
        patrolPoint = AIController.Path.GetPath[0];
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        //Set destination for movement
        if (Vector3.Distance(AIController.transform.position, patrolPoint.position) < stoppingDistance)
        {
            patrolPoint = AIController.Path.Next();
        }
        AIController.transform.position = Vector3.MoveTowards(AIController.transform.position, patrolPoint.position, 5 * Time.deltaTime);
        RotateTowards(patrolPoint);
    }

    public override void EvaluateTransitions()
    {
        base.EvaluateTransitions();

        if (DistanceToPlayer() < smellingRange)
        {
            stateMachine.Transition<EnemyChase>();
        }
        else if (CanSeePlayer() && DistanceToPlayer() < chaseDistance && AIController.CanFollowPlayer)
        {
            stateMachine.Transition<EnemyChase>();
        }

        ////Molly Change
        //if (AIController.IsDazed)
        //{
        //    stateMachine.Transition<EnemyDazed>();
        //}

        /*if(DistanceToPlayer() < hearingRange)
        {
            
        }*/
    }
}
