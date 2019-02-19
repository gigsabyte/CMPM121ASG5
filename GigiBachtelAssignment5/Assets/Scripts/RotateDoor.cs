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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            Debug.Log(rtime);
            if (rtime < 1)
            {
                transform.Rotate(Vector3.right, Time.deltaTime * 45);
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
