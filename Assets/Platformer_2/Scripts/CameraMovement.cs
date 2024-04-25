using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Heroes")
        {
            GameObject cameraParent = GameObject.FindGameObjectWithTag("Camera");
            cameraParent.transform.GetChild(0).gameObject.SetActive(false);
            cameraParent.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
