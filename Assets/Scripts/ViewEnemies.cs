using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.CinemachineTargetGroup;
using static UnityEngine.GraphicsBuffer;

public class ViewEnemies : MonoBehaviour
{
    private GameObject playersParent;
    private GameObject enemiesParent;

    List<Transform> playerTransforms = new List<Transform>();
    List<Transform> enemyTransforms = new List<Transform>();



        public void LookEach()
    {
        if (GameObject.FindGameObjectWithTag("Enemies") == null)
            return;

        playersParent = GameObject.FindGameObjectWithTag("Player");
        enemiesParent = GameObject.FindGameObjectWithTag("Enemies");

        CurrentNum.enemyPosition = enemiesParent.transform.position;

        playerTransforms = GetValidChildTransforms(playersParent, "Pos");
        enemyTransforms = GetValidChildTransforms(enemiesParent, "Pos");





        // Ensure arrays have the same length
        /*if (playerTransforms.Count != enemyTransforms.Count)
        {
            Debug.LogError("Players and enemies arrays must have the same length!");
            return;
        }*/

        int playerCount = playerTransforms.Count;
        int enemyCount = enemyTransforms.Count;

        if (playerCount <= 0)
        {

            Debug.Log("You Lost");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            CurrentNum.reset();
        }

        for (int i = 0; i < enemyCount; i++)
        {
            
            Transform playerChild = GetValidChild(playerTransforms[i % playerCount]); // Access player transforms cyclically
            Transform enemyChild = GetValidChild(enemyTransforms[i]);

            RotateTowards(enemyChild, playerChild);
        }
    }


    public void AddPlayer(GameObject enemies)
    {



        GameObject playersParent = GameObject.FindGameObjectWithTag("Player");


        CurrentNum.enemyPosition = enemies.transform.position;

        playerTransforms = GetValidChildTransforms(playersParent, "Pos");
        enemyTransforms = GetValidChildTransforms(enemies, "Pos");


        CurrentNum.enemies.Clear();
        CurrentNum.players.Clear();

        // Ensure arrays have the same length
        /*if (playerTransforms.Count != enemyTransforms.Count)
        {
            Debug.LogError("Players and enemies arrays must have the same length!");
            return;
        }*/
        for (int i = 0; i < playerTransforms.Count; i++)
        {
            Transform playerChild = GetValidChild(playerTransforms[i]);
            CurrentNum.players.Add(playerChild.gameObject);
        }

            // Rotate players and enemies to face each other
            for (int i = 0; i < enemyTransforms.Count; i++)
        {
     
            Transform enemyChild = GetValidChild(enemyTransforms[i]);

            CurrentNum.enemies.Add(enemyChild.gameObject);
           


        }
    }

    public List<Transform> GetValidChildTransforms(GameObject parent, string nameStartsWith)
    {
        List<Transform> validTransforms = new List<Transform>();

        foreach (Transform child in parent.transform)
        {
            if (child.name.StartsWith(nameStartsWith) && child.childCount > 0)
            {
                validTransforms.Add(child);
            }
        }

        return validTransforms;
    }

   public Transform GetValidChild(Transform parent)
    {
        if (parent != null && parent.childCount > 0)
            return parent.GetChild(0);
        else
            return null;
    }

   public void RotateTowards(Transform target, Transform lookAt)
    {
        if (target == null || lookAt == null)
            return;

        Vector3 direction = lookAt.position - target.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        target.rotation = rotation;
    }


   
}