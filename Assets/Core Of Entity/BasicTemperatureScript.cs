using UnityEngine;

public class BasicTemperatureScript : MonoBehaviour, TemperatureScript
{
    // Adjustable public variables for temperature
    public float minTemperature = 0f; //The min temperature before things fail 
    public float maxTemperature = 100f; //The max temperature before things break
    public float currentTemperature = 25f; //The current level of temperature stored from the last calculation

    // Stored primary variables
    public float updateInterval = 0.5f;
    public float heatProductionPerSecond = 0.1f;
    
    // Required Getters & Setters
    public float getCurrentTemperature() { return currentTemperature; }

    // Private misalliances
    private float timer = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (timer < updateInterval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            currentTemperature += heatProductionPerSecond*updateInterval; //TODO: Move to variable so not recalculated as often, make rate adjustable
            timer = 0; 
        }
    }

}