using System.Collections;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerPrefab; // Assign the player prefab in the Inspector
    public Transform magnet; // Assign the magnet Transform in the Inspector
    public int numObjectsToSpawn = 10; // Number of objects to spawn when space is pressed


    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            magnet.gameObject.GetComponent<MagneticField>().enabled = true;
            SpawnMultipleObjects();
           StartCoroutine(disableMagnet());
        }
    }

    public void SpawnMultipleObjects()
    {
        for (int i = 0; i < numObjectsToSpawn; i++)
        {
           var character =  Instantiate(playerPrefab, new Vector3(magnet.position.x + 0.1f, magnet.position.y, magnet.position.z), Quaternion.identity);
            character.transform.SetParent(transform, false);
        }
    }

    IEnumerator disableMagnet()
    {
        yield return new WaitForSeconds(2f);
      /*  magnet.gameObject.GetComponent<MagneticField>().enabled = false;*/
    }
}