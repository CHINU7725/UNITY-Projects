using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.AI;
using CandyCoded.HapticFeedback;

public class HealthSystem : MonoBehaviour
{

    private int Health;
    [SerializeField] private ProgressBar HealthBar;
    private float MaxHealth;
    Animator animator;
    private bool isDead = false;
    private void Start()
    {
        animator = this.GetComponent<Animator>();

        if (this.gameObject.name.StartsWith("GirlZomb"))
        {
            this.Health = 10;
            MaxHealth = Health;
        }
        else if (this.gameObject.name.StartsWith("CopZomb"))
        {
            this.Health = 20;
            MaxHealth = Health;
        }
        else if (this.gameObject.name.StartsWith("ParasiteZomb"))
        {
            this.Health = 30;
            MaxHealth = Health;
        }
        else if (this.gameObject.name.StartsWith("PumpZomb"))
        {
            this.Health = 40;
            MaxHealth = Health;
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
            HapticFeedback.MediumFeedback();
            this.Health--;
            HealthBar.SetProgress(Health / MaxHealth,3);
            if (this.Health < 0)
            {

                dead();
                isDead = true;
                this.GetComponent<ZombieAttack>().enabled = false;
                this.GetComponent<CapsuleCollider>().enabled = false;
            }

        }
        else if (collision.gameObject.tag == "BakoozaBullet" && !isDead)
        {
            Debug.Log("pink");
            HapticFeedback.MediumFeedback();
            this.Health-=10;
            HealthBar.SetProgress(Health / MaxHealth, 3);
            if (this.Health < 0)
            {

                dead();
                isDead = true;
                this.GetComponent<ZombieAttack>().enabled = false;
                this.GetComponent<CapsuleCollider>().enabled = false;
            }

        }

    }
    private void SetupHealthBar(Canvas Canvas, Camera Camera)
    {
        HealthBar.transform.SetParent(Canvas.transform);
    }

}