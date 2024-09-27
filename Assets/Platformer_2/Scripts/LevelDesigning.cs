using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesigning : MonoBehaviour
{
    public ObstacleManager obstacleManager;
    public void PlaceObjects()
    {
       for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.name.StartsWith("CenterPos"))
            {
                Instantiate(obstacleManager.CenterObjects[Random.Range(0, obstacleManager.CenterObjects.Count)], transform.GetChild(i));
            }

            if (transform.GetChild(i).gameObject.name.StartsWith("LeftPos"))
            {
                Instantiate(obstacleManager.LeftObjects[Random.Range(0, obstacleManager.LeftObjects.Count)], transform.GetChild(i));
            }

            if (transform.GetChild(i).gameObject.name.StartsWith("RightPos"))
            {
                Instantiate(obstacleManager.RightObjects[Random.Range(0, obstacleManager.RightObjects.Count)], transform.GetChild(i));
            }

            if (transform.GetChild(i).gameObject.name.StartsWith("Slider"))
            {
                Instantiate(obstacleManager.Sliders[Random.Range(0, obstacleManager.Sliders.Count)], transform.GetChild(i));
            }
        }
    }
}
