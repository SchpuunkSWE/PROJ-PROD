using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_v2 : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform playerModel;
    [SerializeField] private float pitchSpeed;
    [SerializeField] private float yawSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float leanAmountX;
    [SerializeField] private float leanAmountY;


    private Vector3 playerInput;

    public void Update()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        rb.velocity = transform.forward * speed * (Mathf.Max(speed,.2f));
    }

    private void Turn()
    {
        playerInput = new Vector3(-Input.GetAxisRaw("Vertical") * pitchSpeed, Input.GetAxisRaw("Horizontal") * yawSpeed, 0); //transform.right * Input.GetAxisRaw("Horizontal") + transform.forward * Input.GetAxisRaw("Vertical");
        rb.AddRelativeTorque(playerInput);

        rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.Euler(new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y,0)), 0.5f);

        VisualTurn();
    }

    private void VisualTurn()
    {
        playerModel.localEulerAngles = new Vector3(Input.GetAxisRaw("Vertical") * leanAmountY,
            playerModel.localEulerAngles.y, -Input.GetAxisRaw("Horizontal") * leanAmountX);
    }
}
