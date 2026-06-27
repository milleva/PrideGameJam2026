using UnityEngine;

public class Oscillate : MonoBehaviour
{
    public float amplitude = 2.0f; // The maximum distance to oscillate
    public float speed = 2.0f; // The speed of oscillation
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float oscillationSpeed = speed; // Adjust this value to control the speed of oscillation
        float oscillationAmplitude = amplitude; // Adjust this value to control the amplitude of oscillation

        // Calculate the new position based on a sine wave
        float dy = Mathf.Sin(Time.time * oscillationSpeed) * oscillationAmplitude;

        // Update the object's position
        transform.position = new Vector3(transform.position.x, transform.position.y + dy, transform.position.z);
    }
}
