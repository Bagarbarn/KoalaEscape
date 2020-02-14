using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnScript : MonoBehaviour
{
    //Prefabs to instantiate 
    public GameObject Tree, Boulder, Fire;

    //Spawn Prefab once per 2 seconds 
    public float spawnRate = 2f;

    //Variable to set next spawn time
    float nextSpawn = 0f;

    //Variable contain random value 
    int whatToSpawn;

    float randX;
    Vector2 whereToSpawn;


    private void Update()
    {
        if (Time.time > nextSpawn) { //if time has come
            whatToSpawn = Random.Range(1, 4); //Define random value between 1 and 5 (6 is exclusive)
            Debug.Log(whatToSpawn); //Display it's value in console  
            randX = Random.Range(-4f, 4f);
            whereToSpawn = new Vector2(randX, transform.position.y);

            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(Tree, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Boulder, transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(Fire, transform.position, Quaternion.identity);
                    break;
            }
            //set next spawntime
            nextSpawn = Time.time + spawnRate;
        }
    }



}
