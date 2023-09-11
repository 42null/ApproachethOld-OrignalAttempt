using UnityEngine;
using UnityEngine.UIElements;

public class OrbitingScript : MonoBehaviour
{
    public Transform orbiting;
    public float orbitSpeed = 1.0f;
    public float orbitRadius = -1f;
    // public bool tidallyLocked = false;
    public float dayLength = 2f;
    public float rotationSpeed = 1.0f;
    public float rotationOffset = 90.0f; // Offset for initial rotation angle

    private float orbitingAngleForCaculations = 0.0f;

    private void Start()
    {
        if (orbitRadius <= 0) //If the orbit is less than or 0, set to current distance between the bodies
        {
            orbitRadius = Vector3.Distance(transform.position, orbiting.position); //
        }
    }

    void Update()
    {
        // Orbital calculations
        orbitingAngleForCaculations += orbitSpeed * Time.deltaTime;
        Vector3 offset = new Vector3(Mathf.Cos(orbitingAngleForCaculations) * orbitRadius, Mathf.Sin(orbitingAngleForCaculations) * orbitRadius, 0);
        transform.position = orbiting.position + offset;
        
        // Rotation
        if (rotationSpeed == 0) //Tidally locked
        {
            Vector3 toOrbiting = orbiting.position - transform.position;
            float targetRotation = Mathf.Atan2(toOrbiting.y, toOrbiting.x) * Mathf.Rad2Deg;
            
            Vector3 currentRotation = gameObject.transform.rotation.eulerAngles;

            Quaternion newRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, targetRotation + rotationOffset);
            transform.rotation = newRotation;
        }
        else
        {
            // Debug.Log("2"+gameObject.transform.rotation.x);
            // Quaternion currentRotation = gameObject.transform.rotation;
            // transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, rotationSpeed * Time.deltaTime);
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}
