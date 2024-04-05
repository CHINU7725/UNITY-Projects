using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    public float floatHeight = 0.5f; // Maximum height of the floating motion
    public float floatSpeed = 1f; // Speed of the floating motion

    private float currentHeight;
    private float timeSinceStart;

    void Start()
    {
        currentHeight = transform.position.y; // Store the initial Y position
    }

    void Update()
    {
        // Calculate the oscillating Y position
        float newHeight = currentHeight + Mathf.Sin(timeSinceStart * floatSpeed) * floatHeight;

        // Update the drone's position
        transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);

        // Update the timer
        timeSinceStart += Time.deltaTime;
    }
}