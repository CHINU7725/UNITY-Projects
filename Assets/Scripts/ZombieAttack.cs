using System.Collections;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    private Animator anim;
    private bool isAttacking = false; // Flag to track if the zombie is currently attacking

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 1f, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 1f))
        {
            if (!isAttacking && CurrentNum.players!=null && hit.collider.gameObject != null && hit.collider.gameObject.CompareTag("Heroes"))
            {
                anim.SetBool("Attack", true);
                StartCoroutine(delayDead(hit));


            }
        }
    }

    IEnumerator delayDead(RaycastHit hit)
    {
        if (hit.collider.gameObject == null)
           yield return null;
        isAttacking = true; // Set the flag to indicate that the zombie is attacking

        yield return new WaitForSeconds(4f);
        hit.collider.gameObject.GetComponent<Animator>().SetTrigger("Dead");
        yield return new WaitForSeconds(2f);
        CurrentNum.characterNum--;
        CurrentNum.players.Remove(hit.collider.gameObject);
        Destroy(hit.collider.gameObject);
        anim.SetBool("Attack", false);

        isAttacking = false; // Reset the flag after the attack is finished
    }
}
