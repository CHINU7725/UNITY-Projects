using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Collider))]
[DisallowMultipleComponent]
public class FlamethrowerAttackRadius : MonoBehaviour
{

    private List<HealthSystem> EnemiesInRadius = new List<HealthSystem>();

    public GameObject TineFlames;




    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HealthSystem>(out HealthSystem enemy))
        {
            EnemiesInRadius.Add(enemy);
            enemy.StartBurning(3);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<HealthSystem>(out HealthSystem enemy))
        {
            EnemiesInRadius.Remove(enemy);
            enemy.StopBurning();
        }
    }

    private void OnDisable()
    {
     

        EnemiesInRadius.Clear();
    }




}
 