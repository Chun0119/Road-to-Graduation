using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Animator animator;
    bool grounded, attack, facingLeft;
    Rigidbody2D body;

    void Start ()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("Run", true);
            gameObject.transform.Translate(0.1f, 0, 0);
            if (facingLeft)
            {
                flip();
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("Run", true);
            gameObject.transform.Translate(-0.1f, 0, 0);
            if (!facingLeft)
            {
                flip();
            }
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (!attack && Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("AttackA", true);
            attack = true;
        }

        if (!attack && Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("AttackB", true);
            attack = true;
        }

        if (!attack && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("AttackC", true);
            attack = true;
        }

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector2.up * 700);
        }
    }

    void OnCollisionStay2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Ground")
        {
            grounded = true;
            animator.SetBool("Jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Ground")
        {
            grounded = false;
            animator.SetBool("Jump", true);
        }
    }

    public void AlertObservers(string message)
    {
        if (message.Equals("AttackAAnimationEnded"))
        {
            animator.SetBool("AttackA", false);
            attack = false;
        }
        if (message.Equals("AttackBAnimationEnded"))
        {
            animator.SetBool("AttackB", false);
            attack = false;
        }
        if (message.Equals("AttackCAnimationEnded"))
        {
            animator.SetBool("AttackC", false);
            attack = false;
        }
    }

    private void flip()
    {
        float x = gameObject.transform.localScale.x * -1;
        float y = gameObject.transform.localScale.y;
        float z = gameObject.transform.localScale.z;
        gameObject.transform.localScale = new Vector3(x, y, z);
        facingLeft = !facingLeft;
    }
}
