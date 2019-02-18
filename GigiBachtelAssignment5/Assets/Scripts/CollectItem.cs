using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour
{
    private int count; // count of collectibles

    [SerializeField]
    private GameObject countUI = null; // text gameobject for count
    private Text countDisplay; // actual text component

    // Start is called before the first frame update
    void Start()
    {
        count = 0; // set count to 0
        countDisplay = countUI.GetComponent<Text>(); // get reference to text component
    }

    // on collision with trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collectible") // if the object collided with is a collectible
        {
            increaseCount(); // increase the collected item count
            Destroy(other.gameObject); // destroy collectible
        }
    }

    // increase count
    void increaseCount()
    {
        count++; // increment
        countDisplay.text = "Objects collected: " + count; // update text
    }
}
