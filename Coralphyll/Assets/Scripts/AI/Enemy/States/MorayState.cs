using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MorayState : State
{
    private AIMorayController morayController;
    public AIMorayController AIMorayController => morayController = morayController != null ? morayController : (AIMorayController)owner;

    protected float baseSpeed = 2f;
    private int playerLayer = 6;
    public override void Enter()
    {
        Debug.Log("ENTER: " + stateMachine.CurrentState + "   " + AIMorayController.transform.position);
    }

    public override void HandleUpdate()
    {

    }

    protected Vector3 GetLungePoint()
    {
        return morayController.LungePoint.position;
    }

    protected Transform GetPlayerPos()
    {
        return morayController.Player.transform;
    }

    protected Transform GetMorayPos()
    {
        return morayController.transform;
    }

    protected void SetMorayPos(Vector3 pos)
    {
        morayController.transform.position = pos;
    }

    protected Vector3 GetLairPos()
    {
        return morayController.LairLocation;
    }

    protected bool GotLungeTarget(float distance)
    {
        RaycastHit objectHit;
        Vector3 fwd = morayController.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(morayController.transform.position, fwd * distance, Color.green);
        //return Physics.Raycast(morayController.transform.position, fwd, out objectHit, distance, playerLayer);
        if(Physics.Raycast(morayController.transform.position, fwd, out objectHit, distance, playerLayer))
        {
            Debug.Log("Hit: " + objectHit.transform.gameObject.name);
            return true;
        }
        else
        {
            return false;
        }
    }
}
