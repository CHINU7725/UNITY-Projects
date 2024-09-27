using UnityEngine;

public class FullRotation : MonoBehaviour
{
    public float rotationSpeed = 90f; // Rotation speed in degrees per second

    void Update()
    {
        // Rotate the object around the Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }
}