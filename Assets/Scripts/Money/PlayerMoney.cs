using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    public int money = 0;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI moneyShopText;

    public static PlayerMoney Instance;

    public int currentSkin;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
            moneyText.text = this.money.ToString() + "$";
            moneyShopText.text = this.money.ToString() + "$";
        }
        else
        {
            money = 0;
        }
    }

    public void addMoney (int moneyToAdd)
    {
        money += moneyToAdd;
        moneyText.text = money.ToString() + "$";
        moneyShopText.text = this.money.ToString() + "$";
        PlayerPrefs.SetInt("money", money);
    }

    public void minusMoney(int moneyToMinus)
    {
        if (money - moneyToMinus < 0)
        {
            return;            
        }
        else
        {
            money -= moneyToMinus;
            PlayerPrefs.SetInt("money", money);
            moneyText.text = PlayerMoney.Instance.money.ToString() + "$";
            moneyShopText.text = PlayerMoney.Instance.money.ToString() + "$";
        }
    }
}
