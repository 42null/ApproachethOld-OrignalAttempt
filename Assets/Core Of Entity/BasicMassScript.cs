using UnityEngine;

public class BasicMassScript : MonoBehaviour, MassScript
{
    // Adjustable public variables for mass
    public float baseMass = 0f; //The mass of the entity without any additions 
    public float maxMass = 10f; //The max mass before no new mass can be added
    
    // Stored primary variables
    public float currentMass = 10f; //The current level of mass stored from the last calculation

    // Required Getters & Setters
    public float getCurrentMass() { return currentMass; }
    
    void Start()
    {
    }

    void Update()
    {
    }
    
    
}
