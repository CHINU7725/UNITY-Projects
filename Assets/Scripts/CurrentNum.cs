using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentNum : MonoBehaviour
{
    public static int characterNum=3;
    public static int PrevNum=1;


    public static int EnemiesCount=0;

    public static int EnemyDeadCount=0;

    public static Vector3 enemyPosition=Vector3.up;





    public static List<GameObject> players=new List<GameObject>();
    public static List<GameObject> enemies= new List<GameObject>();
    

    public static void reset()
    {
        characterNum = 3;
        PrevNum = 1 ;
        EnemiesCount = 0;
        EnemyDeadCount =0 ;
        players.Clear();
        enemies.Clear();
    }



}
