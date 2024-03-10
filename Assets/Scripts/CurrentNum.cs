using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentNum : MonoBehaviour
{
    public static int characterNum=1;
    public static int PrevNum=1;


    public static int EnemiesCount=0;


    public static void reset()
    {
        characterNum = 1;
        PrevNum = 1 ;
        EnemiesCount = 0;
    }
}
