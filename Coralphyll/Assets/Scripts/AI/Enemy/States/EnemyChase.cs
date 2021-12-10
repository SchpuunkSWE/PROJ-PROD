//Author: Pol Lozano Llorens
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyState/ChaseState")]
public class EnemyChase : EnemyState
{
    [SerializeField] private float baseChaseSpeed = 5;
    [SerializeField] private float fishFactor = .5f;
    [SerializeField] private float checkCooldown = 2;
    private float currentCheckCooldown;
    private int fishAmount;

    [SerializeField] private float attackDistance;
    [SerializeField] private float lostTargetDistance;
    [SerializeField] private float smellingRange= 2f; //how close the enemy can be and feel the player even if they cant see them

    public override void Enter()
    {
        base.Enter();
        //AIController.Renderer.material.color = Color.yellow;
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        //Set destination to player
        AIController.transform.position = Vector3.MoveTowards(AIController.transform.position, AIController.Player.transform.position, baseChaseSpeed * (1 + fishFactor * fishAmount) * Time.deltaTime);
        RotateTowards(AIController.Player.transform);
        HandleCooldown();
    }

    public override void EvaluateTransitions()
    {
        base.EvaluateTransitions();

        //Molly Change
        //if (AIController.IsDazed)
        //{
        //    stateMachine.Transition<EnemyDazed>();
        //}CULPRIT
        if (!CanSeePlayer() && DistanceToPlayer() > smellingRange || AIController.CanFollowPlayer == false)
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
            fishAmount = fishUtil.getListOfFishes().Count;
        }
    }
}
