using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour {

    public GameObject Startlevel; //Probably going to be replaced by the Array 
    public GameObject[] Level;
    private float nextPosition;
    private GameObject CurrentLevel;
    private GameObject NextLevel;
    private int temp;  //Temp Value for testing
    public float Gap; // Distance between levels


	void Start ()
    {
        temp = 0;
        nextPosition = 0;
        NextLevel = Startlevel;
    }
	
	void Update ()
    {
        if (temp < 20) //Choses wherever or not to spawn an additional levle
            Spawn();

	}
    GameObject SelectLevel() // Goes over the Array selects a random level to spawn
    {
        int temp = Random.Range(0, Level.Length);
        return Level[temp];
        //return Startlevel;
    }
    void Spawn()
    {
        CurrentLevel = NextLevel;
        NextLevel = SelectLevel(); //Selects next Level
        Instantiate(CurrentLevel, new Vector2 (nextPosition, 0), Quaternion.identity);//Instantinates the level at the next Position, next Position is calculated the loop before.
        nextPosition += ((CurrentLevel.GetComponent<Renderer>().bounds.size.x/2)+(NextLevel.GetComponent<Renderer>().bounds.size.x/2)+Gap); //Calcutlates next Positiona as size of last level+last Position+ Gap.
        temp += 1; //temp value
    }
}
