using UnityEngine;
using System.Collections;

public class HammerMovement : MonoBehaviour
{
    public float duration = 2f; // Duration of a single swing
    public bool isReversed = false; // Flag to control the direction of the movement
    public float pauseDuration = 0.3f; // Duration of the pause at the start and end positions

    private float startTime;
    private Vector3 startRotation;
    private Vector3 endRotation;
    private bool isSwingingBack = false; // Flag to track the swing direction
    private bool isPaused = false; // Flag to track if the hammer is paused

    void Start()
    {
        startTime = Time.time;
        startRotation = transform.localEulerAngles;

        // Determine the start and end rotations based on the initial rotation
        float targetAngle = isReversed ? -90f : 90f;
        float initialAngle = startRotation.x;

        if (initialAngle >= 0f && initialAngle <= targetAngle)
        {
            startRotation.x = initialAngle;
            endRotation = new Vector3(targetAngle, startRotation.y, startRotation.z);
        }
        else
        {
            startRotation.x = targetAngle;
            endRotation = new Vector3(0f, startRotation.y, startRotation.z);
            isSwingingBack = true;
        }
    }

    void Update()
    {
        if (isPaused)
        {
            // If the hammer is paused, check if the pause duration has elapsed
            if (Time.time - startTime >= pauseDuration)
            {
                isPaused = false; // Resume the movement
                startTime = Time.time; // Reset the start time
            }
            else
            {
                return; // Skip the movement update while paused
            }
        }

        float timeSinceStart = Time.time - startTime;
        float percentComplete = timeSinceStart / (duration * 0.5f); // Divide duration by 2 for a single swing

        if (percentComplete <= 1f)
        {
            if (!isSwingingBack)
            {
                // Swing from start rotation to end rotation
                transform.localEulerAngles = Vector3.Slerp(startRotation, endRotation, EaseOutQuadratic(percentComplete));
            }
            else
            {
                // Swing back from end rotation to start rotation
                transform.localEulerAngles = Vector3.Slerp(endRotation, startRotation, EaseInQuadratic(percentComplete));
            }
        }
        else
        {
            // Reset the start time for the next swing
            startTime = Time.time;
            isSwingingBack = !isSwingingBack; // Switch the swing direction
            isPaused = true; // Pause the movement
            if(!isReversed)
            startRotation = new Vector3(0f, 0, 0);
        }
    }

    private float EaseInQuadratic(float x)
    {
        return x * x*x;
    }

    private float EaseOutQuadratic(float x)
    {
        return 1 - (1 - x) * (1 - x);
    }
}