//Author: Pol Lozano Llorens
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyState/ChaseState")]
public class EnemyChase : EnemyState
{
    [SerializeField] private float attackDistance;
    [SerializeField] private float lostTargetDistance;

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        //Set destination to player
        AIController.transform.position = Vector3.MoveTowards(AIController.transform.position, AIController.Player.transform.position, 5 * Time.deltaTime);
    }

    public override void EvaluateTransitions()
    {
        base.EvaluateTransitions();

        if (!CanSeePlayer())
        {
            stateMachine.Transition<EnemyAlert>();
        }
        else if (Vector3.Distance(AIController.AttackPoint.position, AIController.Player.transform.position) < attackDistance)
        {
            stateMachine.Transition<EnemyAttack>();
        }
        else if (DistanceToPlayer() > lostTargetDistance)
        {
            stateMachine.Transition<EnemyPatrol>();
        }
    }
}
