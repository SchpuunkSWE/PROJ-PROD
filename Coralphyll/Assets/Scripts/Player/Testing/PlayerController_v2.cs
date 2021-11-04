using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_v2 : MonoBehaviour
{
    [Header("Player Settings")]
    public PlayerData data;

    [Header("Physics")]
    [SerializeField] private Rigidbody rb;

    [Header("Player Model")]
    [SerializeField] private Transform playerModel;

    public void FixedUpdate()
    {
        Move();
        Turn();
        if(data.swimmingUp)
            SwimUp();
        if(data.diving)
            Dive();
    }

    private void Move()
    {
        rb.velocity = transform.forward * data.thrustAmount * data.thrustInput;
    }

    private void Turn()
    {
        float turnVelocity = rb.angularVelocity.y;
        Vector3 newTorque = new Vector3(0, -data.steeringInput.z * data.yawSpeed, 0); //transform.right * Input.GetAxisRaw("Horizontal") + transform.forward * Input.GetAxisRaw("Vertical");
        if (data.turning && Mathf.Abs(turnVelocity) < 2)
        {
           rb.AddRelativeTorque(newTorque);
        }
        else
        {
            if(turnVelocity > 0.1f)
                rb.AddRelativeTorque(Vector3.down * 0.5f);
            if (turnVelocity < -0.1f)
                rb.AddRelativeTorque(Vector3.up * 0.5f);
            if (Mathf.Abs(turnVelocity) < 0.1f)
                rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, Vector3.zero, 0.5f);
        }

        rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.Euler(new Vector3(0, transform.localEulerAngles.y, 0)), 0.5f); //WARNING: DANGER ZONE

        VisualTurn();
    }

    private void VisualTurn()
    {
        playerModel.localEulerAngles = new Vector3(data.steeringInput.x * data.leanAmountY,
            playerModel.localEulerAngles.y, data.steeringInput.z * data.leanAmountX);
    }

    private void SwimUp()
    {
        Debug.Log("Attempting to swim up");
        rb.AddForce(Vector3.up * data.diveForce, ForceMode.Impulse);
    }

    private void Dive()
    {
        Debug.Log("Attempting to dive");
        rb.AddForce(Vector3.down * data.diveForce, ForceMode.Impulse);
    }
}
