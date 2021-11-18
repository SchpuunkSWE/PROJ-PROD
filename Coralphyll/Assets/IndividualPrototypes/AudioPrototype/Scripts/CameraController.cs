using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject followTransform;
    public Vector3 lookInput;
    public float rotationPower = 3f;
    public float rotationLerp = 0.5f;
    private int noLookInversion = -1;
    public GameObject playerRotation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // When you hold down right mouse button, you rotate the player together with the camera and the mouse is locked to the center of the screen. 
        // Meaning that the mouse is locked but it still reads the input for X and Y that is then translated into a Quaternion that rotates the player.
        // The camera itself follows an empty object called "followTransform" that sits inside the player, which allows for the second part of the
        // code where left-clicking only rotates the followTransform (and the camera) - but not the player.
        // Disclaimer: We never touch the Z-axis for rotation since this is what can flip the world upside-down.
        //if (Input.GetMouseButtonUp(1))
        //{
        //cursor.lockState = CursorLockMode.None;
        //}

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        lookInput.x = Input.GetAxis("Mouse X");
        lookInput.y = Input.GetAxis("Mouse Y") * noLookInversion;

        //This region handles vertical rotation around the x-axis from mouse input y and restricts rotation up/down with the angles variable.
        #region Vertical Rotation
        transform.rotation *= Quaternion.AngleAxis(lookInput.y * rotationPower, Vector3.right);
        var angles = transform.localEulerAngles;
        angles.z = 0;

        var angle = transform.localEulerAngles.x;

        //Clamp the Up/Down rotation
        if (angle > 180 && angle < 330)
        {
            angles.x = 330;
        }
        else if (angle < 180 && angle > 30)
        {
            angles.x = 30;
        }

        Vector3 vertical = new Vector3(angles.x, 0, 0);
        transform.localEulerAngles = angles;
        #endregion

        //Rotate player horizontally based upon mouse input and rotationpower(sensitivity)
        transform.rotation *= Quaternion.AngleAxis(lookInput.x * rotationPower, Vector3.up);

        //reset the y rotation of the look transform
        //followTransform.transform.localEulerAngles = new Vector3(angles.x, 0, 0);

        // Basically a copy-paste of the code that controls the character, except this part when holding down left-click you only rotate the camera and not the player.
        //if (Input.GetMouseButton(0))
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //    lookInput.x = Input.GetAxis("Mouse X");
        //    lookInput.y = Input.GetAxis("Mouse Y") * noLookInversion;

        //    //This region handles vertical rotation around the x-axis from mouse input y and restricts rotation up/down with the angles variable.
        //    #region Vertical Rotation
        //    followTransform.transform.rotation *= Quaternion.AngleAxis(lookInput.y * rotationPower, Vector3.right);
        //    var angles = followTransform.transform.localEulerAngles;
        //    angles.z = 0;

        //    var angle = followTransform.transform.localEulerAngles.x;

        //    //    //Clamp the Up/Down rotation - more free than when moving. This does not work well since when the player is rotated on the X-axis, the world looks tilted.
        //    //    // If possible, it would be good if the camera could rotate along eulerAngles (world rotation) and not around the player here.
        //    if (angle > 180 && angle < 300)
        //    {
        //        angles.x = 300;
        //    }
        //    else if (angle < 180 && angle > 50)
        //    {
        //        angles.x = 50;
        //    }

        //    Vector3 vertical = new Vector3(angles.x, 0, 0);
        //    followTransform.transform.localEulerAngles = angles;
        //    #endregion

        //    //    //Rotate followTransform horizontally based upon mouse input and rotationpower(sensitivity)
        //    followTransform.transform.rotation *= Quaternion.AngleAxis(lookInput.x * rotationPower, Vector3.up);

        //}
        //if (Input.GetMouseButtonUp(0))
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //}
    }
    //When player releases right mousebutton, stop rotating camera
    //If player is not right-clicking, camera won't move with cursor and the mouse is unlocked.
}
