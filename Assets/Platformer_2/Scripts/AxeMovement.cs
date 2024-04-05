using UnityEngine;

public class AxeMovement : MonoBehaviour
{
    public float maxRotationSpeed = 90f; // Maximum rotation speed in degrees per second
    private float maxAngle = 85f; // Maximum angle in degrees

    private float currentAngle;
    private bool isIncreasing = true;

    private void Awake()
    {
        currentAngle = transform.localEulerAngles.z;
    }

    void Update()
    {
        // Calculate the rotation direction based on the current angle
        float direction = isIncreasing ? 1f : -1f;

        // Calculate the rotation speed based on the current angle
        float currentSpeed = CalculateRotationSpeed(currentAngle);

        // Rotate the roller
        currentAngle += direction * currentSpeed * Time.deltaTime;

        // Clamp the current angle within the desired range
        currentAngle = Mathf.Clamp(currentAngle, -maxAngle, maxAngle);

        // Update the rotation of the roller
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, currentAngle);

        // Check if the roller has reached the maximum angle in either direction
        if (Mathf.Abs(currentAngle) >= maxAngle)
        {
            isIncreasing = !isIncreasing; // Switch direction
        }
    }

    private float CalculateRotationSpeed(float angle)
    {
        // Calculate the angle ratio
        float angleRatio = Mathf.Abs(angle) / maxAngle;

        // Use a cosine function to calculate the rotation speed based on the current angle
        float speed = maxRotationSpeed * Mathf.Cos(angleRatio * Mathf.PI * 0.48f);

        // Introduce a small offset to prevent the speed from reaching exactly zero
        const float minSpeed = 9f; // Adjust this value as needed
        speed = Mathf.Max(speed, minSpeed);

        return speed;
    }
}