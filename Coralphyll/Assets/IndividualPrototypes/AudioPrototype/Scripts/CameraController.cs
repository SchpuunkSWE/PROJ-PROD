using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform followTransform;
    public Vector3 lookInput;
    public float rotationPower = 3f;
    public float rotationLerp = 0.5f;
    [SerializeField, Min(1), Tooltip("Speed at which the camera returns to its normal position")]
    private float returnSpeed = 90f;
    private int noLookInversion = - 1;
    private Transform originalLookDirection;
    private bool isReturningToNormalRotation = false;
    public CinemachineVirtualCamera vcam;
    private Cinemachine3rdPersonFollow vcamFollower;
    // Start is called before the first frame update
    void Start()
    {
        originalLookDirection = transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        vcamFollower = vcam.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        // When you hold down right mouse button, you rotate the player together with the camera and the mouse is locked to the center of the screen. 
        // Meaning that the mouse is locked but it still reads the input for X and Y that is then translated into a Quaternion that rotates the player.
        // The camera itself follows an empty object called "followTransform" that sits inside the player, which allows for the second part of the
        // code where left-clicking only rotates the followTransform (and the camera) - but not the player.
        // Disclaimer: We never touch the Z-axis for rotation since this is what can flip the world upside-down.
        if(Time.timeScale == 1)
        {
            lookInput.x = Input.GetAxis("Mouse X");
            lookInput.y = Input.GetAxis("Mouse Y") * noLookInversion;
            lookInput.x = Input.GetAxis("Joystick Camera X");
            lookInput.y = -Input.GetAxis("Joystick Camera Y") * noLookInversion;

            // Basically a copy-paste of the code that controls the character, except this part when holding down left-click you only rotate the camera and not the player.
            if (Input.GetMouseButton(0))
            {
                //This region handles vertical rotation around the x-axis from mouse input y and restricts rotation up/down with the angles variable.
                #region Vertical Rotation
                followTransform.rotation *= Quaternion.AngleAxis(lookInput.y * rotationPower, Vector3.right);
                var angles = followTransform.localEulerAngles;
                angles.z = 0;

                var angle = followTransform.localEulerAngles.x;

                //    //Clamp the Up/Down rotation - more free than when moving. This does not work well since when the player is rotated on the X-axis, the world looks tilted.
                //    // If possible, it would be good if the camera could rotate along eulerAngles (world rotation) and not around the player here.
                if (angle > 180 && angle < 300)
                {
                    angles.x = 300;
                }
                else if (angle < 180 && angle > 50)
                {
                    angles.x = 50;
                }

                //Vector3 vertical = new Vector3(angles.x, 0, 0);
                followTransform.localEulerAngles = angles;
                #endregion

                //Rotate followTransform horizontally based upon mouse input and rotationpower(sensitivity)
                followTransform.rotation *= Quaternion.AngleAxis(lookInput.x * rotationPower, Vector3.up).normalized;

            }
            else
            {
                if (Input.GetMouseButtonUp(0))
                {
                    isReturningToNormalRotation = true;
                }
                if (isReturningToNormalRotation)
                {
                    if (followTransform.localRotation != originalLookDirection.localRotation)
                    {
                        followTransform.localRotation = Quaternion.RotateTowards(followTransform.localRotation, Quaternion.identity, returnSpeed * Time.deltaTime);
                    }
                    else
                    {
                        isReturningToNormalRotation = false;
                    }
                }
                //This region handles vertical rotation around the x-axis from mouse input y and restricts rotation up/down with the angles variable.
                #region Vertical Rotation
                transform.rotation *= Quaternion.AngleAxis(lookInput.y * rotationPower, Vector3.right);
                var angles = transform.localEulerAngles;
                angles.z = 0;

                var angle = transform.localEulerAngles.x;

                //Clamp the Up/Down rotation
                if (angle > 180 && angle < 280)
                {
                    angles.x = 280;
                }
                else if (angle < 180 && angle > 60)
                {
                    angles.x = 60;
                }

                //Vector3 vertical = new Vector3(angles.x, 0, 0);
                transform.localEulerAngles = angles;
                #endregion

                //Rotate player horizontally based upon mouse input and rotationpower(sensitivity)
                float rotationMagic = (followTransform.eulerAngles.x > 180) ? (followTransform.eulerAngles.x / 450) : 1 - (followTransform.eulerAngles.x / 100);
                transform.rotation *= Quaternion.AngleAxis(lookInput.x * rotationPower * rotationMagic, Vector3.up);
                
                originalLookDirection.localEulerAngles = transform.localEulerAngles;
                //reset the y rotation of the look transform
                //followTransform.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
            }
        }

        if (Input.mouseScrollDelta.y != 0)
        {
            if (vcamFollower.CameraDistance <= 18f)
                vcamFollower.CameraDistance += Input.mouseScrollDelta.y;
            if (vcamFollower.CameraDistance > 18f)
                vcamFollower.CameraDistance = 18f;
            if (vcamFollower.CameraDistance < 4f)
                vcamFollower.CameraDistance = 4f;
        }
        if (Time.timeScale == 0)
            {
            if (Input.GetMouseButton(0))
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        }
        //When player releases right mousebutton, stop rotating camera
        //If player is not right-clicking, camera won't move with cursor and the mouse is unlocked.
    }


