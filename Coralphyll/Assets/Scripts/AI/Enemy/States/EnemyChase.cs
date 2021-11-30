//Author: Pol Lozano Llorens
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyState/ChaseState")]
public class EnemyChase : EnemyState
{
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float raycastOffset = 1.5f;
    [SerializeField] private LayerMask collisionMask;

    [SerializeField] private float baseChaseSpeed = 5;
    [SerializeField] private float fishFactor = .5f;
    [SerializeField] private float checkCooldown = 2;
    private float currentCheckCooldown;
    private int fishAmount;

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
        HandleCooldown();

        //Set destination to player
        PathFinding();
        Move();
        //AIController.transform.position = Vector3.MoveTowards(AIController.transform.position, AIController.Player.transform.position, baseChaseSpeed * (1 + fishFactor * fishAmount) * Time.deltaTime);
    }

    private void Move()
    {
        AIController.transform.position += AIController.transform.forward * baseChaseSpeed * (1 + fishFactor * fishAmount) * Time.deltaTime;
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
            fishAmount = fishUtil.getListOfFishes().Count;
        }
    }
    

    //This is pretty broken sadly :(
    private void PathFinding()
    {
        RaycastHit hit;
        Vector3 offset = Vector3.zero;

        Vector3 left = AIController.transform.position - AIController.transform.right * raycastOffset;
        Vector3 right = AIController.transform.position + AIController.transform.right * raycastOffset;
        Vector3 up = AIController.transform.position + AIController.transform.up * raycastOffset;
        Vector3 down = AIController.transform.position - AIController.transform.up * raycastOffset;

        Debug.DrawRay(left, AIController.transform.forward * detectionRange, Color.red);
        Debug.DrawRay(right, AIController.transform.forward * detectionRange, Color.red);
        Debug.DrawRay(up, AIController.transform.forward * detectionRange, Color.red);
        Debug.DrawRay(down, AIController.transform.forward * detectionRange, Color.red);

        if (Physics.Raycast(left, AIController.transform.forward, out hit, detectionRange, collisionMask))
            offset += Vector3.right;
        else if (Physics.Raycast(right, AIController.transform.forward, out hit, detectionRange, collisionMask))
            offset -= Vector3.right;

        if (Physics.Raycast(up, AIController.transform.forward, out hit, detectionRange, collisionMask))
            offset += Vector3.up;
        else if (Physics.Raycast(down, AIController.transform.forward, out hit, detectionRange, collisionMask))
            offset -= Vector3.up;

        if (offset != Vector3.zero)
            AIController.transform.Rotate(offset * 5f * Time.deltaTime);
        else
            RotateTowards(AIController.Player.transform);
    }
}
