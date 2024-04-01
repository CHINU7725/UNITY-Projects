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

    [SerializeField]
    private bool _IsBurning;
    public bool IsBurning { get => _IsBurning; set => _IsBurning = value; }

    private Coroutine BurnCoroutine;


/*    public GameObject TinyFlames;*/

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
            if (this.Health <= 0)
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
            if (this.Health <= 0)
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



    public void StartBurning(int DamagePerSecond)
    {
        if (!isDead)
        {
            IsBurning = true;
            if (BurnCoroutine != null)
            {
                StopCoroutine(BurnCoroutine);
            }

            BurnCoroutine = StartCoroutine(Burn(DamagePerSecond));
        }
    }

    private IEnumerator Burn(int DamagePerSecond)
    {
        float minTimeToDamage = 1f / DamagePerSecond;
        WaitForSeconds wait = new WaitForSeconds(minTimeToDamage);
        int damagePerTick = Mathf.FloorToInt(minTimeToDamage) + 1;

        this.Health -= 2;
        HealthBar.SetProgress(Health / MaxHealth, 3);
        if (this.Health <= 0)
        {

            dead();
            isDead = true;
            this.GetComponent<ZombieAttack>().enabled = false;
            this.GetComponent<CapsuleCollider>().enabled = false;
            yield return null;
        }
        while (IsBurning && !isDead)
        {
            yield return wait;
            this.Health -= 2;
            HealthBar.SetProgress(Health / MaxHealth, 3);
            if (this.Health <= 0)
            {

                dead();
                isDead = true;
                this.GetComponent<ZombieAttack>().enabled = false;
                this.GetComponent<CapsuleCollider>().enabled = false;
            }
        }


    }

    public void StopBurning()
    {
        IsBurning = false;
        if (BurnCoroutine != null)
        {
            StopCoroutine(BurnCoroutine);
        }
    }

}