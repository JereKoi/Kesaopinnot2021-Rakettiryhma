using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonHower : MonoBehaviour
{
    public GameObject StaminaButtonHower;

    public void OnMouseOver()
    {
        StaminaButtonHower.SetActive(true);
    }

    public void OnMouseExit()
    {
        StaminaButtonHower.SetActive(false);
    }
}
