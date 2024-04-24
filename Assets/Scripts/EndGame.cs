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
        StartCoroutine(resetScene());
    }

    IEnumerator resetScene()
    {
        yield return new WaitForSeconds(4);
        yop.text = CurrentNum.characterNum.ToString();
        if (CurrentNum.characterNum == 0)
        {
            Debug.LogWarning(CurrentNum.characterNum);
            CurrentNum.characterNum = 3;
            SceneManager.LoadScene("Start");
        }
    }
}
