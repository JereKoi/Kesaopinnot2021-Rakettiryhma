using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminaBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxStamina(int stamina)
    {
        slider.maxValue = stamina;
        slider.value = stamina;
    }

    public void SetStamina(int stamina)
    {
        slider.value = stamina;
    }
   






    public void AddStamina()
    {
        slider.value += 30;
    }

    public void RemoveStamina()
    {
        slider.value -= 30;
    }
}
