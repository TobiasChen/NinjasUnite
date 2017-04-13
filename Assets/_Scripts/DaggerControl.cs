using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerControl : MonoBehaviour {
    private Transform tf;
    public BoxCollider2D bx;
    public float ThrowSpeed;
	// Use this for initialization
	void Start ()
    {
        tf = GetComponent<Transform>();
        bx = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update ()
        {
        tf.transform.Translate(new Vector3(ThrowSpeed, 0));
        }
    private void OnAnimatorIK(int layerIndex)
    {
        
    }
}
