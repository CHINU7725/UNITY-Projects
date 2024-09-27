using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("Hi");
        SceneManager.LoadScene("DemoScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
