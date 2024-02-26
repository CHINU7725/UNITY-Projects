using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    [SerializeField] GameObject lane1cube;
    [SerializeField] GameObject lane2cube;
    [SerializeField] GameObject lane3cube;
    private Vector3[] lanepos;
    int target_index;
    int currentlaneindex;
    void Start()
    {
        lanepos = new Vector3[3];
        currentlaneindex = 1;
        lanepos[0] = lane1cube.transform.position;
        lanepos[1] = lane1cube.transform.position;
        lanepos[2] = lane1cube.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.fwd * 5f);
            Debug.Log("FWD");
        }*/
        /*if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * 5f);
            Debug.Log("REV");
        }*/
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 5f);
            Debug.Log("JUMP");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //rb.AddForce(Vector3.left * 5f);
            if (currentlaneindex != 2)
                target_index = currentlaneindex + 1;
            currentlaneindex = target_index;
            Debug.Log(lanepos[target_index]);
            Debug.Log("LEFT");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //rb.AddForce(Vector3.right * 5f);
            if (currentlaneindex != 0)
                target_index = currentlaneindex - 1;
            currentlaneindex = target_index;
            Debug.Log(lanepos[target_index]);
            Debug.Log("Rigth");
        }
        var step = 5f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, lanepos[target_index], step);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
    }
}
