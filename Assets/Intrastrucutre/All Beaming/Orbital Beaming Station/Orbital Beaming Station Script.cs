using System.Collections;
using System.Collections.Generic;
using StaticHelpers;
using Unity.VisualScripting;
using UnityEngine;

public class OrbitalBeamingStationScript : MonoBehaviour
{
    public GameObject orbiting;
    private CoreScript core;
    private OrbitingScript orbitingScript;

    void Start()
    {
        core = ComponentFinder.FindComponentsInChildrenWithTag<CoreScript>(gameObject, "Core")[0];

        //Assign orbiting script
        orbitingScript = gameObject.AddComponent<OrbitingScript>();
        orbitingScript.orbiting = orbiting.transform;
        
        
    }

    void Update()
    {
    }
}
