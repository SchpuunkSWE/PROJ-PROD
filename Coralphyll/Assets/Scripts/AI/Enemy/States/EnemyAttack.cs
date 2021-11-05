//Author: Pol Lozano Llorens
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyState/AttackState")]
public class EnemyAttack : EnemyState
{
    [SerializeField] private float chaseDistance;
    [SerializeField] private float cooldown;
    [SerializeField] private float attackDistance;

    private float currentCooldown;
    private bool attacking;

    public override void Enter()
    {
        base.Enter();
        currentCooldown = cooldown;
        AIController.Renderer.material.color = Color.red;
        //AIController.Animator.SetBool("Attacking", true);
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        RotateTowards(AIController.Player.transform);

        //set destination to player
        if (DistanceToPlayer() < attackDistance && attacking == false)
            Attack();
        if (attacking)
            HandleCooldown();
    }

    public override void EvaluateTransitions()
    {
        base.EvaluateTransitions();
        if (!CanSeePlayer())
        {
            stateMachine.Transition<EnemyAlert>();
        }
        if (DistanceToPlayer() > chaseDistance)
        {
            stateMachine.Transition<EnemyChase>();
        }
    }

    private void Attack()
    {
        attacking = true;
        //Attack stuff
    }

    private void HandleCooldown()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown < 0)
        {
            attacking = false;
            currentCooldown = cooldown;
        }
    }

    public override void OnAnimationStarted()
    {
        //Turn On AttackCollider
        base.OnAnimationStarted();
    }

    public override void OnAnimationEnded()
    {
        //Turn Off AttackCollider
        base.OnAnimationEnded();
    }
}
