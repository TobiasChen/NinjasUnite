using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour {
    public GameObject Startlevel;
    public GameObject[] Level;
    private Vector2 currentPosition;
    private GameObject CurrentLevel;
    private int temp;
    public float Gap;
	// Use this for initialization
	void Start ()
    {
        //CurrentLevel = Startlevel;
        temp = 0;
        CurrentLevel = Startlevel;
        Instantiate(CurrentLevel);
        currentPosition = CurrentLevel.GetComponent<Collider2D>().bounds.size;
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentPosition = currentPosition + new Vector2(CurrentLevel.GetComponent<Collider2D>().bounds.size.x, 0);
        if (temp < 5)
            CurrentLevel = Instantiate(Startlevel, currentPosition+new Vector2(Gap,0), Quaternion.identity);
            temp += 1;

        print(currentPosition);
	}
}
