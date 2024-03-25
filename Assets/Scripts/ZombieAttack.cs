using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ZombieAttack : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 1f, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 1f))
        { 
            if (hit.collider.gameObject.tag == "Heroes")
            {
                /*anim.SetBool("Attack", true);*/
                hit.collider.gameObject.GetComponent<Animator>().SetTrigger("Dead");
                hit.collider.gameObject.GetComponent<Animator>().SetBool("Idle", false);
                hit.collider.gameObject.SetActive(false);
            }
        }
    }
}
