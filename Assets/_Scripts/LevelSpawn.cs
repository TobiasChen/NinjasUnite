using System.Linq;
using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class LevelSpawn : MonoBehaviour
    {

        public GameObject Startlevel;   //Probably going to be replaced by the Array 
        public float Gap;               // Distance between levels
        public float LoadDistance;      //When to Load the next Level (Default 200)
        public float UnLoadDistance;    //When to UnLoad the last Level(Default 200)
        
        
        private GameObject DeathTrigger;
        private GameObject CurrentLevel;
        private GameObject NextLevel;
        
        public List<GameObject> ActiveLevel;       //The List of currently active Level
        public List<GameObject> ActiveDeathTrigger;//The List of currently active DeathTrigger   
        private GameObject[] Level;                 //An Array which holds all the Level Prefabs.
        private Camera Cam;                         //The Camera tracking the Player to calculated when to load or unload the level
        private float nextPosition;                 //The Position of the next Spawned Level


    void Start ()
        {
            Cam = Camera.main;                      // Camera gets initialized
            nextPosition = 0;                       // Start Position is x =0
            NextLevel = Startlevel;                 //The Game starts at the predefined Start Level

            DeathTrigger = Resources.FindObjectsOfTypeAll(typeof(GameObject)).Cast<GameObject>().Where(g => g.name == "DeathTrigger").ToList()[0]; 
            //Loads all Item Preafbs with the Name "DeathTrigger" into a List and returns the first Entry
            //Not a very clean aproach, but gets the job done
            Level = Resources.LoadAll<GameObject>("LevelPrefabs").Cast<GameObject>().ToArray(); 
            //Loads all Items of Type Prefab in LevelPrefabs and casts them into an Array
        }
	
	void Update ()
        {

            if (Cam.transform.position.x >= nextPosition - LoadDistance)                                          //If the Camera is 200 units form the next Position away the next Level spawns
                { 
                    Spawn();
                }
            if (Cam.transform.position.x >= ActiveLevel[0].GetComponent<Transform>().position.x + UnLoadDistance) //If the Camera is further then 200 Units from the first Spawned Level away, the level despanws
                {
                    Destroy();
                }
        }
    void Spawn()
        {
            GameObject Death;           //Local Variable Death

            CurrentLevel = NextLevel;   //Selects current Level
            NextLevel = SelectLevel();  //Selects next Level
            ActiveLevel.Add(Instantiate(CurrentLevel, new Vector2(nextPosition, 0), Quaternion.identity));
            //Instantinates the level at the next Position, next Position is calculated the loop before.

            Death = Instantiate(DeathTrigger, new Vector2(nextPosition + (CurrentLevel.GetComponent<Renderer>().bounds.size.x / 2) + (Gap / 2), -55), Quaternion.identity);
            //Instantiates a Deathtrigger between the Current Level over the Gap
            Death.transform.localScale = new Vector3(Gap, 2, 1); //Sets the Death Trigger to the correct Size
            ActiveDeathTrigger.Add(Death); //Adds the newly Instantiated Trigger to the List
            
            nextPosition += ((CurrentLevel.GetComponent<Renderer>().bounds.size.x / 2) + (NextLevel.GetComponent<Renderer>().bounds.size.x / 2) + Gap);
            //Calculates next Position as each half the size of last level and Next Level + Gap.
        }
    void Destroy()
        {
            UnityEngine.Object.Destroy(ActiveLevel[0]);         //Unloads the clone of the level from the Scene
            UnityEngine.Object.Destroy(ActiveDeathTrigger[0]);  //Unloads the clone of the DeathTrigger from the Scene
            ActiveLevel.Remove(ActiveLevel[0]);                 //Delets The now empty List Entry
            ActiveDeathTrigger.Remove(ActiveDeathTrigger[0]);   //Delets the now empty List Entry
        }
    
    GameObject SelectLevel() //Goes over the Array to select a random level to spawn
        {
            return Level[UnityEngine.Random.Range(0, Level.Length)];
        }

    }
