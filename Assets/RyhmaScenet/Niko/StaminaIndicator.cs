using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StaminaIndicator: MonoBehaviour
{
    public Image Loading;
    public TMPro.TextMeshProUGUI TextIndicator;
    public TMPro.TextMeshProUGUI TextStamina;
    /*[SerializeField]*/ public float currentStamina;

    public float stamina;
    public float maxStamina;

    public static StaminaIndicator instance;

    private void Awake()
    {
        instance = this;

        PlayerNiko player = new PlayerNiko(); //PlayerNiko voi korvata jollakin toisella
        stamina = player.GetStamina();
        maxStamina = stamina;
    }

    void Start()
    {
        currentStamina = maxStamina;
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

        if(currentStamina < 10)
        {
            TextStamina.color = new Color32(255, 0, 0, 255);
            TextStamina.text = "NO STAMINA!";
        }
        else
        {
            TextStamina.color = new Color32(0, 0, 0, 255);
        }
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
            Debug.Log("Not enough stamina");
        }
    }

    public void AddStamina(float amount)
    {
        if (currentStamina + amount < 100)
        {
            currentStamina += amount;
            Loading.fillAmount = currentStamina;
            TextIndicator.text = ((int)currentStamina).ToString() + "%";
        }
        else
        {
            Debug.Log("Not enough stamina");
        }
    }

    private double FillSpeed()
    {
        double time2fill = 1800; //1800(sec) AKA 30min menee täyttyä
        return 100 / time2fill;
    }
}
