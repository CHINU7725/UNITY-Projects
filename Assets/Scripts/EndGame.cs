using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI yop;
    public TextMeshProUGUI xop;
    public Canvas Died;
    private void Update()
    {
        yop.text = GameObject.FindGameObjectWithTag("Heroes").transform.childCount.ToString();
        xop.text = GameObject.FindGameObjectWithTag("Heroes").transform.childCount.ToString();
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
        GameObject[] wall = GameObject.FindGameObjectsWithTag("Wall");
        GameObject[] res = GameObject.FindGameObjectsWithTag("Respawn");
        GameObject[] env = GameObject.FindGameObjectsWithTag("Environment");
        GameObject.FindGameObjectWithTag("Timer").GetComponent<TimeCalc>().enabled = false;
        foreach (var i in wall)
        {
            i.GetComponent<Plane>().enabled = false;
        }
        foreach (var i in res)
        {
            i.GetComponent<Plane>().enabled = false;
        }
        foreach (var i in env)
        {
            if (i.GetComponent<Plane>() != null)
                i.GetComponent<Plane>().enabled = false;
            else
            {
                i.GetComponent<LandMove>().enabled = false;
            }
        }
        GameObject.FindObjectOfType<SwipeMovement>().enabled = false;
        Died.gameObject.SetActive(true);
        this.GetComponent<EndGame>().enabled=false;


    }
}
