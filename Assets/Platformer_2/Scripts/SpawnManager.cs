using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{


    [SerializeField] GameObject spawnPoint;
    [SerializeField] List<GameObject> LeveList;
    public Transform DroneSpawnPoint;
    public GameObject DroneSpawn;

    int i = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {

            CurrentNum.EnemyDeadCount = 0;
            CurrentNum.EnemiesCount = 0;
            GameObject kaka= Instantiate(DroneSpawn, DroneSpawnPoint.position, Quaternion.identity);
            GameObject spawn;
            i++;
            if (i % 5 != 0)
            {
               
                    spawn = LeveList[Random.Range(0,7)];
              
            }
            else
            {

              
                spawn = LeveList[8];
            }

            GameObject SpawnedLevel = Instantiate(spawn, spawnPoint.transform.position, Quaternion.identity);

            if (i %5  == 0 && i!=0)
            {
              
                Wall_Ques[] io = kaka.GetComponentsInChildren<Wall_Ques>();
                int max = 0;

                foreach (Wall_Ques innerW in io)
                {
                    int futureNUmber = GameObject.FindGameObjectWithTag("Heroes").GetComponent<PlayerSpawn>().playerCount;
                    int num = innerW.gameObject.GetComponent<Wall_Ques>().n;
                    if (innerW.gameObject.GetComponent<Wall_Ques>().randomOperator == '+')
                        futureNUmber += num;
                    if (innerW.gameObject.GetComponent<Wall_Ques>().randomOperator == '/')
                    {
                        futureNUmber /= num;
                    }
                    if (innerW.gameObject.GetComponent<Wall_Ques>().randomOperator == 'X')
                        futureNUmber = futureNUmber * num;
                    if (innerW.gameObject.GetComponent<Wall_Ques>().randomOperator == '-')
                    {
                        futureNUmber = futureNUmber - num;
                    }
                    if (innerW.gameObject.GetComponent<Wall_Ques>().randomOperator == '#')
                    {
                        futureNUmber = (int)Mathf.Sqrt(futureNUmber);
                    }
                    if (max < futureNUmber)
                    {
                        max = futureNUmber;
                    }

                    int x = max / 2;
                    max = Random.Range(max , max + x);
                }

                SpawnedLevel.GetComponentInChildren<PlayerSpawn>().SpawnMultipleObjects(max);
                CurrentNum.EnemiesCount = max;
                Debug.LogWarning("lppllp" + max);
            }
            else
            {
                SpawnedLevel.GetComponent<LevelDesigning>().PlaceObjects();
            }
           
        }
    }
}
