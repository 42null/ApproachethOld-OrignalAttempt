using UnityEngine;

public class BasicChatterScript : MonoBehaviour, ChatterScript
{
    // Adjustable public variables for mass
    public float baseChatter = 0f; //The default chatter amount with nothing going on.
    
    // Stored primary variables
    public float currentChatter = 10f; //The current level of chatter stored from the last calculation

    // Required Getters & Setters
    public float getCurrentChatter() { return currentChatter; }
    
    void Start()
    {
    }

    void Update()
    {
    }
    
    
}
