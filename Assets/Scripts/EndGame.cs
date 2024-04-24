using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI yop;
    private void Update()
    {
        yop.text = CurrentNum.characterNum.ToString();
        if (CurrentNum.characterNum == 0)
        {
            Debug.LogWarning(CurrentNum.characterNum);
            CurrentNum.characterNum = 3;
            SceneManager.LoadScene("Start");
        }
    }
}
