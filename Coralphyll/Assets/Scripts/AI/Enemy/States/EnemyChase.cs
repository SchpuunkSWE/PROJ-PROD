//Author: Pol Lozano Llorens
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyState/ChaseState")]
public class EnemyChase : EnemyState
{
    [SerializeField] private float baseChaseSpeed = 5;
    [SerializeField] private float fishFactor;
    [SerializeField] private float checkCooldown = 2;
    private float currentCheckCooldown;

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
        AIController.transform.position = Vector3.MoveTowards(AIController.transform.position, AIController.Player.transform.position, baseChaseSpeed * 1 + fishFactor * Time.deltaTime);
        RotateTowards(AIController.Player.transform);
    }

    public override void EvaluateTransitions()
    {
        base.EvaluateTransitions();

        //Molly Change
        //if (AIController.IsDazed)
        //{
        //    stateMachine.Transition<EnemyDazed>();
        //}CULPRIT
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

    private void HandleCooldown()
    {
        currentCheckCooldown -= Time.deltaTime;
        if (currentCheckCooldown < 0)
        {
            currentCheckCooldown = checkCooldown;
            NPCFishUtil fishUtil = AIController.Player.GetComponent<NPCFishUtil>();
            fishFactor = fishUtil.getListOfFishes().Count;
        }
    }
}
