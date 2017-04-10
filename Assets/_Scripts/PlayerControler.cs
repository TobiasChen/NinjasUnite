using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour {

    //Public Variables
    public float maxSpeed;
    public float jumpTakeOffSpeed;
    public float Gravitation;
    [HideInInspector] public bool grounded; 
    //Private Variables
    private bool facingRight;
    private Rigidbody2D rb;
    private Animator anim;

    void Start ()
        {
            
            anim = GetComponent<Animator>();    //Gets the Animator
            rb = GetComponent<Rigidbody2D>();   //Gets the RigidBody 
            facingRight = true;                 //The Character starts as facing right
            grounded = false;                   //The Character starts in the Air


        }
    private void FixedUpdate()
        {
            Movement();                                         //Just transfering the whole Movment part into its one Function to make the Code more Readable;
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));   //The Animation Parameter "Speed" gets set to the Velocity in x direction of the Character
        }

    public void DeathTrigger()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            //The Scene Manage reloads the Scene by looking for the builInedx of the Current Scene and loading it 
        }
    private void Movement()
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * maxSpeed, rb.velocity.y);// The Velocity of the Character gets calculated over the Input
                                                                                                //in X direction multiplicated with the Max Movment Speed                
            if (Input.GetKey(KeyCode.Space) && grounded == true)                                //Only Lets the Player jump if he is grounded
                {                                                                               //Jump just adds Force in y direction in an Impulse 
                    rb.AddForce(new Vector2(0, jumpTakeOffSpeed), ForceMode2D.Impulse); 
                }                                                                               
            if (grounded == false)                                                              //Adds extra Gravity to make the Jump shorter and less heigh
                {
                    Vector2 vel = rb.velocity;                                                  //The Gravitaion is simply subtracted from the velocity in Y Direction,
                    vel.y -= Gravitation;                                                       //as long as the Character is in the air
                    rb.velocity = vel;                                                  

                }                                                                               //If moving right and facing left -->Flip
            if (rb.velocity.x > 0 && !facingRight)                                               
                Flip();                                                                         //If moving left and facing right -->Flip
            else if (rb.velocity.x < 0 && facingRight)                                           
            Flip();
        }
    void Flip()//Flips the Sprite so it always look is in the direction the Character is moving
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
}
