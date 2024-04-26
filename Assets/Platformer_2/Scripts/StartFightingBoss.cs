using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartFightingBoss : MonoBehaviour
{
    GameObject target;
    Transform parentTransform;
    public float moveSpeed = 5f;
    public bool isPlayerEnter = false;
    GameObject player;
    GameObject[] walls;
    GameObject[] Respawns;
    GameObject[] enviornments;

    bool stop=true;
    private void Start()
    {

        target = GameObject.FindGameObjectWithTag("Heroes");
        parentTransform = transform.parent.GetChild(0);
        StartCoroutine(oo());
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

                // Move the child transform's position towards the target position
                childTransform.position = Vector3.MoveTowards(
                    childTransform.position, // Current position of the child transform
                    targetPosition, // Target position
                    moveSpeed * Time.deltaTime // The distance to move each frame
                );
            }
        }

        if (transform.parent.GetChild(0).GetChild(0).gameObject.GetComponent<HealthBoss>().isDead && isPlayerEnter)
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
            transform.parent.GetChild(0).gameObject.GetComponentInChildren<Animator>().SetTrigger("5");
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

    IEnumerator oo()
    {
        yield return new WaitForSeconds(3);
        stop = false;
    }


}
