using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wall_Ques : MonoBehaviour
{
    private List<char> op;
    public char randomOperator;
    public int n;
    public TextMeshProUGUI equation;


    private void Awake()
    {
        FixedOperators(0);
    }

    public void AssignOperater()
    {
        op = new List<char> { '+', '-', 'X', '/' };
        int opIndex = 0;

        opIndex = Random.Range(0, op.Count);

        randomOperator = op[opIndex];

        if (randomOperator == '/')
        {
            n = Random.Range(2, 5);
        }
        else if (randomOperator == 'X')
        {
            n = Random.Range(2, 4);
        }
        else
        {
            n = Random.Range(1, 10);
        }
        if (equation != null)
        {
            equation.text = randomOperator + " " + n;
        }
        else
        {
            Debug.LogError("TextMeshProUGUI element reference not set in the inspector!");
        }
        if (randomOperator == 'X' ? CurrentNum.characterNum * n >= 1000 : randomOperator == '+' ? CurrentNum.characterNum+n >= 1000 : false)
        {
            GameObject[] innerWalls = GameObject.FindGameObjectsWithTag("InnerWall");
            // Loop through the array of inner walls
            foreach (GameObject innerWall in innerWalls)
            {
                // Do something with each inner wall, for example:
                innerWall.GetComponent<Wall_Ques>().Emergency(); // Replace YourInnerWallScript with the actual script on your InnerWall objects
            }
        }else if(randomOperator == '/' ? CurrentNum.characterNum / n < 1 : randomOperator == '-' ? CurrentNum.characterNum-n < 1 : false)
        {
            GameObject[] innerWalls = GameObject.FindGameObjectsWithTag("InnerWall");
            foreach (GameObject innerWall in innerWalls)
            {
                // Do something with each inner wall, for example:
                innerWall.GetComponent<Wall_Ques>().Awake(); // Replace YourInnerWallScript with the actual script on your InnerWall objects
            }
        }    
        
    }
    public void reducePlayer()
    {
        op = new List<char> { '-', '/' };
        int opIndex = 0;

        opIndex = Random.Range(0, op.Count);

        randomOperator = op[opIndex];

        if (randomOperator == '/')
        {
            n = Random.Range(2, 5);
        }
        else
        {
            n = Random.Range(5, 30);
        }

        if (equation != null)
        {
            equation.text = randomOperator + " " + n;
        }
        else
        {
            Debug.LogError("TextMeshProUGUI element reference not set in the inspector!");
        }
        if (randomOperator == '/' ? CurrentNum.characterNum / n < 1 : randomOperator == '-' ? CurrentNum.characterNum - n < 1 : false)
        {
            GameObject[] innerWalls = GameObject.FindGameObjectsWithTag("InnerWall");
            foreach (GameObject innerWall in innerWalls)
            {
                // Do something with each inner wall, for example:
                innerWall.GetComponent<Wall_Ques>().Awake(); // Replace YourInnerWallScript with the actual script on your InnerWall objects
            }
        }
    }
    public void Emergency()
    {
        randomOperator = '#';
        n = CurrentNum.characterNum;

        if (equation != null)
        {
            equation.text = "SQRT";
        }
        else
        {
            Debug.LogError("TextMeshProUGUI element reference not set in the inspector!");
        }
    }



    public void FixedOperators(int index)
    {
        if(this.gameObject.name=="Left")
        {
            randomOperator = OperatorList.operatorList[index][0];
        }
        else
        {
            randomOperator = OperatorList.operatorList[index][1];
        }
        n = Random.Range(1, 5);
        equation.text = randomOperator + " " + n;
    }

}