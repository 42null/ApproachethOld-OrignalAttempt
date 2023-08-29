using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AstroidMovementScript : MonoBehaviour
{
    public float deadZoneX = 26;
    public float deadZoneY = 14;
    
    public float moveSpeed = 0;
    public float angle = 0;
    
    void Start()
    {
        // randomVector3ForMovement = createRandomVector3Direction(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = transform.position + (randomVector3ForMovement * Time.deltaTime);
        
        if (transform.position.x < -deadZoneX || transform.position.x > deadZoneX || transform.position.y < -deadZoneY || transform.position.y > deadZoneY )
        {
            Destroy(gameObject);
        }
    }

    private void newRandomDirection()
    {
        angle = Random.Range(0,360);
        
    }
    
    private static Vector3 createRandomVector3Direction(float halfRange)
    {
        return new Vector3(Random.Range(-halfRange, halfRange), Random.Range(-halfRange, halfRange),0);
    }
}
