using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private void Update()
    {
        if (CurrentNum.characterNum == 0)
        {
            SceneManager.LoadScene("Start");
        }
    }
}
