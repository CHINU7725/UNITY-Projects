using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;
[CreateAssetMenu(fileName = "Shoot Config", menuName = "Guns/Shoot Configuration", order = 2)]

public class ShootConfiguationScriptableObjects : ScriptableObject
{
    public LayerMask HitMask;
    public Vector3 Spread = new Vector3 (0.1f, 0.1f, 0.1f);
    public float fireRate = 0.25f;
}
