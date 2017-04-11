﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour {

    //Public Variables
    public float maxSpeed;
    public float jumpTakeOffSpeed;
    public float moveForce;
    public float Gravitation;
    [HideInInspector] public bool grounded;
    //Private Variables
    private bool Jumping;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer ren;
    private GameObject Dagger;
    void Start ()
        {
            
            anim = GetComponent<Animator>();    //Gets the Animator
            rb = GetComponent<Rigidbody2D>();   //Gets the RigidBody 
            ren = GetComponent<SpriteRenderer>();
            grounded = false;                   //The Character starts in the Air
            Jumping = false;
            Dagger= Resources.FindObjectsOfTypeAll(typeof(GameObject)).Cast<GameObject>().Where(g => g.name == "Kunai").ToList()[0];
    }
     void FixedUpdate()
        {
            float temp = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", Mathf.Abs(temp));   //The Animation Parameter "Speed" gets set to the Velocity in x direction of the Character
            if (Mathf.Abs(temp)>0)
                rb.velocity=new Vector2 (temp*moveForce,rb.velocity.y);
            if (Mathf.Abs(rb.velocity.x) > maxSpeed)
                rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
            if (grounded == false)
            {                                                                               
                Vector2 vel = rb.velocity;                                                  //Adds extra Gravity to make the Jump shorter and less heigh
                vel.y -= Gravitation;                                                       //The Gravitaion is simply subtracted from the velocity in Y Direction,
                rb.velocity = vel;                                                          //as long as the Character is in the air
            }                                         
            if (Jumping)
                Jump(); 
        }
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded == true)                                //Only Lets the Player jump if he is grounded
        {
            Jumping = true;                                                                         
        }
        if (Input.GetKeyDown(KeyCode.F))
            ThrowDagger();
        if (rb.velocity.x >0)                                              //If moving right and facing left -->Flip
            ren.flipX = false;
        else if (rb.velocity.x < 0)                                        //If moving left and facing right -->Flip
            ren.flipX = true;
    }

    void Jump()
        {
        anim.SetTrigger("Jump");
        rb.AddForce(new Vector2(0, jumpTakeOffSpeed), ForceMode2D.Impulse);                     //Jump just adds Force in y direction in an Impulse 
        Jumping = false;                                                                        //Jumping gets reverted to false to prevent continoeus aplied forece
       }
    void ThrowDagger()
        {
            Instantiate(Dagger, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            anim.SetTrigger("KnifeThrow");
        }
    public void DeathTrigger()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        //The Scene Manage reloads the Scene by looking for the builInedx of the Current Scene and loading it 
    }
}
