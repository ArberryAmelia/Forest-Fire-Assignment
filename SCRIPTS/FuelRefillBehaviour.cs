using UnityEngine;

public class FuelRefillBehaviour : MonoBehaviour
{
    public float fuelRefillAmount; // VAriable to identify amount of fuel to refill when picking up the fuel cell.

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Jetpack")) // Assigns function to jetpack collider tagged as "Jetpack"
        {
            JetpackMovementManager jetpack = other.GetComponent<JetpackMovementManager>(); // Calls reference to the JetpackMovementManager script

            // Check if the collider is the player character.
            if (jetpack != null)
            {
                jetpack.RefillFuel(fuelRefillAmount);   // Refill the player's jetpack fuel using called method from jetpackMovementManager scripts.
                Destroy(gameObject);        // Destroy the fuel prefab after picking it up.
            }
        }
    }
}

