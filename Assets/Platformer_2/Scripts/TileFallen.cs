using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomActivateRigidbodies : MonoBehaviour
{
     List<GameObject> gameObjectList = new List<GameObject>(); // Public list of GameObjects
    public float shakeTime = 1f; // Duration of the shaking effect
    private float shakeStrength = 0.05f; // Strength of the shaking effect
    public int NumberOfFallenTiles = 8;

    void Start()
    {
        PopulateGameObjectList();
        // Shuffle the list
        ShuffleList(gameObjectList);

        // Activate the rigidbodies of the first 4 GameObjects with a shaking effect
        for (int i = 0; i < NumberOfFallenTiles; i++)
        {
            if (gameObjectList.Count > i)
            {
                GameObject obj = gameObjectList[i];
                StartCoroutine(ShakeAndActivateRigidbody(obj));
            }
        }
    }

    void ShuffleList(List<GameObject> list)
    {
        // Fisher-Yates shuffle algorithm
        int n = list.Count;
        for (int i = 0; i < n; i++)
        {
            int r = i + Random.Range(0, n - i);
            GameObject temp = list[r];
            list[r] = list[i];
            list[i] = temp;
        }
    }
    void PopulateGameObjectList()
    {
        // Get all child GameObjects and add them to the gameObjectList
        foreach (Transform child in transform)
        {
            gameObjectList.Add(child.gameObject);
        }
    }
    IEnumerator ShakeAndActivateRigidbody(GameObject obj)
    {
        Vector3 originalPosition = obj.transform.position;
        Quaternion originalRotation = obj.transform.rotation;

        float elapsedTime = 0f;
        while (elapsedTime < shakeTime)
        {
            obj.transform.position = originalPosition + Random.insideUnitSphere * shakeStrength;
            obj.transform.rotation = Quaternion.Euler(Random.Range(-shakeStrength, shakeStrength), Random.Range(-shakeStrength, shakeStrength), Random.Range(-shakeStrength, shakeStrength)) * originalRotation;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = originalPosition;
        obj.transform.rotation = originalRotation;

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true; // Activate the rigidbody

        }
    }
}