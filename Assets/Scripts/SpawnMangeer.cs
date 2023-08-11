using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMangeer : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3 (24, 0, 0); // Position of Spawn Obstacle 

    private float startDelay = 2;
    private float repeatDelay = 2;

    private PlayerController playerControllerScript;
    
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); // Reference of player for informition of player

        InvokeRepeating("SpawnObstacle",startDelay,repeatDelay); // Continuas Spawning of Obstacles

    }

    void Update()
    {
        
    }

    void SpawnObstacle ()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
