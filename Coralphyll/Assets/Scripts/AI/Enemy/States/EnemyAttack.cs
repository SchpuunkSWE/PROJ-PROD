//Author: Pol Lozano Llorens
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyState/AttackState")]
public class EnemyAttack : EnemyState
{
    [SerializeField] private float chaseDistance;
    [SerializeField] private float cooldown;
    [SerializeField] private float attackDistance; //How close player has to be to trigger an attack
    [SerializeField] private float attackRange; //How far attack will reach
    [SerializeField] private float fishPerBite;

    private float currentCooldown;
    private bool attacking;

    public override void Enter()
    {
        base.Enter();
        currentCooldown = cooldown;
        //AIController.Renderer.material.color = Color.red;
        //AIController.Animator.SetBool("Attacking", true);
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        RotateTowards(AIController.Player.transform);

        if (DistanceToPlayer() < attackDistance && attacking == false)
        {
            attacking = true;
            AIController.Animator.SetTrigger("attack");
        }

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
        //AIController.Renderer.material.color = Color.magenta;

        if (currentCooldown < 0)
        {
            attacking = false;
            //AIController.Renderer.material.color = Color.red;
            currentCooldown = cooldown;
        }
    }


    public override void OnAnimationEnded()
    {
        //Trigger Attack
        if (DistanceToPlayer() < attackRange)
        {
            Attack();
        }
    }
}
