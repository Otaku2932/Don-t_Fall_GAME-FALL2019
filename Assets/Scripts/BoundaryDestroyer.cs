using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestroyer : MonoBehaviour
{
    public GameControllerS gameController;
    public GameObject death;
    // Runs once
    // When another collider leaves this colliders area
    void OnTriggerExit2D(Collider2D other)
    {
        //Object reference not set to an instance of an object BoundaryDestroyer.OnTriggerExit2D
        //fixed by making controllerS public and attaching game controllerobject
        if (other.gameObject.CompareTag("Beni"))
        {
            gameController.rez();
        }
        
        Instantiate(death, other.gameObject.GetComponent<Rigidbody2D>().position, this.transform.rotation);
        Destroy(other.gameObject);
    }

    // Runs once
    // When another collider enters this colliders area
    void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    // Runs every frame if...
    // Another collider stay inside this colliders area
    void OnTriggerStay2D(Collider2D other)
    {
        
    }
}
