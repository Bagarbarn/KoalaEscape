using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnScript : MonoBehaviour
{
    //Prefabs to instantiate 

    public GameObject[] obstacles;

    //Spawn Prefab once per 2 seconds 
    public float spawnRate = 2f;

    //Variable to set next spawn time
    float nextSpawn = 0f;

    //Variable contain random value 
    int whatToSpawn;

    float randX;
    Vector2 whereToSpawn;

    private void Start()
    {
        for(int i = 0; i < obstacles.Length; i++)
        {
           // obstacles[i] = Instantiate(obstacles[i]);
            //obstacles[i].SetActive(false);
        }
    }


    private void Update()
    {
        if (Time.time > nextSpawn) { //if time has come
            whatToSpawn = Random.Range(0, obstacles.Length); //Define random value between 1 and 5 (6 is exclusive)
            Debug.Log(whatToSpawn); //Display it's value in console  
            randX = Random.Range(-4f, 4f);
            whereToSpawn = new Vector3(randX, transform.position.y, -1f);

            Instantiate(obstacles[whatToSpawn], transform.position, Quaternion.identity);

            //set next spawntime
            nextSpawn = Time.time + spawnRate;
        }
        
    }



}
