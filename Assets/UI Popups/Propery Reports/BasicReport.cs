using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BasicReport : MonoBehaviour
{
    // public TemperatureScript temperatureScript;
    public GameObject propertyScriptGameObject;
    public float updateInterval = 0f;
    private float updateTimer = 0f;
    private float lastValue = 0f;

    void Start()
    {
        // updateInterval = temperatureScript.updateInterval;
    }

    void Update()
    {
        if (updateTimer > updateInterval) //TODO: DO SUBSCRIBER DESIGN PATTERN FOR EFFICIENCY!!!
        {
            updateTimer = 0;
            // float newValue = propertyScriptGameObject.GetComponent<BasicTempatureScript>();
            // if (lastValue != newValue)
            // {
                // lastValue = newValue;
                // gameObject
            // }
        }
        else
        {
            updateTimer += Time.deltaTime;
        }
        
        
    }

}
