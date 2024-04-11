using UnityEngine;

public class SwipeMovement : MonoBehaviour
{

    private Vector3 targetPosition; // The position the player should move to
    private Touch touch;
    void Update()
    {
     /*   // Check for touch input
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Get the position of the touch in world space
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Set the target position to the touch position, but only on the x-axis
                targetPosition = new Vector3(hit.point.x, this.transform.position.y, this.transform.position.z);
            }
            // Move the player towards the target position
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, Time.deltaTime * 10f);
        }*/


        if(Input.touchCount>0)
        {
            touch=Input.GetTouch(0);
            if(touch.phase==TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x+touch.deltaPosition.x*0.01f,transform.position.y,transform.position.z);
            }
        }
      
    }
}
