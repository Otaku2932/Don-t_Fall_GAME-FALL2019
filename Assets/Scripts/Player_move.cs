using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    private Rigidbody2D rBody;
    public float movex, speed = 0.5f, jumpspeed = 1;
    public bool faceright = true;
    private bool allowjump = true;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movex = Input.GetAxis("Horizontal");

        animator.SetFloat("speed", Mathf.Abs(movex));

        if (movex > 0 && faceright == false)
        {
            flip();
        }
        else if (movex < 0 && faceright == true)
        {
            flip();
        }
        if (allowjump == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                jump();
            }
        }

        if (allowjump == false) 
        {
            rBody.velocity = new Vector2(movex * speed / 2, rBody.velocity.y);
        }
        else
        {
            rBody.velocity = new Vector2(movex * speed, rBody.velocity.y);
        }


        if (rBody.velocity.y > 0)
        {
            animator.SetBool("joping", true);
        }
        else
        {
            animator.SetBool("joping", false);
        }

        if (rBody.velocity.y < 0)
        {
            animator.SetBool("fall", true);
        }
        else
        {
            animator.SetBool("fall", false);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        allowjump = false;
        //Debug.Log("inair true");
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            allowjump = true;
            //Debug.Log("inair false");
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            allowjump = true;
            //Debug.Log("inair false");
        }
    }
    void jump()
    {
        rBody.velocity = new Vector2(rBody.velocity.x, jumpspeed);
    }
    void flip()
    {
        faceright = !faceright;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
