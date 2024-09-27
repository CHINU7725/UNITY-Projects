using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            Destroy(other.gameObject);
        }
        else
        {
            if (other.gameObject.tag == "Wall")
            {
                Destroy(other.gameObject);
            }
        }
    }
}
