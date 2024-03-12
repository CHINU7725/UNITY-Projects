using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrdgeSpawn : MonoBehaviour
{

    [SerializeField] GameObject spawnpoint;
    [SerializeField] GameObject prefabstobespawned;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bridge")
        {
            GameObject spawner = prefabstobespawned;
            var op = Instantiate(spawner, spawnpoint.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}