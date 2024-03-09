using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    [SerializeField] GameObject spawnpoint;
    [SerializeField] GameObject prefabstobespawned;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            Destroy(other.gameObject);

            GameObject spawner = prefabstobespawned;
            Instantiate(spawner,spawnpoint.transform.position, Quaternion.identity);
        }
    }

}
