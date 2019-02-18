/*
 * PlayerMovement.cs
 * 
 * A script to move the Player object with the WASD keys. 
 * Has different movement for 1st/3rd person perspective.
 * 
 */
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // movement variables
    [SerializeField]
    private float movespeed = 5;

    [SerializeField]
    private float gravity = 5;

    private Vector3 movedir = Vector3.zero;

    // camera variables
    [SerializeField]
    private GameObject cam = null;

    [SerializeField]
    public bool firstperson = true;
   
    // character controller
    private CharacterController controller;
    
    // get character controller
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // update loop
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // check if space is pressed
        {
            firstperson = !firstperson; // swap 1st/3rd person
        }

        // reset move direction
        movedir = Vector3.zero;

        if (firstperson) // first person movement
        {
            // get forward vector of camera
            Vector3 cameradir = cam.transform.forward;
            cameradir.y = 0;

            if (Input.GetKey(KeyCode.W)) // move along camera forward
            {
                movedir = cameradir;
            }
            else if (Input.GetKey(KeyCode.S)) // move back along camera forward
            {
                movedir = cameradir * -1;
            }
            if (Input.GetKey(KeyCode.D)) // move right of the camera
            {
                movedir = Quaternion.AngleAxis(90, Vector3.up) * cameradir;
            }
            else if (Input.GetKey(KeyCode.A)) // move left of the camera
            {
                movedir = Quaternion.AngleAxis(-90, Vector3.up) * cameradir;
            }
        }
        else // 3rd person movement
        {
            if (Input.GetKey(KeyCode.W)) // forward
            {
                movedir.z = 1;
            }
            else if (Input.GetKey(KeyCode.S)) // back
            {
                movedir.z = -1;
            }
            if (Input.GetKey(KeyCode.D)) // right
            {
                movedir.x = 1;
            }
            else if (Input.GetKey(KeyCode.A)) // left
            {
                movedir.x = -1;
            }
        }

        // normalize vector and multiply by movespeed
        movedir = Vector3.Normalize(movedir) * movespeed * Time.deltaTime;
        movedir = transform.TransformDirection(movedir);
        // adjust for gravity
        movedir.y = movedir.y - (gravity * Time.deltaTime);
        // move
        controller.Move(movedir);

    }
}
