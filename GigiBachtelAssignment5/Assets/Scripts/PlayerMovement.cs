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
        Vector3 rotation = transform.eulerAngles;
        if (Input.GetKey(KeyCode.W)) // forward
        {
            movedir = cam.transform.forward;
            movedir.y = 0;
            //rotation.y = 0;
        }
        else if (Input.GetKey(KeyCode.S)) // back
        {
            movedir = cam.transform.forward * -1;
            movedir.y = 0;
            //rotation.y = 180;
        }
        if (Input.GetKey(KeyCode.D)) // right
        {
            movedir = cam.transform.right;
            movedir.y = 0;
            //rotation.y = 90;

        }
        else if (Input.GetKey(KeyCode.A)) // left
        {
            movedir = cam.transform.right *-1;
            movedir.y = 0;
            //rotation.y = 270;
        }

        // normalize vector and multiply by movespeed
        movedir = Vector3.Normalize(movedir) * movespeed * Time.deltaTime;
        movedir = transform.TransformDirection(movedir);
        // adjust for gravity
        movedir.y = movedir.y - (gravity * Time.deltaTime);
        // move
        controller.Move(movedir);
        transform.localEulerAngles = rotation;

    }
}
