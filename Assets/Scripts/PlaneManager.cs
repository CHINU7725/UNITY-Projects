using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    [SerializeField] GameObject spawnpoint;
    [SerializeField] GameObject prefabstobespawned;
    int iterationCount = 1;
    int factor = 5;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            Destroy(other.gameObject);
            iterationCount++;
            GameObject spawner = prefabstobespawned;
            Instantiate(spawner, spawnpoint.transform.position, Quaternion.identity);
            if (iterationCount % factor == 0)
            {
                GameObject[] innerWalls = GameObject.FindGameObjectsWithTag("InnerWall");
                factor = Random.Range(4, 7);
                iterationCount = 1;


                // Loop through the array of inner walls
                foreach (GameObject innerWall in innerWalls)
                {
                    // Do something with each inner wall, for example:
                    innerWall.GetComponent<Wall_Ques>().reducePlayer(); // Replace YourInnerWallScript with the actual script on your InnerWall objects
                }

            }
            else
            {
                GameObject[] innerWalls = GameObject.FindGameObjectsWithTag("InnerWall");
                // Loop through the array of inner walls
                foreach (GameObject innerWall in innerWalls)
                {
                    // Do something with each inner wall, for example:
                    innerWall.GetComponent<Wall_Ques>().AssignOperater(); // Replace YourInnerWallScript with the actual script on your InnerWall objects
                }

            }

            
            
        }
    }

}
