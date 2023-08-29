using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Scripting;

public class GameObjectWithCore : MonoBehaviour
{
    public CoreScript coreScript;

    void Start()
    {
        
    }
    
    private void Update()
    {
        // Example usage of the coreScript's properties
        float currentTemperature = coreScript.temperatureScript.getCurrentTemperature();
        float mass = coreScript.massScript.getCurrentMass();
        float chatter = coreScript.chatterScript.getCurrentChatter();
        float directableSpeed = coreScript.directableSpeed;

        // Your logic using these properties goes here
    }
 
    
    
    
}