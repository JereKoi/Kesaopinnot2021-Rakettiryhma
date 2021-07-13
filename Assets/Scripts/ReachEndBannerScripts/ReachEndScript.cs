using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReachEndScript : MonoBehaviour
{
    public GameObject ReachEndBanner;
    public GameObject changeMindButton;

    public void ContinuePlaying()
    {
        ReachEndBanner.SetActive(false);
        changeMindButton.SetActive(true);
    }

    public void StartNewGame()
    {
        ReachEndBanner.SetActive(false);
        changeMindButton.SetActive(false);
        Progressbox.Instance.hahmoLVL1.SetActive(true);
        Progressbox.Instance.hahmoLVL2.SetActive(false);
        PlayerPrefs.DeleteAll();
        Progressbox.Instance.StartNewGameReset();
        StaminaIndicator.instance.currentStamina = StaminaIndicator.instance.maxStamina;
        StaminaIndicator.instance.currentStamina = 100;
        StaminaIndicator.instance.TextIndicator.text = ((int)StaminaIndicator.instance.currentStamina).ToString() + "%";
        StaminaIndicator.instance.OnApplicationQuit();
        PlayerMoney.Instance.money = 0;
        PlayerMoney.Instance.moneyText.text = PlayerMoney.Instance.money.ToString() + "$";
        PlayerMoney.Instance.moneyShopText.text = PlayerMoney.Instance.money.ToString() + "$";
        PlayerPrefs.SetInt("money", PlayerMoney.Instance.money);
    }

    public void ClickChangeMindButton()
    {
        ReachEndBanner.SetActive(true);
    }
}
