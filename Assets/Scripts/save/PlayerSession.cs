using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerSession : MonoBehaviour
{
    //[SerializeField] GameObject welcomePopup;
    //[SerializeField] Text welcomePopupSeconds;
    private StaminaIndicator staminaIndicator;

    public static PlayerSession Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        staminaIndicator.GetComponent<StaminaIndicator>();
        StaminaIndicator.instance.currentStamina = PlayerPrefs.GetFloat("S", 0);
        welcomePopupShow();
        string dateQuitString = PlayerPrefs.GetString("dateQuit","");
        if (!dateQuitString.Equals (""))
        {
            DateTime dateQuit = DateTime.Parse(dateQuitString);
            DateTime dateNow = DateTime.Now;

            if (dateNow>dateQuit)
            {
                TimeSpan timespan = dateNow - dateQuit;
                int seconds = (int)timespan.TotalSeconds;
                Debug.Log("quit for " + seconds + " seconds");
                staminaIndicator.currentStamina += seconds;
                if (seconds>60) //in real game use days (total days)
                {
                    //welcomePopupSeconds.text = seconds + " SECONDS";
                    welcomePopupShow();
                }
            }
            PlayerPrefs.SetString("dateQuit", "");
        }
        StartCoroutine("StaminaCounter");
    }
    private void OnApplicationQuit()
    {
        DateTime dateQuit = DateTime.Now;
        PlayerPrefs.SetString("dateQuit", dateQuit.ToString());
        PlayerPrefs.SetFloat("S", staminaIndicator.currentStamina);
        Debug.Log("quit at" + dateQuit.ToString());
    }

    IEnumerator StaminaCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            StaminaIndicator.instance.currentStamina++;
            StaminaIndicator.instance.TextIndicator.text = ((int)StaminaIndicator.instance.currentStamina).ToString() + "%";
        }
    }

    public void welcomePopupShow()
    {
        //welcomePopup.SetActive(true);
    }

    public void welcomepopupHide()
    {
        //welcomePopup.SetActive(false);
    }
}
