using System.Collections.Generic;
using System.Collections;
using UnityEngine;

using UnityEngine.Pool;

[DisallowMultipleComponent]
public class Flamethrower : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ShootingSystem;

    [SerializeField]
    private FlamethrowerAttackRadius AttackRadius;

    [Space]
    [SerializeField]
    private int BurningDPS = 5;
    [SerializeField]
    private float BurnDuration = 3f;

/*    private void Awake()
    {
        OnFirePool = new ObjectPool<ParticleSystem>(CreateOnFireSystem);
*//*        AttackRadius.OnEnemyEnter += StartDamagingEnemy;
        AttackRadius.OnEnemyExit += StopDamagingEnemy;*//*
    }*/

/*    private ParticleSystem CreateOnFireSystem()
    {
        return Instantiate(OnFireSystemPrefab);
    }*/

/*    private void StartDamagingEnemy(HealthSystem Enemy)
    {
        if (Enemy.TryGetComponent<IBurnable>(out IBurnable burnable))
        {
            burnable.StartBurning(BurningDPS);
            ParticleSystem onFireSystem = OnFirePool.Get();
            onFireSystem.transform.SetParent(Enemy.transform, false);
            onFireSystem.transform.localPosition = Vector3.zero;
            ParticleSystem.MainModule main = onFireSystem.main;
            main.loop = true;
            EnemyParticleSystems.Add(Enemy, onFireSystem);
        }
    }*/


/*    private IEnumerator DelayedDisableBurn(HealthSystem Enemy, ParticleSystem Instance, float Duration)
    {
        ParticleSystem.MainModule main = Instance.main;
        main.loop = false;
        yield return new WaitForSeconds(Duration);
        Instance.gameObject.SetActive(false);
        if (Enemy.TryGetComponent<IBurnable>(out IBurnable burnable))
        {
            burnable.StopBurning();
        }
    }

    private void StopDamagingEnemy(HealthSystem Enemy)
    {
        if (EnemyParticleSystems.ContainsKey(Enemy))
        {
            StartCoroutine(DelayedDisableBurn(Enemy, EnemyParticleSystems[Enemy], BurnDuration));
            EnemyParticleSystems.Remove(Enemy);
        }
    }*/

    private void Update()
    {
     
        /*  if (Mouse.current.leftButton.isPressed)
          {

          }
          else
          {
              StopShooting();
          }*/
    }

    public void Shoot()
    {
        ShootingSystem.gameObject.SetActive(true);
        AttackRadius.gameObject.SetActive(true);
    }

    public void StopShooting()
    {
        AttackRadius.gameObject.SetActive(false);
        ShootingSystem.gameObject.SetActive(false);
    }
}
