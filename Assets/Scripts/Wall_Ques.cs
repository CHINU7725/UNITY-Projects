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
        op = new List<char> { '+', '-', 'X', '/' };
        int opIndex = Random.Range(0, op.Count);
        randomOperator = op[opIndex];
        n = Random.Range(1, 10);
        if (equation != null)
        {
            equation.text = randomOperator + " " + n;
        }
        else
        {
            Debug.LogError("TextMeshProUGUI element reference not set in the inspector!");
        }
    }
}
