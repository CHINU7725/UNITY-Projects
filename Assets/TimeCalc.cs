using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCalc : MonoBehaviour
{
   public TextMeshProUGUI textMeshProUGUI;

    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text=( (int.Parse(textMeshProUGUI.text.Split(" ")[0])+(int)(Time.fixedDeltaTime*100))).ToString()+" meter";
    }
}
