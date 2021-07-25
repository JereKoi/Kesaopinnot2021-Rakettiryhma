using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StaminaIndicator: MonoBehaviour
{
    public Image Loading;
    public TMPro.TextMeshProUGUI TextIndicator;
    public TMPro.TextMeshProUGUI TextStamina;
    public float currentStamina;

    public GameObject banner;
    public GameObject arrow;

    public float stamina;
    public float maxStamina;

    public static StaminaIndicator instance;

    private void Awake()
    {
        instance = this;
        maxStamina = stamina;
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("S"))
        {
            currentStamina = PlayerPrefs.GetFloat("S");
            TextIndicator.text = ((int)currentStamina).ToString() + "%";
        }
        else
        {
            currentStamina = maxStamina;
            currentStamina = 100;
            TextIndicator.text = ((int)currentStamina).ToString() + "%";
        }
        string dateQuitString = PlayerPrefs.GetString("dateQuit", "");
        if (!dateQuitString.Equals(""))
        {
            DateTime dateQuit = DateTime.Parse(dateQuitString);
            DateTime dateNow = DateTime.Now;

            if (dateNow > dateQuit)
            {
                TimeSpan timespan = dateNow - dateQuit;
                int minutes = (int)timespan.TotalMinutes;
                //Debug.Log("quit for " + minutes + " minutes");
                currentStamina += minutes;
                TextIndicator.text = ((int)currentStamina).ToString() + "%";
                if (currentStamina >= 100)
                {
                    currentStamina = 100;
                    TextIndicator.text = ((int)currentStamina).ToString() + "%";
                }
            }
            PlayerPrefs.SetString("dateQuit", "");
        }
        StartCoroutine("StaminaCounter");
    }

    void Update()
    {
        if(currentStamina < 100)
        {
            currentStamina += (float) FillSpeed() * Time.deltaTime;
            TextIndicator.text = ((int)currentStamina).ToString() + "%";
            TextStamina.text = "RECHARGING!";
        }
        else
        {
            TextStamina.text = "READY!";
        }
        Loading.GetComponent<Image>().fillAmount = currentStamina / 100;

        if(currentStamina < 5)
        {
            TextStamina.color = new Color32(255, 0, 0, 255);
            TextStamina.text = "NO STAMINA!";
        }
        else
        {
            TextStamina.color = new Color32(0, 0, 0, 255);
        }
    }

    public void CheckStaminaAfterOpenShop()
    {
        if (currentStamina < 5)
        {
            arrow.SetActive(true);
            banner.SetActive(true);
        }
    }

    IEnumerator StaminaCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(30f);
            if (currentStamina >= 100)
            {
                currentStamina = 100;
                TextIndicator.text = ((int)currentStamina).ToString() + "%";
            }
            else
            {
                currentStamina++;
                TextIndicator.text = ((int)currentStamina).ToString() + "%";
            }
        }
    }

    public void OnApplicationQuit()
    {
        DateTime dateQuit = DateTime.Now;
        PlayerPrefs.SetString("dateQuit", dateQuit.ToString());
        PlayerPrefs.SetFloat("S", currentStamina);
        //Debug.Log("quit at" + dateQuit.ToString());
    }

    public void UseStamina(float amount)
    {
        if (currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            Loading.fillAmount = currentStamina;
        }
        else
        {
        }
    }

    private double FillSpeed()
    {
        double time2fill = 1500; //1800(sec) AKA 30min menee täyttyä
        return 100 / time2fill;
    }
}
