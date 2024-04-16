using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{


    [SerializeField] GameObject spawnPoint;
    [SerializeField] List<GameObject> LeveList;
    public Transform DroneSpawnPoint;
    public GameObject DroneSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        { 
            Instantiate(DroneSpawn, DroneSpawnPoint.position, Quaternion.identity);
            int index = Random.Range(0, LeveList.Count - 1);
            GameObject spawn = LeveList[index];
            GameObject SpawnedLevel =  Instantiate(spawn, spawnPoint.transform.position, Quaternion.identity);
            SpawnedLevel.GetComponent<LevelDesigning>().PlaceObjects();
        }
    }
}
