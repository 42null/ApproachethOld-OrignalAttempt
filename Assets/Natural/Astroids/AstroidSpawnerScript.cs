using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawnerScript : MonoBehaviour
{
    public GameObject astroid;
    public float spawnRate = 2;
    private float timer = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Instantiate(astroid, transform); //Spawn at the rotation and location of the spanner
            timer = 0; 
        }
    }
}
