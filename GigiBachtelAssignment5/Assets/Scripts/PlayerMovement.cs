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

    // character animator
    private Animator animator;
    
    // get character controller and animator
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // update loop
    void Update()
    {
        bool isWalking = false;
        Vector3 rotation = transform.eulerAngles;
        if (Input.GetKey(KeyCode.W)) // forward
        {
            movedir = Vector3.forward;
            movedir.y = 0;
            //transform.forward = cam.transform.forward;
            rotation.y = cam.transform.parent.localEulerAngles.y;
            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.S)) // back
        {
            movedir = Vector3.forward;
            movedir.y = 0;
            isWalking = true;
            rotation.y = cam.transform.parent.localEulerAngles.y + 180;
            //rotation.y = 180;
        }
        if (Input.GetKey(KeyCode.D)) // right
        {
            movedir = Vector3.forward;
            movedir.y = 0;
            isWalking = true;
            rotation.y = cam.transform.parent.localEulerAngles.y + 90;
            //rotation.y = 90;

        }
        else if (Input.GetKey(KeyCode.A)) // left
        {
            movedir = Vector3.forward;
            movedir.y = 0;
            isWalking = true;
            rotation.y = cam.transform.parent.localEulerAngles.y - 90;
            //rotation.y = 270;
        }

        animator.SetBool("IsWalking", isWalking);

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
