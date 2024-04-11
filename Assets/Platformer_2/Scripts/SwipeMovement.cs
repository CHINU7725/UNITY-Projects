using UnityEngine;
using UnityEngine.UI;

public class SwipeMovement : MonoBehaviour
{
    public GameObject playerObject; // Reference to the player object
    private Vector3 targetPosition; // The position the player should move to

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Check if the touch is in the "Began" phase
            if (touch.phase == TouchPhase.Began)
            {
                // Get the position of the touch in world space
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    // Set the target position to the touch position
                    targetPosition = hit.point;
                }
            }
        }

        // Move the player towards the target position
        playerObject.transform.position = Vector3.Lerp(playerObject.transform.position, targetPosition, Time.deltaTime * 5f);
    }
}