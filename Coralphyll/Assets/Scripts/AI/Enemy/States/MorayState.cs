//Author: Molly Röle
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MorayState : State
{
    private AIMorayController morayController;
    public AIMorayController AIMorayController => morayController = morayController != null ? morayController : (AIMorayController)owner;

    protected float baseSpeed = 2f;
    protected float attackDistance = 1f;

    public override void Enter()
    {
        Debug.Log("ENTER: " + stateMachine.CurrentState + "   " + AIMorayController.transform.position);
    }

    protected Vector3 GetLungePoint()
    {
        return AIMorayController.GetLungePoint().position;
    }

    protected Transform GetPlayerPos()
    {
        return AIMorayController.GetPlayerObject().transform;
    }

    protected Transform GetMorayPos()
    {
        return AIMorayController.transform;
    }

    protected void SetMorayPos(Vector3 pos)
    {
        AIMorayController.transform.position = pos;
    }

    protected Vector3 GetLairPos()
    {
        return AIMorayController.GetLairLocation();
    }

    protected bool GotLungeTarget(float distance)
    {
        RaycastHit objectHit;
        Vector3 fwd = AIMorayController.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(AIMorayController.transform.position, fwd * distance, Color.green);
        //return Physics.Raycast(morayController.transform.position, fwd, out objectHit, distance, playerLayer);
        if(Physics.Raycast(morayController.transform.position, fwd, out objectHit, distance, AIMorayController.GetPlayerLayer()))
        {
            Debug.Log("Hit: " + objectHit.transform.gameObject.name);
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void HandleUpdate()
    {

    }
}
