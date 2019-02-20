using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor : MonoBehaviour
{

    public bool rotate = false;

    public float rtime = 0;
    // Start is called before the first frame update
    void Start()
    {
        rtime = 0;
        rotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            
            if (rtime < 1)
            {
                Vector3 rotation = transform.eulerAngles;
                rotation.y += Time.deltaTime * 45;
                //transform.Rotate(Vector3.up, Time.deltaTime * 45);
                transform.eulerAngles = rotation;
                rtime += Time.deltaTime;
            }
            else
            {
                rotate = false;
                rtime = 0;
            }
        }
    }
}
