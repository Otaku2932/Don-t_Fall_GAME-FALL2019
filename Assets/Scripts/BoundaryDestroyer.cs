using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestroyer : MonoBehaviour
{
    // Runs once
    // When another collider leaves this colliders area
    void OnTriggerExit2D(Collider2D other)
    {
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
