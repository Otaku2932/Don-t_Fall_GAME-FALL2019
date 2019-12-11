using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameControllerS gameController;
    public GameObject death;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Object reference not set to an instance of an object DestroyByContact.OnCollisionEnter2D
        //fixed by making controllerS public and attaching game controllerobject
        if (other.gameObject.CompareTag("Beni"))
        {
            gameController.rez();
        }
        
        if (other.gameObject.CompareTag("Ground"))
        {
            //do not destroy ground
        }
        else
        {
            Instantiate(death, other.gameObject.GetComponent<Rigidbody2D>().position, this.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
