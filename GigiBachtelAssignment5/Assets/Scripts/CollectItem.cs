using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour
{
    private int count; // count of collectibles
    private int totalCount = 15;

    [SerializeField]
    private GameObject countUI = null; // text gameobject for count
    private Text countDisplay; // actual text component

    private ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        count = 0; // set count to 0
        countDisplay = countUI.GetComponent<Text>(); // get reference to text component
        particles = GetComponent<ParticleSystem>();
    }

    // on collision with trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DoorKey")
        {
            other.gameObject.GetComponent<OpenDoor>().Door.GetComponent<RotateDoor>().rotate = true;
            particles.Play();
            other.gameObject.GetComponent<DestroyCollectible>().alive = false;
        }
        if(other.tag == "Collectible") // if the object collided with is a collectible
        {
            particles.Play();
            increaseCount(); // increase the collected item count
            other.gameObject.GetComponent<DestroyCollectible>().alive = false;
        }
    }

    // increase count
    void increaseCount()
    {
        count++; // increment
        countDisplay.text = count + "/" + totalCount + " Objects Collected"; // update text
        if(count == totalCount)
        {
            Cursor.lockState = CursorLockMode.None;
            GetComponent<GoToScene>().loadNewScene();
        }
    }
}
