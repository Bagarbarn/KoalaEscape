using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Vector2 x_boundaries_;
    public float distance_from_player_;

    private Transform player_transform_;

    public GameObject[] obstacle_instances_;

    private GameObject current_obstacle_;

    private void Start()
    {
        player_transform_ = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnNewObstacle();
    }

    private void Update()
    {
        if(current_obstacle_.transform.position.y > player_transform_.position.y + distance_from_player_)
        {
            SpawnNewObstacle();
        }
    }

    private void SpawnNewObstacle()
    {
        Destroy(current_obstacle_);
        int obstacle_index = Random.Range(0, obstacle_instances_.Length);
        float x_pos = Random.Range(x_boundaries_.x, x_boundaries_.y);
        Vector3 new_position = new Vector3(x_pos, player_transform_.position.y - distance_from_player_);
        current_obstacle_ = Instantiate(obstacle_instances_[obstacle_index],new_position, Quaternion.identity);
    }
}
