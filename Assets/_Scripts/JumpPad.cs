using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {
    public float Accleration;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.rigidbody.velocity.y <= 0)
                collision.rigidbody.AddForce(new Vector2(0, Accleration), ForceMode2D.Impulse); 
            else if (collision.rigidbody.velocity.y > 0)
                collision.rigidbody.AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
        }
    }
}
