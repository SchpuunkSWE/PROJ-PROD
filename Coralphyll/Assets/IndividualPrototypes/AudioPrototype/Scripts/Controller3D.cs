using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller3D : MonoBehaviour
{
    public Vector3 velocity;
    public float speed = 30f;
    public Vector3 playerInput;
    public float decelerateValue = 7f;
    public float velocityXSmoothValue = 0.2f;
    public float velocityZSmoothValue = 0.2f;
    public float maxVelocityValue = 20f;
    public CapsuleCollider capsuleCollider;
    public LayerMask collisionMask;
    [SerializeField] private float skinWidth = 0.05f;
    public float standardStaticFrictionVariable = 0.5f;
    public float kineticFrictionVariable = 0.16f;
    public float airResistance = 0.8f;
    public float gravity = 9f;
    public float jumpForce = 25f;

    public bool isGrounded;
    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        ApplyGravity();
        HitDetection();
        ApplyVelocity();

    }
    private void PlayerInput()
    {
        playerInput = transform.right * Input.GetAxisRaw("Horizontal") + transform.forward * Input.GetAxisRaw("Vertical");
        if (playerInput.magnitude > float.Epsilon)
        {
            if (velocity.magnitude < 1f)
            {
                velocity += playerInput.normalized;
            }
            CalculateVelocity(playerInput);

        }
        else
        {
            DecelerateVelocity();
        }
    }
    private void CalculateVelocity(Vector3 input)
    {
        velocity += input.normalized * speed * Time.deltaTime;
        if (velocity.magnitude > maxVelocityValue)
        {
            velocity = velocity.normalized * maxVelocityValue;
        }
    }
    private void ApplyVelocity()
    {

        velocity *= Mathf.Pow(airResistance, Time.deltaTime);
        transform.position += velocity * Time.deltaTime;
    }
    private void ApplyGravity()
    {
        velocity += Vector3.down * gravity * Time.deltaTime;
    }
    private void DecelerateVelocity()
    {
        Vector3 projectedDir = new Vector3(velocity.x, 0.0f, velocity.z);
        float absValue = Mathf.Abs(projectedDir.magnitude);
        projectedDir = projectedDir.normalized;
        if (decelerateValue > absValue)
        {
            velocity.x = Mathf.SmoothDamp(velocity.x, 0, ref velocityXSmoothValue, 0.2f);
            velocity.z = Mathf.SmoothDamp(velocity.z, 0, ref velocityZSmoothValue, 0.2f);
        }
        else
        {
            velocity -= projectedDir * decelerateValue * Time.deltaTime;

            /* This might be necessary to include for smoother deceleration 
            velocity.x = Mathf.SmoothDamp(velocity.x, 0, ref velocityXSmoothValue, 0.1f);
             velocity.z = Mathf.SmoothDamp(velocity.z, 0, ref velocityZSmoothValue, 0.1f);*/
        }

    }

    private void HitDetection()
    {
        //Capsule cast to check for collissions. 
        RaycastHit hit;
        Vector3 upperPoint = transform.position + Vector3.up * (capsuleCollider.height / 2 - capsuleCollider.radius);
        Vector3 lowerPoint = transform.position + Vector3.down * (capsuleCollider.height / 2 - capsuleCollider.radius);
        Physics.CapsuleCast(upperPoint, lowerPoint, capsuleCollider.radius, velocity.normalized, out hit, Mathf.Infinity, collisionMask);
        Debug.DrawLine(upperPoint, velocity.normalized, Color.red);
        Debug.DrawLine(lowerPoint, velocity.normalized, Color.blue);

        //Raycast to check if player is grounded.
        RaycastHit checkGround;
        Physics.Raycast(transform.position, Vector3.down, out checkGround, Mathf.Infinity, collisionMask);
        if (checkGround.collider)
        {
            float distanceToCollisionPoint = skinWidth / Vector3.Dot(velocity.normalized, hit.normal);
            float allowedMovementDistance = hit.distance + distanceToCollisionPoint;
            if (allowedMovementDistance > velocity.magnitude * Time.deltaTime)
            {
                isGrounded = false;
                return;
            }
            isGrounded = true;

        }

        if (hit.collider) //If the capsulecast hit anything within velocity.normalized range
        {
            float distanceToCollisionPoint = skinWidth / Vector3.Dot(velocity.normalized, hit.normal);
            float allowedMovementDistance = hit.distance + distanceToCollisionPoint;
            if (allowedMovementDistance > velocity.magnitude * Time.deltaTime)
            {
                return;
            }
            transform.position += hit.normal * (skinWidth + Vector3.Dot(velocity.normalized * hit.distance, hit.normal));

            Vector3 dotProd = DotFunction(velocity, hit.normal);
            velocity += dotProd;
            FrictionFunction(dotProd.magnitude);


        }
    }
    private Vector3 DotFunction(Vector3 velocityV, Vector3 hitNormal)
    {
        float dotProduct = Vector3.Dot(velocityV, hitNormal);
        if (dotProduct > 0)   //Check if we hit any surface with a normal that points in the same direction as we are moving
        {
            dotProduct = 0;
        }
        Vector3 projection = dotProduct * hitNormal;
        return -projection;
    }
    private void FrictionFunction(float magnitude)
    {
        if (velocity.magnitude < magnitude * standardStaticFrictionVariable) // If we are moving slower than this, then stop.
        {
            velocity = Vector3.zero;
        }
        else
        {
            velocity -= velocity.normalized * magnitude * kineticFrictionVariable;
        }
    }

    //DISCLAIMER: The JumpFunction and DiveFunction are placeholders for now since this should be something that exists in the playerInput section for moving along the Y-axis. 
    //But for now, it's at least some way to move straight up and down when testing. They simply add a positive or negative force to the velocity.y as long as
    //The magnitude of velocity.y is greater than 8f.
    public void JumpFunction()
    {
        Vector3 maxVel = velocity;
        if (!(maxVel.y > 8f))
        {
            Vector3 jumping = Vector3.up * jumpForce;
            if (velocity.x == 0 || velocity.z == 0)
            {
                velocity.y += jumping.y * 0.6f;
            }
            else
            {
                velocity.y += jumping.y;
            }
        }
    }
    public void DiveFunction()
    {
        Vector3 maxVel = velocity;
        if (!(maxVel.y < -8f))
        {
            Vector3 jumping = -1 * (Vector3.up * jumpForce);
            if (velocity.x == 0 || velocity.z == 0)
            {
                velocity.y += jumping.y * 0.6f;
            }
            else
            {
                velocity.y += jumping.y;
            }
        }
    }

}
