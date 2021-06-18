using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNiko : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Stamina.instance.UseStamina(15); //luku 15 kertoo määrän, jolla se kuluttaa staminaa
    }

    public float GetStamina()
    {
        return 300; //300 voi korvata jollakin staminan määrällä
    }
}
