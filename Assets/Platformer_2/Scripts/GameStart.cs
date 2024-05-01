using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public void GameShuru()
    {
        GameObject[] wall = GameObject.FindGameObjectsWithTag("Wall");
        GameObject[] res= GameObject.FindGameObjectsWithTag("Respawn");
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player22");
        GameObject[] env = GameObject.FindGameObjectsWithTag("Environment");
        GameObject.FindGameObjectWithTag("Timer").GetComponent<TimeCalc>().enabled = true;
        foreach (var i in wall)
        {
            i.GetComponent<Plane>().enabled=true;
        }
        foreach (var i in res)
        {
            i.GetComponent<Plane>().enabled = true;
        }
        foreach (var i in env)
        {
            if(i.GetComponent<Plane>() != null)
            i.GetComponent<Plane>().enabled = true;
            else
            {
                i.GetComponent<LandMove>().enabled = true;
            }
        }
        foreach (var i in player)
        {
            i.GetComponent<Animator>().enabled=true;
        }
   
    }
}
