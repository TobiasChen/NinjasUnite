using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour {

    public GameObject Startlevel; //Probably going to be replaced by the Array 
    public GameObject DeathTrigger;
    public Camera Cam;
    public GameObject[] Level;
    public List<GameObject> ActiveLevel;
    private float nextPosition;
    private GameObject CurrentLevel;
    private GameObject NextLevel;
    private int temp;  //Temp Value for testing
    public float Gap; // Distance between levels


	void Start ()
    {
        Cam = Camera.main;
        temp = 0;
        nextPosition = 0;
        NextLevel = Startlevel;
    }
	
	void Update ()
    {
        //  if (Cam.transform.position.x == nextPosition + 50)
        //      Destroy();
        if (temp < 20) //Choses wherever or not to spawn an additional levle
            Spawn();
        if (temp < 15 && temp > 3)
            Destroy();

    }
    GameObject SelectLevel() // Goes over the Array selects a random level to spawn
    {
        int temp = Random.Range(0, Level.Length);
        //return Level[temp];
        return Startlevel;
    }
    private void Destroy()
    {
        GameObject ToDestroy;
        ToDestroy = ActiveLevel[0];
        ActiveLevel.Remove(ToDestroy);
        print("Test");
    }
    void Spawn()
    {
        GameObject Death;
        CurrentLevel = NextLevel;
        NextLevel = SelectLevel(); //Selects next Level
        Instantiate(CurrentLevel, new Vector2 (nextPosition, 0), Quaternion.identity);//Instantinates the level at the next Position, next Position is calculated the loop before.
        ActiveLevel.Add(CurrentLevel);
        //Death = Instantiate(DeathTrigger, new Vector2(0,-80), Quaternion.identity, NextLevel.transform);
        Death = Instantiate(DeathTrigger, new Vector2(nextPosition+ (CurrentLevel.GetComponent<Renderer>().bounds.size.x / 2)+(Gap/2), -55), Quaternion.identity);//Instantiates a Deathtrigger between the last
        Death.transform.localScale = new Vector3(Gap, 2, 1);
        nextPosition += ((CurrentLevel.GetComponent<Renderer>().bounds.size.x/2)+(NextLevel.GetComponent<Renderer>().bounds.size.x/2)+Gap); //Calcutlates next Positiona as size of last level+last Position+ Gap.

        temp += 1; //temp value
    }
}
