using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller3DKeybinds : MonoBehaviour
{
    public Vector3 velocity;

    [SerializeField]
    private float speed = 30f;

    public float Speed { get => speed; set => speed = value; }

    [SerializeField]
    private  float oGspeed = 30;
    public float OGSpeed { get => oGspeed;}

    public Vector3 playerInput;
    public float decelerateValue = 7f;
    public float velocityXSmoothValue = 0.2f;
    public float velocityZSmoothValue = 0.2f;
    public float velocityYSmoothValue = 0.2f;

    public float maxVelocityValue = 5f;
    public float MaxVelocityValue { get => maxVelocityValue; set => maxVelocityValue = value; }

    public float oGMaxVelocityValue = 5f;
    public float OGMaxVelocityValue { get => oGMaxVelocityValue; }

    //public CapsuleCollider capsuleCollider;
    public SphereCollider sphereCollider;
    public LayerMask collisionMask;
    [SerializeField] private float skinWidth = 0.05f;
    public float standardStaticFrictionVariable = 0.5f;
    public float kineticFrictionVariable = 0.16f;
    public float airResistance = 0.8f;
    [HideInInspector] public float gravity = 9f;
    public float jumpForce = 8f;
    public float maxJumpForce = 8f;
    public bool isGrounded;
    private void Awake()
    {
        //capsuleCollider = GetComponent<CapsuleCollider>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        //ApplyGravity();
        HitDetection();
        ApplyVelocity();

    }

    
    private void PlayerInput()
    {
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

    #region Velocity
    private void CalculateVelocity(Vector3 input)
    {
        velocity += input.normalized * speed * Time.deltaTime;
        Vector3 lateralVelocity = new Vector3(velocity.x, 0, velocity.z);
        if (lateralVelocity.magnitude > maxVelocityValue)
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
        Vector3 projectedDir = velocity;//new Vector3(velocity.x, 0.0f, velocity.z);
        float absValue = Mathf.Abs(projectedDir.magnitude);
        projectedDir = projectedDir.normalized;
        if (decelerateValue > absValue)
        {
            velocity.x = Mathf.SmoothDamp(velocity.x, 0, ref velocityXSmoothValue, 0.2f);
            velocity.z = Mathf.SmoothDamp(velocity.z, 0, ref velocityZSmoothValue, 0.2f);
            velocity.y = Mathf.SmoothDamp(velocity.y, 0, ref velocityYSmoothValue, 0.2f);
        }
        else
        {
            velocity -= projectedDir * decelerateValue * Time.deltaTime;

            /* This might be necessary to include for smoother deceleration 
            velocity.x = Mathf.SmoothDamp(velocity.x, 0, ref velocityXSmoothValue, 0.1f);
             velocity.z = Mathf.SmoothDamp(velocity.z, 0, ref velocityZSmoothValue, 0.1f);*/
        }

    }
    #endregion

    #region Hit Detection
    private void HitDetection()
    {
        //Capsule cast to check for collissions. 
        RaycastHit hit;
        //Vector3 upperPoint = transform.position + Vector3.up * (capsuleCollider.height / 2 - capsuleCollider.radius);
        //Vector3 lowerPoint = transform.position + Vector3.down * (capsuleCollider.height / 2 - capsuleCollider.radius);
        //Physics.CapsuleCast(upperPoint, lowerPoint, capsuleCollider.radius, velocity.normalized, out hit, Mathf.Infinity, collisionMask);
        //Debug.DrawLine(upperPoint, velocity.normalized, Color.red);
        //Debug.DrawLine(lowerPoint, velocity.normalized, Color.blue);
        Physics.SphereCast(transform.position + sphereCollider.center, sphereCollider.radius, velocity.normalized, out hit, Mathf.Infinity, collisionMask);

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
    #endregion
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
    public void SwimUpFunction()
    {
        if(Mathf.Abs(velocity.y)  < maxJumpForce) {
            playerInput += transform.up * jumpForce;
        }
        else{
            velocity.y = maxJumpForce;
        }
        
    }
    public void DiveFunction()
    {
        if(Mathf.Abs(velocity.y) < maxJumpForce) {
            playerInput += -transform.up * jumpForce;
        }
        else{
            velocity.y = -maxJumpForce;
        }
    }

    public void ResetMomentumFunction()
    {
        playerInput = Vector3.zero;
    }
    public void ForwardFunction()
    {
        playerInput += transform.forward * 1;
    }

    public void BackFunction()
    {
        playerInput += transform.forward * -1;
    }

    public void RightFunction()
    {
        playerInput += transform.right * 1;
    }

    public void LeftFunction()
    {
        playerInput += transform.right * -1;
    }

}
