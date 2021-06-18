using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;

    GameObject staminaText;

    private int maxStamina = 100;
    private int currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(1f);
    private Coroutine regen;

    public static StaminaBar instance;

    private void Awake()
    {
        instance = this;
        staminaText = GameObject.Find("EnoughStamina");
    }

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void UseStamina(int amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;


            if (regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenStamina(amount));
        }
        else
        {
            Debug.Log("Not enough stamina");
        }

        if (currentStamina >= amount)
        {
            staminaText.SetActive(true);
        }
        else
        {
            staminaText.SetActive(false);
        }
    }

    private IEnumerator RegenStamina(int amount)
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            yield return regenTick;

            if (currentStamina >= amount)
            {
                staminaText.SetActive(true);
            }
            else
            {
                staminaText.SetActive(false);
            }
        }
        regen = null;
    }
}
