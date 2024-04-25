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
        yop.text = GameObject.FindGameObjectWithTag("Heroes").transform.childCount.ToString();

        if (GameObject.FindGameObjectWithTag("Heroes").transform.childCount == 0)
        {
            Debug.LogWarning(CurrentNum.characterNum);
            CurrentNum.characterNum = 3;
            StartCoroutine(resetScene());

        }

      
    }

    IEnumerator resetScene()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene("Start");

    }
}
