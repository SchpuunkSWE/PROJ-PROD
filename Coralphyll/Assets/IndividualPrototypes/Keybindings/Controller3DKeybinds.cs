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

    [SerializeField]
    private float oGMaxVelocityValue = 5f;
    public float OGMaxVelocityValue { get => oGMaxVelocityValue; }

    [SerializeField]
    private float maxVelocityValue = 5f;
    public float MaxVelocityValue { get => maxVelocityValue; set => maxVelocityValue = value; }

    public Vector3 playerInput;
    public float decelerateValue = 7f;
    public float velocityXSmoothValue = 0.2f;
    public float velocityZSmoothValue = 0.2f;
    public float velocityYSmoothValue = 0.2f;

    //public CapsuleCollider capsuleCollider;
    public SphereCollider sphereCollider;
    public LayerMask collisionMask;
    [SerializeField] private float skinWidth = 0.05f;
    public float standardStaticFrictionVariable = 0.5f;
    public float kineticFrictionVariable = 0.16f;
    public float airResistance = 0.8f;
    public bool isGrounded;

    private Rigidbody rb;
    private void Awake()
    {
        //capsuleCollider = GetComponent<CapsuleCollider>();
        sphereCollider = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        HitDetection();
        ApplyVelocity();
        Rotate();
    }

    private void PlayerInput()
    {
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        if (playerInput.magnitude > float.Epsilon)
        {
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
        velocity += input * speed * Time.deltaTime;
        if (velocity.magnitude > maxVelocityValue && boostComplete)
        {
            velocity = velocity.normalized * maxVelocityValue;
        }
    }

    private void ApplyVelocity()
    {
        velocity *= Mathf.Pow(airResistance, Time.deltaTime);
        transform.position += velocity * Time.deltaTime;
    }
    
    private void DecelerateVelocity()
    {
        float absValue = Mathf.Abs(new Vector3(velocity.x, 0, velocity.z).magnitude);
        if (decelerateValue > absValue)
        {
            velocity.x = Mathf.SmoothDamp(velocity.x, 0, ref velocityXSmoothValue, 0.2f);
            velocity.z = Mathf.SmoothDamp(velocity.z, 0, ref velocityZSmoothValue, 0.2f);
        }
        absValue = Mathf.Abs(velocity.y);
        if (decelerateValue > absValue)
        {
            velocity.y = Mathf.SmoothDamp(velocity.y, 0, ref velocityYSmoothValue, 0.2f);
        }
        //absValue = Mathf.Abs(velocity.z);
        //if (decelerateValue > absValue)
        //{
            
        //}
        absValue = Mathf.Abs(velocity.magnitude);
        if (decelerateValue < absValue)
        {
            velocity -= velocity.normalized * decelerateValue * Time.deltaTime;
        }

    }

    #endregion

    #region Hit Detection
    private void HitDetection()
    {
        //Sphere cast to check for collissions. 
        RaycastHit hit;
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

        if (hit.collider) //If the spherecast hit anything within velocity.normalized range
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

    public void AxisYFunction(float input)
    {
        playerInput += transform.up * input;
    }

    public void ResetMomentumFunction()
    {
        playerInput = Vector3.zero;
    }
    public void AxisZFunction(float input)
    {
        playerInput += transform.forward * input;
    }

    public void AxisXFunction(float input)
    {
        //transform.rotation *= Quaternion.AngleAxis(input, Vector3.up);
        angularVelocity.y += input * rotationSpeed * Time.deltaTime;
        if (Mathf.Abs(angularVelocity.y) < 0.1f)
            angularVelocity.y = 0;
        if (angularVelocity.y > maxRotationSpeed)
            angularVelocity.y = maxRotationSpeed;
        if (angularVelocity.y < -maxRotationSpeed)
            angularVelocity.y = -maxRotationSpeed;

        transform.rotation *= Quaternion.AngleAxis(angularVelocity.y * 0.5f, Vector3.up);
    }

    private void Rotate()
    { 
        angularVelocity -= angularVelocity.normalized * angularDrag * Time.deltaTime;
    }
    [SerializeField]
    private Vector3 angularVelocity = Vector3.zero;
    [SerializeField]
    private float rotationSpeed = 10;
    [SerializeField]
    private float angularDrag = 3;
    [SerializeField]
    private float maxRotationSpeed = 2;
    [SerializeField]
    private float boostCooldown = 5;
    public bool isBoostReady = true;
    private bool boostComplete = true;
    [SerializeField]
    private float boostPower = 10;
    [SerializeField]
    private float boostDuration = 1;

 
    public void StartBoost()
    {
        isBoostReady = false;
        StartCoroutine(Boost());
    }

    private IEnumerator Boost()
    {
        float startTime = Time.time;
        boostComplete = false;
        while(Time.time < startTime + boostDuration)
        {
            velocity = (velocity.magnitude < 2f) ? maxVelocityValue * transform.forward * speed * boostPower * Time.deltaTime : velocity + transform.forward * boostPower * Time.deltaTime;

            yield return null;
        }
        boostComplete = true;
        yield return new WaitForSeconds(boostCooldown);
        isBoostReady = true;        
    }
}
