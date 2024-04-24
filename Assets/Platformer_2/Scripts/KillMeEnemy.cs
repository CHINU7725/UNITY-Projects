using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMeEnemy : MonoBehaviour
{

    public GameObject splash;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player22"))
        {
            ++CurrentNum.EnemyDeadCount;
            Debug.LogWarning(CurrentNum.EnemyDeadCount);
            Destroy(this.gameObject);
            var spawner = Instantiate(splash, new Vector3(transform.position.x, transform.position.y + 1.3f, transform.position.z), Quaternion.identity);
            spawner.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        }

    }


}