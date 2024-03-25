using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CandyCoded.HapticFeedback;
using Unity.VisualScripting;
using System.Linq;

public class PlaneManager : MonoBehaviour
{
    [SerializeField] GameObject spawnpoint;
    [SerializeField] GameObject prefabstobespawned;
    int iterationCount = 0;
    int factor = 5;
/*    public AnimationChanger changer;*/
    public GameObject explosion;
    public ViewEnemies ve;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {

            iterationCount++;
            GameObject spawner = prefabstobespawned;
           var op= Instantiate(spawner, spawnpoint.transform.position, Quaternion.identity);
            CurrentNum.EnemyDeadCount = 0;
            EnemiesShow enemies = op.transform.GetChild(2).GetComponent<EnemiesShow>();
            int max = 0;
            GameObject[] ino = new GameObject[2];
            ino[0] = other.transform.GetChild(0).gameObject;
            ino[1] = other.transform.GetChild(1).gameObject;
            foreach (GameObject innerW in ino)
            {
                int futureNUmber = CurrentNum.PrevNum;
                int num = innerW.gameObject.GetComponent<Wall_Ques>().n;
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
                int x =max/ 2;
                max = Random.Range(max,max + x);
            }
            
            enemies.PlaceEnemy(max);
            CurrentNum.EnemiesCount = max;


            Destroy(other.gameObject);
            GameObject[] innerWalls = GameObject.FindGameObjectsWithTag("InnerWall");
            if (iterationCount < OperatorList.operatorList.Count)
            {
                factor = Random.Range(4, 7);


                // Loop through the array of inner walls
                foreach (GameObject innerWall in innerWalls)
                {
                   
                    // Do something with each inner wall, for example:
                    innerWall.GetComponent<Wall_Ques>().FixedOperators(iterationCount);

                   
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

            /*if (CurrentNum.EnemiesCount > CurrentNum.characterNum)
            {
                StartCoroutine(ExplosionShow());
            }
            else
            {
               *//* changer.PlayerWin(op);*/
           /*     op.GetComponentInChildren<StartFire>().enableRun();*//*
            }*/


            ve.AddPlayer(op.transform.GetChild(2).gameObject);

        }

    }



    IEnumerator ExplosionShow()
    {
        yield return new WaitForSeconds(2);
        explosion.gameObject.SetActive(true);
        HapticFeedback.HeavyFeedback();
        yield return new WaitForSeconds(0.6f);
        explosion.gameObject.SetActive(false);
        explosion.gameObject.SetActive(true);
        HapticFeedback.HeavyFeedback();
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        CurrentNum.reset();
    }

}
