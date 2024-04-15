using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleManager", menuName = "ScriptableObjects/ObstacleManagerScriptableObject", order = 1)]
public class ObstacleManager : ScriptableObject
{
    public List<GameObject> CenterObjects = new List<GameObject>();
    public List<GameObject> LeftObjects = new List<GameObject>();
    public List<GameObject> RightObjects = new List<GameObject>();
    public List<GameObject> Sliders = new List<GameObject>();
}
