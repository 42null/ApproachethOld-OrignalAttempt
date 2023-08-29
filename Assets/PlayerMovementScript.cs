using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Allow multiple keys to be pressed at once
        if(Input.GetKeyDown(KeyCode.W)){ myRigidBody.velocity = Vector2.up * flapStrength; }
        if(Input.GetKeyDown(KeyCode.S)){ myRigidBody.velocity = Vector2.down * flapStrength; }
        if(Input.GetKeyDown(KeyCode.A)){ myRigidBody.velocity = Vector2.left * flapStrength; }
        if(Input.GetKeyDown(KeyCode.D)){ myRigidBody.velocity = Vector2.right * flapStrength; }
        
    }
}
