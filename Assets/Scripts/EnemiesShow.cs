using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesShow : MonoBehaviour
{
    public Transform[] characterPos;

    public GameObject Normalenemy;
    public GameObject SuperEnemy;
    public GameObject SuperUltraEnemy;
    public GameObject ProMaxEnemy;
    /*    public TextMeshProUGUI playerCount;*/

    public int TotalEnemies;


    public void PlaceEnemy(int totalCount)
    {
        CurrentNum.EnemiesCount = totalCount;
        int normalCharacterCount = totalCount % 5;
        int superCharacterCount = (totalCount / 5) % 5;
        int ultraCharacterCount = (totalCount / 25) % 5;
        int proMaxCharacterCount = totalCount / 125;

        // Ensure the total number of characters does not exceed 8
        int totalCharacters = normalCharacterCount + superCharacterCount + ultraCharacterCount + proMaxCharacterCount;
        if (totalCharacters > 16)
        {
            Debug.LogWarning("Total number of characters cannot exceed 16.");
        }
        Debug.Log(totalCount);
        // Clear existing characters
        for (int i = 0; i < characterPos.Length; i++)
        {
            if (characterPos[i].childCount > 0)
            {


                for (int io = 0; io < characterPos[i].childCount; io++)
                {
                    Destroy(characterPos[i].GetChild(io).gameObject);
                }

            }
        }

        int currentPosition = 0;
        for (int i = 0; i < normalCharacterCount; i++)
        {
 
            var op=Instantiate(Normalenemy, characterPos[currentPosition].position, Quaternion.identity, characterPos[currentPosition]);
            currentPosition = (currentPosition + 1) % characterPos.Length;
        }

        for (int i = 0; i < superCharacterCount; i++)
        {
            Instantiate(SuperEnemy, characterPos[currentPosition].position, Quaternion.identity, characterPos[currentPosition]);
            currentPosition = (currentPosition + 1) % characterPos.Length;
        }

        for (int i = 0; i < ultraCharacterCount; i++)
        {
            Instantiate(SuperUltraEnemy, characterPos[currentPosition].position, Quaternion.identity, characterPos[currentPosition]);
            currentPosition = (currentPosition + 1) % characterPos.Length;
        }

        for (int i = 0; i < proMaxCharacterCount; i++)
        {
            Instantiate(ProMaxEnemy, characterPos[currentPosition].position, Quaternion.identity, characterPos[currentPosition]);
            currentPosition = (currentPosition + 1) % characterPos.Length;
        }

        this.gameObject.transform.rotation=Quaternion.Euler(0, 0, 0);
        CurrentNum.PrevNum = CurrentNum.characterNum;
    }



    
}
