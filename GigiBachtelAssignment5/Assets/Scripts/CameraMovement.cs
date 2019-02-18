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
    [SerializeField]
    private GameObject player = null;
    //reference to playermovement script
    private PlayerMovement pm;

    float xpos = 0;
    float zpos = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // lock cursor
        pm = player.GetComponent<PlayerMovement>(); // get reference
        zpos = -8;
    }

    // Update is called once per frame
    void Update()
    {
        zpos += Input.GetAxis("Mouse X");
        xpos -= Input.GetAxis("Mouse X");
        Vector3 newpos = Vector3.Normalize(new Vector3(xpos, 0, zpos));
        newpos *= 8;
        newpos.y = 4;
        transform.position = player.transform.position + newpos; // put the camera above and behind the player
        //transform.LookAt(player.transform); // look at the player
        if (pm.firstperson) // if the player is in first person
        {
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0) // if mouse moved
            {
                // rotate by the y movement along the x axis and by the x movement along the y axis
                transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -1, Input.GetAxis("Mouse X"), 0));

                // reset the rotation along the Z axis
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            }
        }

            
    }
}
