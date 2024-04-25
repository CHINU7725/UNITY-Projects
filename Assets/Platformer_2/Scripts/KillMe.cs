using System.Collections;
using System.Collections.Generic;
using CandyCoded.HapticFeedback;
using UnityEngine;

public class KillMe : MonoBehaviour
{
    public GameObject splash;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            CurrentNum.characterNum--;
            Destroy(this.gameObject);
            HapticFeedback.MediumFeedback();
            var spawner = Instantiate(splash,new Vector3(transform.position.x,transform.position.y+1.3f,transform.position.z),Quaternion.identity);
            spawner.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        }
        if(collision.gameObject.CompareTag("BigBoss"))
        {
            StartCoroutine(KillyoMe(collision.gameObject));
        }
    }


   IEnumerator KillyoMe(GameObject go)
    {
        yield return new WaitForSeconds(1f);

        CurrentNum.characterNum--;
        Destroy(this.gameObject);
        HapticFeedback.MediumFeedback();
        var spawner = Instantiate(splash, new Vector3(transform.position.x, transform.position.y + 1.3f, transform.position.z), Quaternion.identity);
        spawner.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        go.GetComponent<HealthBoss>().karoKamal();
    }
}

