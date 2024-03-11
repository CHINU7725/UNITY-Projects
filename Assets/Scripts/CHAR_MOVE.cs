using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAR_MOVE : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 2.5f;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        Vector3 movement;
        movement = new Vector3(xMove, 0.0f, zMove);
        rb.AddForce(movement * speed);
      
    }
}
