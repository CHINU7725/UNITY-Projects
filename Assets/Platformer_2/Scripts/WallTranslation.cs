using UnityEngine;

public class WallTranslation : MonoBehaviour
{
    public float speed = 1f; // Translation speed
    public float maxPositionX = 3.13f; // Maximum position along the local X-axis

    private bool isIncreasing = true; // Flag to track the translation direction
    private Vector3 initialPosition; // Store the initial local position of the wall

    void Start()
    {
        initialPosition = transform.localPosition; // Store the initial local position
    }

    void Update()
    {
        // Calculate the translation direction
        float direction = isIncreasing ? 1f : -1f;

        // Translate the wall along its local X-axis
        transform.localPosition += transform.right * direction * speed * Time.deltaTime;

        // Check if the wall has reached the maximum position in either direction
        float currentPositionX = transform.localPosition.x;
        if (Mathf.Abs(currentPositionX) >= maxPositionX)
        {
            isIncreasing = !isIncreasing; // Switch direction
        }
    }
}