using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class WaterBucketSpawn : MonoBehaviour
{

    public GameObject waterBucketPrefab; //Calls reference to the water bucket prefab
    public float spawnInterval = 1f; // Time between water bucket spawns.
    public ForestFire3D forestFire3D; // Calls reference to Forest Fire script

    private void Start()
    {
        forestFire3D = GameObject.FindAnyObjectByType<ForestFire3D>(); 
        InvokeRepeating("SpawnWaterBucket", 0f, spawnInterval); // Call the SpawnWaterBucket function at regular intervals.
    }

    private void SpawnWaterBucket()
    {
        // Generates a water bucket prefab at a random cell position in the scene 
        int randomX = Random.Range(0, forestFire3D.gridSizeX);
        int randomY = Random.Range(0, forestFire3D.gridSizeY);
        Vector3 randomPosition = forestFire3D.cellGameObjects[randomX, randomY].transform.position;
        randomPosition = new Vector3(randomPosition.x, randomPosition.y + 12, randomPosition.z); 

        // Instantiate the water bucket at the random cell position 
        WaterBucketBehaviour bucket = Instantiate(waterBucketPrefab, randomPosition, Quaternion.identity).GetComponent<WaterBucketBehaviour>();
        bucket.cell = forestFire3D.forestFireCells[randomX, randomY]; 
    }
}
