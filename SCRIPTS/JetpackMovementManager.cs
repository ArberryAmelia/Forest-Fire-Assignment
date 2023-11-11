using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class JetpackMovementManager : MonoBehaviour
{
    private Vector3 thrustDirection;        // Vector 3 variable used to identify thrust direction
    private Vector3 gravityDirection;       // Vector 3 variable used to identify gravity direction 

    public float currentThrustPower;        //
    public float thrustAccelerationRate;    // Variables used for calculating the thrust     
    public float maxThrustPower;            //
    public float minThrustPower;

    public float currentFallRate;           //
    public float fallAccelerationRate;      // Variables used for calculating the effect of gravity 
    public float maxFallRate;               //

    public InputActionReference thrustAction; // Reference to the thrust action on the XR rig

    public Transform rightController;       // Transform component identifies right-hand controller for direction control 

    public float fuel;               // The initial fuel level.
    public float fuelConsumptionRate; // The rate at which fuel is consumed per second.
    public float maximumFuel;       // Maximum level of fuel available, cannot fill jet pack over 150

    private void Update()
    {
        if (thrustAction.action.IsPressed()) // When right controller trigger button pressed, calculate new Vector 
        {
            CalculateThrust();

            if (fuel > 0) //Jetpack thrust only works when fuel level is above 0 
            {
                ApplyThrust();
            }
        }
        else  // When controller trigger button is released, the effects of gravity are apparent 
        {
            CalculateGravity();
            ApplyGravity();
        }


        if (thrustAction.action.IsPressed())  // Decrease fuel when thrust is active.
        {

            ConsumeFuel(fuelConsumptionRate * Time.deltaTime);
        }

        Debug.DrawRay(transform.position, thrustDirection, Color.red, 10f);     // Debug log casts ray to identify whether thrust direction movement is successful
        Debug.DrawRay(transform.position, gravityDirection, Color.blue, 10f);   // Debug log casts ray to identify whether gravity direction movement is successful
    }

    // Method to calculate thrust 
    private void CalculateThrust()
    {
        thrustDirection = rightController.transform.up;     // Calculates thrust direction from the contoller movement position 
        currentThrustPower += thrustAccelerationRate * Time.deltaTime;

        // Stop reducing the fall rate once it gets to zero
        if (currentFallRate > 0)    
            currentFallRate -= fallAccelerationRate * Time.deltaTime;
        else if (currentFallRate <= 0)     // If the fall rate is less than or equal to zero, calculate as zero
        {
            currentFallRate = 0.00f;
        }
    }

    // Method to calculate gravity 
    private void CalculateGravity()
    {
        gravityDirection = thrustDirection;     // 

        // Reverse the gravity direction for jet pack fall 
        gravityDirection = Quaternion.Euler(0, -180, 0) * gravityDirection;
        gravityDirection = -gravityDirection;

        if (currentThrustPower > 0)         // If thrust power is more than zero, reverse the effecr of thrust acceleration
            currentThrustPower -= thrustAccelerationRate * Time.deltaTime;
        else if (currentThrustPower < 0)    // If thrust power is less than zero, calculate as zero 
            currentThrustPower = 0;

        currentFallRate += fallAccelerationRate * Time.deltaTime;   // Adds effect of fall acceleration to the current rate of fall 
    }

    // Method to calculate the application of thrust power
    private void ApplyThrust()
    {

        // Move the character in the thrust direction with the current thrust power
        if (currentThrustPower > maxThrustPower)        // If current thrust power is more than the max thrust power, calculate the maximum thrust power
            currentThrustPower = maxThrustPower;        // Ensures thrust power does not exceed max
        else if (currentThrustPower < minThrustPower)   // If current thrust power is less than minimum thrust power, calculate the minimum thrust power
            currentThrustPower = minThrustPower;        // Ensure thrust power does not return negative, return negative pulls character rig through grid map 

        transform.position += currentThrustPower * Time.deltaTime * thrustDirection;
    }

    // Method to calulate the application of gravity 
    private void ApplyGravity()
    {
        if (currentFallRate > maxFallRate)      // If current maximum fall rate is more than maximum fall rate, calculate the maximum
            currentFallRate = maxFallRate;      // Calculates player terminal velocity 

        if (transform.position.y > 0.1f)        // If gravity effect is more than 0.1, apply effects of gravity 
            transform.position += gravityDirection * currentFallRate * Time.deltaTime;
        else if (transform.position.y < 0)      // If gravity effect is less than zero, calculate as zero 
            currentFallRate = 0f;
    }

    // Method to consume fuel
    private void ConsumeFuel(float amount)
    {
        // Subtract the consumed fuel amount from the current fuel level.
        fuel -= amount;

        // Ensure that the fuel level does not go below zero.
        fuel = Mathf.Max(0, fuel);
    }

    // Method to refill the fuel
    public void RefillFuel(float amount)
    {
        // Add the refill amount to the current fuel level.
        fuel += amount;

        // Ensure that the fuel level does not exceed a maximum value
        fuel = Mathf.Clamp(fuel, 0, maximumFuel);
    }

}
