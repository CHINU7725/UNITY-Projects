using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using CandyCoded.HapticFeedback;

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

    List<Transform> playerTransforms=new List<Transform>();

    public GameObject JoystickCanva;

    public ViewEnemies ve;

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


        if (CurrentNum.enemies.Count != CurrentNum.EnemyDeadCount && JoystickCanva.activeSelf)
        {
            halfScreenInput();
        }
        else
        {
            fullScreenInput();
        }




            currentIndex = targetIndex;

        var stop = movementSpeed * Time.deltaTime;

        rb.gameObject.transform.position = Vector3.MoveTowards(rb.gameObject.transform.position, lanePs[currentIndex], stop);
        /* Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(lanePs[currentIndex].x, Camera.main.transform.position.y, Camera.main.transform.position.z), stop);*/


        /*        // Calculate the target rotation
                Quaternion targetRotation = Quaternion.LookRotation(target.position - rb.gameObject.transform.position, Vector3.up);

                // Apply smooth rotation towards the target
                rb.gameObject.transform.rotation = Quaternion.Slerp(rb.gameObject.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);*/


        if (CurrentNum.enemies.Count!=CurrentNum.EnemyDeadCount)
        {
            ve.LookEach();
        }
        else
        {

            localView();

        }
    }
    public void localView()
    {
        playerTransforms = ve.GetValidChildTransforms(rb.gameObject, "Pos");

        for (int i = 0; i < playerTransforms.Count; i++)
        {
            Transform playerChild = ve.GetValidChild(playerTransforms[i]);
            Quaternion targetRotation = Quaternion.LookRotation(target.position - playerChild.position, Vector3.up);

            // Apply smooth rotation towards the target
            playerChild.rotation = Quaternion.Slerp(playerChild.rotation, targetRotation, 7f * Time.deltaTime);

        }

    }


    private void halfScreenInput()
    {
            // Input handling logic for half-screen swipe controls
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouch = Input.GetTouch(0).position;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouch = Input.GetTouch(0).position;

                // Get the half width of the screen
                float halfScreenWidth = Screen.width / 2f;

                // Check if the swipe occurred on the left half of the screen
                if (startTouch.x < halfScreenWidth && endTouch.x < halfScreenWidth)
                {
                    // Swipe occurred on the left half of the screen
                    if (endTouch.x > startTouch.x)
                    {
                        if (currentIndex != 0)
                        {
                        playerTransforms = ve.GetValidChildTransforms(rb.gameObject, "Pos");

                        for (int i = 0; i < playerTransforms.Count; i++)
                        {
                            Debug.Log("lppl");
                            Transform playerChild = ve.GetValidChild(playerTransforms[i]);
                            playerChild.GetComponent<Animator>().SetTrigger("Right");
                        }
                        target = rightLook;
                            targetIndex = currentIndex - 1;
                            HapticFeedback.MediumFeedback();
                        }
                    }
                    else if (endTouch.x < startTouch.x)
                    {
                        if (currentIndex != 1)
                        {
                        playerTransforms = ve.GetValidChildTransforms(rb.gameObject, "Pos");

                        for (int i = 0; i < playerTransforms.Count; i++)
                        {
                            Transform playerChild = ve.GetValidChild(playerTransforms[i]);
                            playerChild.GetComponent<Animator>().SetTrigger("Left");
                        }
                        target = leftLook;
                            targetIndex = currentIndex + 1;
                            HapticFeedback.MediumFeedback();
                        }
                    }
                }
            }
        
    }

    private void fullScreenInput()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !JoystickCanva.activeSelf)
        {
            startTouch = Input.GetTouch(0).position;
        }


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && !JoystickCanva.activeSelf)
        {
            endTouch = Input.GetTouch(0).position;

            if (endTouch.x > startTouch.x && !JoystickCanva.activeSelf)
            {
                if (currentIndex != 0)
                {
                   
                        target = rightLook;
                    targetIndex = currentIndex - 1;
                    HapticFeedback.MediumFeedback();
                }
            }
            else if (endTouch.x < startTouch.x && !JoystickCanva.activeSelf)
            {
                if (currentIndex != 1)
                {
                    
                    target = leftLook;
                    targetIndex = currentIndex + 1;
                    HapticFeedback.MediumFeedback();
                }
            }
        }
    }

}
