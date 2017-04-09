using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour {

    public float maxSpeed;
    public float jumpTakeOffSpeed;
    public float Gravitation;
    //public BoxCollider2D colliderGround;
    //public BoxCollider2D ColliderBody;
    public bool grounded = false;
    public bool facingRight = true;

    private Rigidbody2D rb;
    private Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}
    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag=="Ground")
        {
            grounded = true;
        }
        if (hit.gameObject.tag=="DeathTrigger")
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
    private void OnCollisionExit2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
    private void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal")*maxSpeed; // Player Input
        anim.SetFloat("Speed", Mathf.Abs(move)); //Animator Controler sets The Parameter Speed to the Movement Speed
        rb.velocity = new Vector2(move, rb.velocity.y);

        if(Input.GetKey(KeyCode.Space)&&grounded==true)
        {
            rb.AddForce(new Vector2(0, jumpTakeOffSpeed), ForceMode2D.Impulse);
        }
        if (grounded == false)
        {
            Vector2 vel = rb.velocity;
            vel.y -= Gravitation;
            rb.velocity = vel;
        }
        if (move > 0 && !facingRight)   //Deciede werever or not to flip the Sprite
            flip();
        else if (move < 0 && facingRight)
            flip();
    }

    void Update ()
    {
		
	}
    void flip() //Flips the Sprite so it always look is in the direction its moving
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
