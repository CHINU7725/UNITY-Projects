using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{


    [SerializeField] GameObject spawnPoint;
    [SerializeField] List<GameObject> prefabsToSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            Destroy(other.gameObject);

            //Spawn
            int index = Random.Range(0, prefabsToSpawn.Count - 1);
            GameObject spawn = prefabsToSpawn[index];
            Instantiate(spawn, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
