using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMove : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    private void Update()
    {
        transform.Translate(Vector3.left* Time.deltaTime * speed);
    }
}
