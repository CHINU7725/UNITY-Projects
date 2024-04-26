using System.Collections;
using UnityEngine;

public class ControlLose : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Heroes")
        {
            other.gameObject.GetComponentInParent<SwipeMovement>().enabled = false;
            this.GetComponent<AudioSource>().enabled = true;

            StartCoroutine(MoveTowardsTarget(other.gameObject.transform.parent.gameObject, new Vector3(0.6907592f, -7.193927f, 9.513805f), 20f));
        }
    }

    IEnumerator MoveTowardsTarget(GameObject obj, Vector3 targetPosition, float speed)
    {
        while (Vector3.Distance(obj.transform.localPosition, targetPosition) > 0.01f)
        {
            obj.transform.localPosition = Vector3.MoveTowards(obj.transform.localPosition, targetPosition, speed * Time.deltaTime);
            yield return null; 
        }
    }
}
