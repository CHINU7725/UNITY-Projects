using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    [SerializeField] GameObject spawnpoint;
    [SerializeField] List<GameObject> prefabstobespawned;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlaneDestroyer")
        {
            Destroy(other.gameObject);

            //spaawning
            int i = Random.Range(0, prefabstobespawned.Count);
            GameObject spawner = prefabstobespawned[i];
            Instantiate(spawner,spawnpoint.transform.position, Quaternion.identity);
        }
    }

}
