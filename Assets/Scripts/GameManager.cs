using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform[] characterPos;

    public GameObject Normalcharacter;
    public GameObject Supercharacter;
    public GameObject SuperUltracharacter;
    public GameObject ProMaxCharacter;
 /*   public TextMeshProUGUI playerCount;*/



    public void UpdateCharacters(int totalCount)
    {
        int normalCharacterCount = totalCount % 5;
        int superCharacterCount = (totalCount / 5) % 5;
        int ultraCharacterCount = (totalCount / 25) % 5;
        int proMaxCharacterCount = totalCount / 125;

        // Ensure the total number of characters does not exceed 8
        int totalCharacters = normalCharacterCount + superCharacterCount + ultraCharacterCount+proMaxCharacterCount;
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
            Instantiate(Normalcharacter, characterPos[currentPosition].position, Quaternion.identity, characterPos[currentPosition]);
            currentPosition = (currentPosition + 1) % characterPos.Length;
        }

        for (int i = 0; i < superCharacterCount; i++)
        {
            Instantiate(Supercharacter, characterPos[currentPosition].position, Quaternion.identity, characterPos[currentPosition]);
            currentPosition = (currentPosition + 1) % characterPos.Length;
        }

        for (int i = 0; i < ultraCharacterCount; i++)
        {
            Instantiate(SuperUltracharacter, characterPos[currentPosition].position, Quaternion.identity, characterPos[currentPosition]);
            currentPosition = (currentPosition + 1) % characterPos.Length;
        }

        for (int i = 0; i < proMaxCharacterCount; i++)
        {
            Instantiate(ProMaxCharacter, characterPos[currentPosition].position, Quaternion.identity, characterPos[currentPosition]);
            currentPosition = (currentPosition + 1) % characterPos.Length;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("InnerWall"))
        {
            int num=other.gameObject.GetComponent<Wall_Ques>().n;

            if(other.gameObject.GetComponent<Wall_Ques>().randomOperator=='+')
            CurrentNum.characterNum += num;
            if (other.gameObject.GetComponent<Wall_Ques>().randomOperator == '/')
            {
                CurrentNum.characterNum = CurrentNum.characterNum / num;
                if (CurrentNum.characterNum < 0)
                {
                    CurrentNum.characterNum = 0;
                }
            }
            if (other.gameObject.GetComponent<Wall_Ques>().randomOperator == 'X')
                CurrentNum.characterNum = CurrentNum.characterNum* num;
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

            UpdateCharacters(CurrentNum.characterNum);
       /*     playerCount.text = CurrentNum.characterNum.ToString();*/

           
           
        }
    }




}
