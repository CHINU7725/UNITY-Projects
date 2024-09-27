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


  /*  private void Start()
    {
        
       
    }*/

    public void PlaceEnemy(int totalCount)
    {
        characterPos = new Transform[50];
        for (int i = 0; i < this.transform.childCount; i++)
        {
            characterPos[i] = this.transform.GetChild(i);
        }
        CurrentNum.EnemiesCount = totalCount;
        int normalCharacterCount = totalCount % 8;
        int superCharacterCount = (totalCount / 8) % 8;
        int ultraCharacterCount = (totalCount / 64) % 8;
        int proMaxCharacterCount = totalCount / 512;

        // Ensure the total number of characters does not exceed 8
        int totalCharacters = normalCharacterCount + superCharacterCount + ultraCharacterCount + proMaxCharacterCount;
        if (totalCharacters > 49)
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
        GameObject op;
        for (int i = 0; i < normalCharacterCount; i++)
        {
 
            op=Instantiate(Normalenemy, characterPos[currentPosition].position, Quaternion.identity, characterPos[currentPosition]);
            op.layer = 7;
            currentPosition = (currentPosition + 1) % characterPos.Length;
        }

        for (int i = 0; i < superCharacterCount; i++)
        {
            op=Instantiate(SuperEnemy, characterPos[currentPosition].position, Quaternion.identity, characterPos[currentPosition]);
            op.layer = 7;
            currentPosition = (currentPosition + 1) % characterPos.Length;
        }

        for (int i = 0; i < ultraCharacterCount; i++)
        {
           op= Instantiate(SuperUltraEnemy, characterPos[currentPosition].position, Quaternion.identity, characterPos[currentPosition]);
            op.layer = 7;
            currentPosition = (currentPosition + 1) % characterPos.Length;
        }

        for (int i = 0; i < proMaxCharacterCount; i++)
        {
            op = Instantiate(ProMaxEnemy, characterPos[currentPosition].position, Quaternion.identity, characterPos[currentPosition]);
            op.layer = 7;
            currentPosition = (currentPosition + 1) % characterPos.Length;
        }


        this.gameObject.transform.rotation=Quaternion.Euler(0, 0, 0);
  
    }



    
}
