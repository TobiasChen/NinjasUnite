using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlScript : MonoBehaviour {
    private Transform tf;
    public float CameraSpeed;
	// Use this for initialization
	void Start ()
    {
        tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
         tf.transform.Translate(new Vector3(CameraSpeed, 0, 0));
	}
}
