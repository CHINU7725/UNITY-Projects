using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player22")
        {
           
            
            other.gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
  
        }
    }
}
