//Author: Molly Röle
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyState/DazedState")]
public class EnemyDazed : EnemyState
{
    //private float timer = 0f;
    //private float waitTime = 4.0f;

    //private bool finishedBeingDazed = false;
    //public override void Enter()
    //{
    //    base.Enter();
    //    AIController.Renderer.material.color = Color.magenta;
    //    finishedBeingDazed = false;
    //    Debug.Log("Enemy Entered Dazed State!");
    //}
    //public override void HandleUpdate()
    //{
    //    base.HandleUpdate();
    //    //Rotate weirdly to show dazed
    //    //Play dazed particles

    //    //count time being dazed
    //    //while (timer < waitTime)
    //    //{
    //    //    timer += Time.deltaTime;
    //    //    Debug.Log("Pausing for " + timer + "..");
    //    //}
    //    finishedBeingDazed = true;
    //}
    //public override void EvaluateTransitions()
    //{
    //    base.EvaluateTransitions();

    //    //When having been dazed for x amount of time, transition back to patrolling
    //    if (finishedBeingDazed)
    //    {
    //        stateMachine.Transition<EnemyPatrol>();
    //        AIController.IsDazed = false;
    //    }
    //}
}
