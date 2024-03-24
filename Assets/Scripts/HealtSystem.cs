using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    private int Health;
    Animator animator;
    private bool isDead=false;
    private void Start()
    {
        animator = this.GetComponent<Animator>();
  
        if (this.gameObject.name.StartsWith("GirlZomb"))
        {
            this.Health = 10;
        }
        else if (this.gameObject.name.StartsWith("CopZomb"))
        {
            this.Health = 20;
        }
        else if (this.gameObject.name.StartsWith("ParasiteZomb"))
        {
            this.Health = 30;
        }
        else if (this.gameObject.name.StartsWith("PumpZomb"))
        {
            this.Health = 40;
        }
    }
    public void dead()
    {
        animator.SetTrigger("Dead");
     CurrentNum.EnemyDeadCount++;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet" && !isDead)
        {
            this.Health--;
            if (this.Health < 0)
            {
                dead();
                isDead = true;

            }

        }
    }

}