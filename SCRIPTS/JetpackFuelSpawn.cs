using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JetpackFuelSpawn : MonoBehaviour
{

    public GameObject fuelCellPrefab; // Calls reference to fuel cell prefab
    public float spawnInterval = 3f; // Time between fuel cell spawns.

    private void Start()
    {
        // Call the SpawnFuelCell function at regular intervals.
        InvokeRepeating("SpawnFuelCell", 0f, spawnInterval);
    }

    // Method to spawn fuel cell
    private void SpawnFuelCell()
    {
        // Generate a random position within the scene boundaries.
        Vector3 randomPosition = new Vector3(
            Random.Range(0f, 156f), // Calculates a random x position within the grid space
            0.5f,                   // Positions prefabs raised of the ground for easier viewing by players 
            Random.Range(0f, 156f)  // Calculates a random y position within the grid space
            );

        // Instantiate the fuel cell prefab spawn at the random position and facing a random direction.
        Instantiate(fuelCellPrefab, randomPosition, Quaternion.identity);
    }
}
