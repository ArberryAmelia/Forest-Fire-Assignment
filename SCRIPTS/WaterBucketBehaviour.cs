using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBucketBehaviour : MonoBehaviour
{
    public ForestFireCell cell; // Reference to cell spawn position in Inspector tab, and reference to the method used to reset cell state

    private void OnTriggerEnter(Collider other) //Completes method when jetpack collides with prefab collider 
    {
        if (other.CompareTag("Jetpack")) // Assigns function to jetpack collider
        {
            JetpackMovementManager jetpack = other.GetComponent<JetpackMovementManager>(); // Calls jetpack movement script reference for box collider collision

            // Check if the collider is the player character.
            if (jetpack != null)
            {
                // When the jetpack collider interacts with prefab, the corresponding cell below is returned to a tree state, and the fire is extinguished
                cell.ResetCell();
                cell.cellState = ForestFireCell.State.Tree;  // Sets cell state to tree state 
                cell.groundMeshRenderer.material = cell.groundMaterialTree; // Returns cell material from burning material to original ground material 
                cell.leaves.SetActive(true);  // Returns leaf material state to unburnt 
                cell.treeObject.SetActive(true);  // Returns tree material state to unburnt

                Destroy(gameObject); // Destroys game object on collision 
            }
        }
    }
}

