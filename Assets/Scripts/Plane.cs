using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UIElements;

public class Plane : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    private void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
