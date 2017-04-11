using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GroundCheck : MonoBehaviour {
    public BoxCollider2D GroundCollider;
    private PlayerControler Script;
	// Use this for initialization
	void Start ()
    {
        GroundCollider = GetComponent<BoxCollider2D>();
        Script = GetComponentInParent<PlayerControler>();
	}
	
	// Update is called once per frame
	void Update ()
        {
		

        }
    private void OnCollisionEnter2D(Collision2D collision)
        {
            {
                if (collision.gameObject.tag == "Ground")
                {
                    Script.grounded = true;
                }
                if (collision.gameObject.tag == "DeathTrigger")
                {
                    Script.DeathTrigger();
                }
            }
        }
    private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                Script.grounded = false;
            }
        }
}
