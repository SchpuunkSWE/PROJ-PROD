//Author: Pol Lozano Llorens
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyState/AttackState")]
public class EnemyAttack : EnemyState
{
    [SerializeField] private float chaseDistance;
    [SerializeField] private float cooldown;
    [SerializeField] private float attackDistance;
    [SerializeField] private float fishPerBite;

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
        //Do not transition during cooldown
        if (!attacking)
        {
            if (!CanSeePlayer())
            {
                stateMachine.Transition<EnemyAlert>();
            }
            if (DistanceToPlayer() > chaseDistance)
            {
                stateMachine.Transition<EnemyChase>();
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        //Attack stuff
        NPCFishUtil fishUtil = AIController.Player.GetComponent<NPCFishUtil>();
        var fishes = fishUtil.getListOfFishes();
        float amountToKill = Mathf.Min(fishPerBite, fishes.Count);
        if (fishes.Count > 0)
        {
            for (int i = 0; i < amountToKill; i++)
            {
                fishUtil.KillFish();
            }       
        }
        else
        {
            //Kill player if it has no fishes picked up
            DeathInfo d = new DeathInfo
            {
                victim = AIController.Player,
                killer = AIController.gameObject
            };
            EventHandler<DeathEvent>.FireEvent(new DeathEvent(d));
        }
    }

    private void HandleCooldown()
    {
        currentCooldown -= Time.deltaTime; 
        AIController.Renderer.material.color = Color.magenta;

        if (currentCooldown < 0)
        {
            attacking = false;
            AIController.Renderer.material.color = Color.red;
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
