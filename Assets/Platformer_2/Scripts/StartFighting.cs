using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFighting : MonoBehaviour
{
    GameObject target;
    Transform parentTransform;
    public float moveSpeed = 5f;
    public bool isPlayerEnter = false;
    GameObject player;
    GameObject[] walls;
    GameObject[] Respawns;
    GameObject[] enviornments;
    private void Start()
    {

        target = GameObject.FindGameObjectWithTag("Heroes");
        parentTransform = transform.parent.GetChild(0);
    }
    void Update()
    {



        if (isPlayerEnter)
        {
            // Get the position of the target GameObject
            Vector3 targetPosition = target.transform.position;

            // Loop through each child of the parent transform
            for (int i = 0; i < parentTransform.childCount; i++)
            {
                // Get the child transform
                Transform childTransform = parentTransform.GetChild(i);

                // Calculate the direction from the child to the target
                Vector3 direction = targetPosition - childTransform.position;

                // Normalize the direction vector
                Vector3 normalizedDirection = direction.normalized;

                // Move the child towards the target using the specified speed
                childTransform.position += normalizedDirection * moveSpeed * Time.deltaTime;
            }
        }

        if (transform.parent.GetChild(0).childCount==1 && isPlayerEnter)
        {
            Debug.Log("sd");
            player.gameObject.GetComponentInParent<SwipeMovement>().enabled = true;
            walls = GameObject.FindGameObjectsWithTag("Wall");
            Respawns = GameObject.FindGameObjectsWithTag("Respawn");
            enviornments = GameObject.FindGameObjectsWithTag("Environment");
            foreach (GameObject wall in walls)
            {
                wall.GetComponent<Plane>().enabled = true;
            }
            foreach (GameObject Respawn in Respawns)
            {
                Respawn.GetComponent<Plane>().enabled = true;
            }
            foreach (GameObject envi in enviornments)
            {
                if (envi.GetComponent<Plane>())
                    envi.GetComponent<Plane>().enabled = true;
                else
                    envi.GetComponent<LandMove>().enabled = true;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Heroes")
        {
            player=other.gameObject;
            isPlayerEnter = true;
            walls = GameObject.FindGameObjectsWithTag("Wall");
            Respawns = GameObject.FindGameObjectsWithTag("Respawn");
            enviornments = GameObject.FindGameObjectsWithTag("Environment");
            foreach (GameObject wall in walls)
            {
                wall.GetComponent<Plane>().enabled = false;
            }
            foreach (GameObject Respawn in Respawns)
            {
                Respawn.GetComponent<Plane>().enabled = false;
            }
            foreach (GameObject envi in enviornments)
            {
                if (envi.GetComponent<Plane>())
                    envi.GetComponent<Plane>().enabled = false;
                else
                    envi.GetComponent<LandMove>().enabled = false;
            }
        }

    }


}
