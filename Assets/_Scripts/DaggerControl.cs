using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerControl : MonoBehaviour {
    private Transform tf;
    public BoxCollider2D bx;
    public bool FlyingLeft;
    public float ThrowSpeed;
	// Use this for initialization
	void Start ()
    {
        FlyingLeft = GameObject.Find("Player").GetComponent<SpriteRenderer>().flipX;
        tf = GetComponent<Transform>();
        bx = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update ()
        {
        if (FlyingLeft)
            tf.transform.Translate(new Vector3(-ThrowSpeed, 0));
        else if (!FlyingLeft)
            tf.transform.Translate(new Vector3(ThrowSpeed, 0));
    }
}
