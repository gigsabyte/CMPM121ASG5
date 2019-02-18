/*
 * CameraMovement.cs
 * 
 * A script to move/rotate the Camera object. 
 * Has different movement for 1st/3rd person perspective.
 * 
 */
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //reference to playermovement script
    private PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // lock cursor
        pm = transform.parent.gameObject.GetComponent<PlayerMovement>(); // get reference
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.firstperson) // if the player is in first person
        {
            transform.localPosition = Vector3.up; // put the camera inside the player
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0) // if mouse moved
            {
                // rotate by the y movement along the x axis and by the x movement along the y axis
                transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -1, Input.GetAxis("Mouse X"), 0));

                // reset the rotation along the Z axis
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            }
        }
        else // if the player is in the third person
        {
            transform.localPosition = new Vector3(0, 8, -8); // put the camera above and behind the player
            transform.LookAt(transform.parent); // look at the player
        }
    }
}
