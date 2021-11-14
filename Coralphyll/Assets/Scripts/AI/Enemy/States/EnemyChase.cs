//Author: Pol Lozano Llorens
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyState/ChaseState")]
public class EnemyChase : EnemyState
{
    [SerializeField] private float attackDistance;
    [SerializeField] private float lostTargetDistance;

    public override void Enter()
    {
        base.Enter();
        AIController.Renderer.material.color = Color.yellow;
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        //Set destination to player
        AIController.transform.position = Vector3.MoveTowards(AIController.transform.position, AIController.Player.transform.position, 5 * Time.deltaTime);
        RotateTowards(AIController.Player.transform);
    }

    public override void EvaluateTransitions()
    {
        base.EvaluateTransitions();
        if (!CanSeePlayer() || AIController.CanFollowPlayer == false)
        {
            stateMachine.Transition<EnemyPatrol>();
        }
        else if (DistanceToPlayer() < attackDistance)
        {
            stateMachine.Transition<EnemyAttack>();
        }
        else if (DistanceToPlayer() > lostTargetDistance)
        {
            stateMachine.Transition<EnemyPatrol>();
        }
    }
}
