using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSave : MonoBehaviour
{
    public GameObject Background1;
    public GameObject Background2;
    public GameObject Background3;
    public GameObject BackgroundText1;
    public GameObject BackgroundText2;
    public Button BackgroundButton2;
    public Button BackgroundButton3;


    public bool isPurchasedBackground2;
    public bool isPurchasedBackground3;

    public int currentBackground;

    public static BackgroundSave instance;

    private void Start()
    {
        instance = this;

        if (PlayerPrefs.HasKey("isPurchasedBackground2"))
        {
            isPurchasedBackground2 = PlayerPrefs.GetInt("isPurchasedBackground2") != 0;
            if (isPurchasedBackground2 == true)
            {
                BackgroundButton2.interactable = true;
                BackgroundText1.SetActive(false);
            }
        }
        if (PlayerPrefs.HasKey("isPurchasedBackground3"))
        {
            isPurchasedBackground3 = PlayerPrefs.GetInt("isPurchasedBackground3") != 0;
            if (isPurchasedBackground3 == true)
            {
                BackgroundButton3.interactable = true;
                BackgroundText2.SetActive(false);
            }
        }
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Background"))
        {
            currentBackground = PlayerPrefs.GetInt("Background");
            if (currentBackground == 1)
            {
                Background1.SetActive(true);
                Background2.SetActive(false);
                Background3.SetActive(false);
            }
            else if (currentBackground == 2)
            {
                Background2.SetActive(true);
                Background1.SetActive(false);
                Background3.SetActive(false);
            }
            else if (currentBackground == 3)
            {
                Background3.SetActive(true);
                Background2.SetActive(false);
                Background1.SetActive(false);
            }
        }
        else
        {
            Background1.SetActive(true);
        }
    }

    private void Update()
    {
        Background2Update();
        Background3Update();
    }

    public void SelectBackground1()
    {
        Background1.SetActive(true);
        Background2.SetActive(false);
        Background3.SetActive(false);
        currentBackground = 1;
        PlayerPrefs.SetInt("Background", 1);
    }
    public void SelectBackground2()
    {
        Background1.SetActive(false);
        Background2.SetActive(true);
        Background3.SetActive(false);
        currentBackground = 2;
        PlayerPrefs.SetInt("Background", 2);
        if (PlayerMoney.Instance.money >= 20)
        {
            PlayerMoney.Instance.minusMoney(20);
            BackgroundText1.SetActive(false);
            PlayerMoney.Instance.moneyText.text = PlayerMoney.Instance.money.ToString() + "$";
            PlayerMoney.Instance.moneyShopText.text = PlayerMoney.Instance.money.ToString() + "$";
            Background1.SetActive(false);
            Background2.SetActive(true);
            Background3.SetActive(false);
            currentBackground = 2;
            PlayerPrefs.SetInt("Background", 2);
            isPurchasedBackground2 = true;
            PlayerPrefs.SetInt("isPurchasedBackground2", isPurchasedBackground2 ? 1 : 0);
            if (PlayerMoney.Instance.money < 20)
            {
                if (isPurchasedBackground2 == false)
                {
                    BackgroundButton2.interactable = false;
                }
            }
        }
        if (isPurchasedBackground2 == true && currentBackground == 2)
        {
            BackgroundText1.SetActive(false);
            BackgroundButton2.interactable = true;
        }
    }
    public void SelectBackground3()
    {
        Background1.SetActive(false);
        Background2.SetActive(false);
        Background3.SetActive(true);
        currentBackground = 3;
        PlayerPrefs.SetInt("Background", 3);

        if (PlayerMoney.Instance.money >= 20)
        {
            PlayerMoney.Instance.minusMoney(20);
            BackgroundText2.SetActive(false);
            PlayerMoney.Instance.moneyText.text = PlayerMoney.Instance.money.ToString() + "$";
            PlayerMoney.Instance.moneyShopText.text = PlayerMoney.Instance.money.ToString() + "$";
            Background1.SetActive(false);
            Background2.SetActive(false);
            Background3.SetActive(true);
            currentBackground = 3;
            PlayerPrefs.SetInt("Background", 3);
            isPurchasedBackground3 = true;
            PlayerPrefs.SetInt("isPurchasedBackground3", isPurchasedBackground3 ? 1 : 0);
            if (PlayerMoney.Instance.money < 20)
            {
                if (isPurchasedBackground3 == false)
                {
                    BackgroundButton3.interactable = false;
                }
            }
        }
        if (isPurchasedBackground3 == true && currentBackground == 3)
        {
            BackgroundText2.SetActive(false);
            BackgroundButton3.interactable = true;
        }
    }

    public void Background2Update()
    {
        if (isPurchasedBackground2 == false && PlayerMoney.Instance.money < 20)
        {
            BackgroundButton2.interactable = false;
        }
        else
        {
            BackgroundButton2.interactable = true;
        }
    }

    public void Background3Update()
    {
        if (isPurchasedBackground3 == false && PlayerMoney.Instance.money < 20)
        {
            BackgroundButton3.interactable = false;
        }
        else
        {
            BackgroundButton3.interactable = true;
        }
    }
}


