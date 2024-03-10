using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

            iterationCount++;
            GameObject spawner = prefabstobespawned;
           var op= Instantiate(spawner, spawnpoint.transform.position, Quaternion.identity);
            EnemiesShow enemies = op.transform.GetChild(2).GetComponent<EnemiesShow>();
            int max = 0;
            GameObject[] ino = new GameObject[2];
            ino[0] = other.transform.GetChild(0).gameObject;
            ino[1] = other.transform.GetChild(1).gameObject;
            foreach (GameObject innerW in ino)
            {
                int futureNUmber = CurrentNum.PrevNum;
                int num = innerW.gameObject.GetComponent<Wall_Ques>().n;
                Debug.Log("xjdhjsdhjx" + num);
                if (innerW.gameObject.GetComponent<Wall_Ques>().randomOperator == '+')
                    futureNUmber += num;
                if (innerW.gameObject.GetComponent<Wall_Ques>().randomOperator == '/')
                {
                    futureNUmber = futureNUmber / num;
                }
                if (innerW.gameObject.GetComponent<Wall_Ques>().randomOperator == 'X')
                    futureNUmber = futureNUmber * num;
                if (innerW.gameObject.GetComponent<Wall_Ques>().randomOperator == '-')
                {
                    futureNUmber = futureNUmber - num;
                }
                if(innerW.gameObject.GetComponent<Wall_Ques>().randomOperator == '#')
                {
                    futureNUmber = (int)Mathf.Sqrt(futureNUmber);
                }
                if (max < futureNUmber)
                {
                    max = futureNUmber;
                }
            }

            enemies.PlaceEnemy(max);

            Debug.Log("pinky " + max);
            Destroy(other.gameObject);
            GameObject[] innerWalls = GameObject.FindGameObjectsWithTag("InnerWall");
            if (iterationCount % factor == 0)
            {

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

                // Loop through the array of inner walls
                foreach (GameObject innerWall in innerWalls)
                {
                    // Do something with each inner wall, for example:
                    innerWall.GetComponent<Wall_Ques>().AssignOperater(); // Replace YourInnerWallScript with the actual script on your InnerWall objects
                }

            }

            if (CurrentNum.EnemiesCount > CurrentNum.characterNum)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                CurrentNum.reset();
            }
        }
    }

}
