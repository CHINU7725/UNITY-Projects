using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{


    [SerializeField] GameObject spawnPoint;
    [SerializeField] List<GameObject> prefabsToSpawn;
    public Transform DroneSpawnPoint;
    public GameObject DroneSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            Destroy(other.gameObject);
            Instantiate(DroneSpawn, DroneSpawnPoint.position, Quaternion.identity);
            int index = Random.Range(0, prefabsToSpawn.Count - 1);
            GameObject spawn = prefabsToSpawn[index];
            Instantiate(spawn, spawnPoint.transform.position, Quaternion.identity);
        }
        else
        {
            if(other.gameObject.tag =="Wall")
            {
                Destroy(other.gameObject);
            }
        }
    }
}
