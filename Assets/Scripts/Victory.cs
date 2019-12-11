using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public GameControllerS gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Object reference not set to an instance of an object Victory.OnTriggerEnter2D
        //fixed by making controllerS public and attaching game controllerobject
        if (other.gameObject.CompareTag("Beni"))
        {
            gameController.fin();
        }
        
    }
}
