using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    private int money = 0;
    public Text moneyText;

    public static PlayerMoney Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
            moneyText.text = this.money.ToString() + "$";
        }
        else
        {
            money = 0;
        }
    }

    public void addMoney (int moneyToAdd)
    {
        money += moneyToAdd;
        Debug.Log("added money");
        moneyText.text = money.ToString() + "$";
        PlayerPrefs.SetInt("money", money);
    }

    public void minusMoney(int moneyToMinus)
    {
        if (money - moneyToMinus < 0)
        {
            Debug.Log("Ei voi ostaa, ei tarpeeksi rahaa");
            return;            
        }
        else
        {
            money -= moneyToMinus;
        }
    }
}
