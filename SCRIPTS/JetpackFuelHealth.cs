using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JetpackFuelHealth : MonoBehaviour
{
    public JetpackMovementManager jetpackMovementManager;   // Calls reference to Jet pack movement manager script

    public float maxmimumFuel;      // Variable for maximum fuel 

    public Slider healthSlider;     // Calls reference to health silder game object in scene
    

    // Start is called before the first frame update
    private void Start()
    {
        jetpackMovementManager = GameObject.FindGameObjectWithTag("Jetpack").GetComponent<JetpackMovementManager>(); // References XR player rig, tagged as "Jetpack"
        healthSlider.maxValue = maxmimumFuel;       // Sets the maximum fuel variable as the maximum value of the health slider 
        jetpackMovementManager.fuel = maxmimumFuel;     // Fuel level at the start of the scene is set to the maximum fuel level 
        Debug.Log("The jetpack has " + jetpackMovementManager.fuel + "L of fuel. Start putting out that fire!!"); //Debug to show fuel level is set to maximum
    }

    // Update is called once per frame
    private void Update()
    {
        healthSlider.value = jetpackMovementManager.fuel;       // Value of the health slider set to the current fuel level, so health slider depletes as fuel is consumed

        if (jetpackMovementManager.fuel <= 0)  // If fuel level is less than or equal to zero, send debug message to console to show zero fuel level 
        {
            Debug.LogError("There is  " + jetpackMovementManager.fuel + "L of fuel left in the jetpack. Search for some more");
        }


    }
}
