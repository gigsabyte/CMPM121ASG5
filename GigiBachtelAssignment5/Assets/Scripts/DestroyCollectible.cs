using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollectible : MonoBehaviour
{
    public bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!alive)
        {
            Destroy(gameObject); // destroy collectible
        }
    }
}
