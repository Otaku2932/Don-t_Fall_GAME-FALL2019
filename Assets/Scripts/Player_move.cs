using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    private Rigidbody2D rBody;
    public float movex, speed = 0.5f, jumpspeed = 1;
    public bool faceright = true;
    private bool allowmove = true;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (allowmove == true)
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

            if (Input.GetButtonDown("Jump"))
            {
                jump();
            }
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
        allowmove = false;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        allowmove = true;
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
