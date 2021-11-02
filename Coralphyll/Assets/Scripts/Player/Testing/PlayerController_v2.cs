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
    
    private Vector3 playerInput;

    public void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        rb.velocity = transform.forward * data.thrustAmount * (Mathf.Max(data.thrustInput,.2f));
    }

    private void Turn()
    {
        playerInput = new Vector3(-Input.GetAxisRaw("Vertical") * data.pitchSpeed, Input.GetAxisRaw("Horizontal") * data.yawSpeed, 0); //transform.right * Input.GetAxisRaw("Horizontal") + transform.forward * Input.GetAxisRaw("Vertical");
        rb.AddRelativeTorque(playerInput);

        rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.Euler(new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y,0)), 0.5f);

        VisualTurn();
    }

    private void VisualTurn()
    {
        playerModel.localEulerAngles = new Vector3(Input.GetAxisRaw("Vertical") * data.leanAmountY,
            playerModel.localEulerAngles.y, -Input.GetAxisRaw("Horizontal") * data.leanAmountX);
    }
}
