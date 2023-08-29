using UnityEngine;
using UnityEngine.Serialization;

public class BasicTempatureScript// : Temperature
{
    public float updateInterval = 0.5f;
    public float heatProductionPerSecond = 1f;
    
    private float timer = 0;

    public float temperature {
        get;
        set;
    }

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
            temperature += heatProductionPerSecond / updateInterval;
            timer = 0; 
        }
    }

}