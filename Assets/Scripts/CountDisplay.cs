using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CountDisplay : MonoBehaviour
{
    public Canvas playerPos;
    public TextMeshProUGUI playerCount;
    /*public TextMeshProUGUI enemyCount;*/
    public GameObject Player;
    /*public GameObject Enemy;*/
   
    void Update()
    {
        playerPos.transform.position = Player.transform.position;
        /*enemyCount.transform.position = Enemy.transform.position;*/
        playerCount.text = CurrentNum.characterNum.ToString();
        /*enemyCount.text = CurrentNum.EnemiesCount.ToString();*/
    }
}
