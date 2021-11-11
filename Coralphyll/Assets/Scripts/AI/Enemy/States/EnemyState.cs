//Author: Pol Lozano Llorens
using UnityEngine;

public abstract class EnemyState : State
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float turnSpeed;

    private AIController aiController;
    public AIController AIController => aiController = aiController != null ? aiController : (AIController)owner;

    public override void Enter()
    {
        AIController.Speed = moveSpeed;
        Debug.Log("ENTER: " + stateMachine.CurrentState + "   " + AIController.transform.position);
    }
    public override void HandleUpdate()
    {
        //Set animator stuff?
    }

    protected bool CanSeePlayer()
    {
        //TODO Fix better line of sight
        return !Physics.Linecast(aiController.transform.position, aiController.Player.transform.position, aiController.VisionMask);
    }

    protected float DistanceToPoint(Vector3 point)
    {
        return Vector3.Distance(AIController.AttackPoint.transform.position, point);
    }

    protected float DistanceToPlayer()
    {
        return DistanceToPoint(aiController.Player.transform.position);
    }

    protected void RotateTowards(Transform target)
    {
        if(Vector3.Distance(AIController.AttackPoint.position, target.position) > .1f)
        {
            Vector3 dir = target.position - AIController.transform.position;
            Quaternion toRotation = Quaternion.LookRotation(dir);
            AIController.transform.rotation = Quaternion.Lerp(AIController.transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }
    }
}
