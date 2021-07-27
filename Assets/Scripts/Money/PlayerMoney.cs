using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    public int money = 0;
    //public Text moneyText;
    //public Text moneyShopText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI moneyShopText;

    public static PlayerMoney Instance;

    
    int pinkSkin;
    int blueSkin;
    int orangeSkin;
    int whiteSkin;
    int redSkin;
    int greenSkin;

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

        redSkin = PlayerPrefs.GetInt("Pink");
        redSkin = PlayerPrefs.GetInt("Blue");
        redSkin = PlayerPrefs.GetInt("Orange");
        redSkin = PlayerPrefs.GetInt("White");
        redSkin = PlayerPrefs.GetInt("Red");
        redSkin = PlayerPrefs.GetInt("Green");
        currentSkin = PlayerPrefs.GetInt("CSkin");
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

    public void PinkSkin()
    {
        if (pinkSkin != 0)
        {
            currentSkin = 1;
            PlayerPrefs.SetInt("CSkin", 1);
        }
        else
        {
            minusMoney(5);
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.GetInt("money", money);
            moneyText.text = money.ToString() + "$";
            moneyShopText.text = this.money.ToString() + "$";
            PlayerPrefs.SetInt("Pink", 1);
            pinkSkin = PlayerPrefs.GetInt("Pink");
            currentSkin = 1;
            PlayerPrefs.SetInt("CSkin", 1);
        }
    }
    public void BlueSkin()
    {
        if (blueSkin != 0)
        {
            currentSkin = 2;
            PlayerPrefs.SetInt("CSkin", 2);
        }
        else
        {
            minusMoney(5);
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.GetInt("money", money);
            moneyText.text = money.ToString() + "$";
            moneyShopText.text = this.money.ToString() + "$";
            PlayerPrefs.SetInt("Blue", 1);
            blueSkin = PlayerPrefs.GetInt("Blue");
            currentSkin = 2;
            PlayerPrefs.SetInt("CSkin", 2);
        }
    }
    public void OrangeSkin()
    {
        if (orangeSkin != 0)
        {
            currentSkin = 3;
            PlayerPrefs.SetInt("CSkin", 3);
        }
        else
        {
            minusMoney(5);
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.GetInt("money", money);
            moneyText.text = money.ToString() + "$";
            moneyShopText.text = this.money.ToString() + "$";
            PlayerPrefs.SetInt("Orange", 1);
            orangeSkin = PlayerPrefs.GetInt("Orange");
            currentSkin = 3;
            PlayerPrefs.SetInt("CSkin", 3);
        }
    }
    public void WhiteSkin()
    {
        if (whiteSkin != 0)
        {
            currentSkin = 4;
            PlayerPrefs.SetInt("CSkin", 4);
        }
        else
        {
            PlayerPrefs.SetInt("White", 1);
            pinkSkin = PlayerPrefs.GetInt("White");
            currentSkin = 4;
            PlayerPrefs.SetInt("CSkin", 4);
        }
    }
    public void RedSkin()
    {
        if (redSkin != 0)
        {
            currentSkin = 5;
            PlayerPrefs.SetInt("CSkin", 5);
        }
        else
        {
            minusMoney(5);
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.GetInt("money", money);
            moneyText.text = money.ToString() + "$";
            moneyShopText.text = this.money.ToString() + "$";
            PlayerPrefs.SetInt("Red", 1);
            redSkin = PlayerPrefs.GetInt("Red");
            currentSkin = 5;
            PlayerPrefs.SetInt("CSkin", 5);
        }
    }
    public void GreenSkin()
    {
        if (greenSkin != 0)
        {
            currentSkin = 6;
            PlayerPrefs.SetInt("CSkin", 6);
        }
        else
        {
            minusMoney(5);
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.GetInt("money", money);
            moneyText.text = money.ToString() + "$";
            moneyShopText.text = this.money.ToString() + "$";
            PlayerPrefs.SetInt("Green", 1);
            greenSkin = PlayerPrefs.GetInt("Green");
            currentSkin = 6;
            PlayerPrefs.SetInt("CSkin", 6);

        }
    }
}
