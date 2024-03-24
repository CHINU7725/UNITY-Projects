using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AnimationChanger : MonoBehaviour
{
    private GameObject enemiesParent;

    List<Transform> enemyTransforms = new List<Transform>();
    public void PlayerWin(GameObject op)
    {
        enemiesParent = op.transform.GetChild(2).gameObject;
        enemyTransforms = GetValidChildTransforms(enemiesParent, "Pos");

        foreach (var xombie in enemyTransforms)
        {
            StartCoroutine(ActivateDeadAnimationAfterDelay(xombie.GetChild(0).GetComponent<Animator>()));
        }
        
    }


    public void PlayerLose()
    {

    }

    private IEnumerator ActivateDeadAnimationAfterDelay(Animator animator)
    {
        yield return new WaitForSeconds(3f); // Wait for 4 seconds
        if (animator != null)
        {
            animator.SetTrigger("Dead"); // Activate the "Dead" animation
        }
        else
        {
            Debug.LogWarning("No Animator component found on this GameObject.");
        }
        yield return new WaitForSeconds(1f);
        CurrentNum.EnemyDead = true;
    }

    List<Transform> GetValidChildTransforms(GameObject parent, string nameStartsWith)
    {
        List<Transform> validTransforms = new List<Transform>();

        foreach (Transform child in parent.transform)
        {
            if (child.name.StartsWith(nameStartsWith) && child.childCount == 1)
            {
                validTransforms.Add(child);
            }
        }

        return validTransforms;
    }

    Transform GetValidChild(Transform parent)
    {
        if (parent != null && parent.childCount > 0)
            return parent.GetChild(0);
        else
            return null;
    }
}
