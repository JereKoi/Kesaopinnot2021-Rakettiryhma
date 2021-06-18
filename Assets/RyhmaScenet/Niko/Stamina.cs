using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Stamina : MonoBehaviour
{
    GameObject staminaText;

    public Slider staminaBar;

    private float stamina;
    private float maxStamina;
    private float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(2f); //kuinka useasti regeneroi staminaa (2 sec) atm
    private Coroutine regen;

    public static Stamina instance;

    private void Awake()
    {
        instance = this;
        staminaText = GameObject.Find("EnoughStamina");

        PlayerNiko player = new PlayerNiko(); //PlayerNiko voi korvata jollakin toisella(käyttää PlayerNiko scriptiä)
        stamina = player.GetStamina();
        maxStamina = stamina;
    }

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void UseStamina(float amount)
    {
        if (currentStamina - amount >= 0)
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

    private IEnumerator RegenStamina(float amount)
    {
        yield return new WaitForSeconds(2);

        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 1000; //kuinka monta tickiä menee, jotta stamina regeneroituu 0:sta (tällä hetkellä 33min, kunnes se on täynnä)
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