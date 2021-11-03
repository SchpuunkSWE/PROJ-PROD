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
        rb.velocity = transform.forward * data.thrustAmount * (Mathf.Max(data.thrustInput,0));
    }

    private void Turn()
    {
        Vector3 newTorque = new Vector3(0, -data.steeringInput.z * data.yawSpeed, 0); //transform.right * Input.GetAxisRaw("Horizontal") + transform.forward * Input.GetAxisRaw("Vertical");
        rb.AddRelativeTorque(newTorque);

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
