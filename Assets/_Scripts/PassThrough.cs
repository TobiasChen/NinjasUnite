using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThrough : MonoBehaviour {
	// Use this for initialization
	void Start ()
    {
		
	}
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetAxis("Vertical")<0 && Input.GetButtonDown("Jump"))
        {
            Jumper();
            Invoke("Jumper", 0.5f);
        }
    }
    // Update is called once per frame
    void Update ()
    {
		
	}
 
    public void Jumper()
    {
        gameObject.GetComponent<Collider2D>().enabled = !gameObject.GetComponent<Collider2D>().enabled;
    }
}
