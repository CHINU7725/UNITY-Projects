using System.Collections;
using CandyCoded.HapticFeedback;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerPrefab; // Assign the player prefab in the Inspector
    public Transform magnet; // Assign the magnet Transform in the Inspector
    /*public int numObjectsToSpawn = 10; // Number of objects to spawn when space is pressed
*/

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            magnet.gameObject.GetComponent<MagneticField>().enabled = true;
            SpawnMultipleObjects(20);
           StartCoroutine(disableMagnet());
        }
    }

    public void SpawnMultipleObjects(int numObjectsToSpawn)
    {
        Debug.Log(numObjectsToSpawn);
        for (int i = 0; i < numObjectsToSpawn; i++)
        {
            var character = Instantiate(playerPrefab,transform);
            /*           var character =  Instantiate(playerPrefab, new Vector3(magnet.position.x + 0.1f, magnet.position.y, magnet.position.z), Quaternion.identity);*/
            character.transform.SetParent(transform, false);
        }
    }

    IEnumerator disableMagnet()
    {
        yield return new WaitForSeconds(2f);
      /*  magnet.gameObject.GetComponent<MagneticField>().enabled = false;*/
    }


    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.CompareTag("InnerWall"))
        {
            HapticFeedback.MediumFeedback();
            int num = other.gameObject.GetComponent<Wall_Ques>().n;

            if (other.gameObject.GetComponent<Wall_Ques>().randomOperator == '+')
            {
                SpawnMultipleObjects(num);
                CurrentNum.characterNum += num;
            }
            if (other.gameObject.GetComponent<Wall_Ques>().randomOperator == '/')
            {
                CurrentNum.characterNum = CurrentNum.characterNum / num;
                if (CurrentNum.characterNum < 0)
                {
                    CurrentNum.characterNum = 0;
                }
            }
            if (other.gameObject.GetComponent<Wall_Ques>().randomOperator == 'X')
            {
                SpawnMultipleObjects(num*CurrentNum.characterNum - CurrentNum.characterNum);
                CurrentNum.characterNum = CurrentNum.characterNum * num;
            }
            if (other.gameObject.GetComponent<Wall_Ques>().randomOperator == '-')
            {
                CurrentNum.characterNum = CurrentNum.characterNum - num;
                if (CurrentNum.characterNum < 0)
                {
                    CurrentNum.characterNum = 0;
                }
            }
            if (other.gameObject.GetComponent<Wall_Ques>().randomOperator == '#')
            {
                CurrentNum.characterNum = (int)math.sqrt(CurrentNum.characterNum);
            }

          



        }
    }

}