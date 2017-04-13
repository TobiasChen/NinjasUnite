using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GroundCheck : MonoBehaviour {
    public BoxCollider2D GroundCollider;
    private PlayerControler Script;
    private Animator anim;
	// Use this for initialization
	void Start ()
    {
        GroundCollider = GetComponent<BoxCollider2D>();
        Script = GetComponentInParent<PlayerControler>();
        anim = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
        {
		

        }
    private void OnCollisionEnter2D(Collision2D collision)
        {
            {
            if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "JumpPad" || collision.gameObject.tag == "Dirt")
            {
                Script.grounded = true;
                Script.IsNotInAir = true;
                anim.SetBool("Grounded", true);

            }
            if (collision.gameObject.tag == "DeathTrigger")
                {
                    Script.DeathTrigger();
                }
            }
        }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Dirt")
        {
            Script.IsNotInAir = false;
            Script.grounded = false;
            anim.SetBool("Grounded", false);
        }
        else if (collision.gameObject.tag == "JumpPad")
        {
            StartCoroutine(JumpPad());
        }
    }
    IEnumerator JumpPad()
    {
        anim.SetBool("Grounded", true);
        Script.IsNotInAir = false;
        yield return new WaitForSeconds(0.2f);
        Script.grounded = false;
    }
}
