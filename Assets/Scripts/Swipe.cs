using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Swipe : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;

    public GameObject LeftLane;
    public GameObject RightLane;

    Vector3[] lanePs;

    int currentIndex = 0;
    int targetIndex = 0;


    public Transform leftLook;
    public Transform rightLook;
    private Transform target;

    private Vector2 startTouch;
    private Vector2 endTouch;

    public float movementSpeed=12f;
    public float rotationSpeed=10f;

    void Start()
    {
        lanePs = new Vector3[3];
        lanePs[0] = LeftLane.transform.position;
        lanePs[1] = RightLane.transform.position;

        target = rightLook;

    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentIndex != 0)
            {

                targetIndex = currentIndex - 1;
            }
            /*     rb.AddForce(Vector3.left * 10f);*/

        }

        if (Input.GetKeyDown(KeyCode.A))
        {


            if (currentIndex != 1)
            {
                targetIndex = currentIndex + 1;
            }
        }



        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouch = Input.GetTouch(0).position;
        }


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouch = Input.GetTouch(0).position;

            if (endTouch.x > startTouch.x)
            {
                if (currentIndex != 0)
                {
                    target = rightLook;
                    targetIndex = currentIndex - 1;
                }
            }
            else if (endTouch.x < startTouch.x)
            {
                if (currentIndex != 1)
                {
                    target = leftLook;
                    targetIndex = currentIndex + 1;
                }
            }
        }

        currentIndex = targetIndex;

        var stop = movementSpeed * Time.deltaTime;

        rb.gameObject.transform.position = Vector3.MoveTowards(rb.gameObject.transform.position, lanePs[currentIndex], stop);
        Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(lanePs[currentIndex].x, Camera.main.transform.position.y, Camera.main.transform.position.z), stop);


        // Calculate the target rotation
        Quaternion targetRotation = Quaternion.LookRotation(target.position - rb.gameObject.transform.position, Vector3.up);

        // Apply smooth rotation towards the target
        rb.gameObject.transform.rotation = Quaternion.Slerp(rb.gameObject.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

}
