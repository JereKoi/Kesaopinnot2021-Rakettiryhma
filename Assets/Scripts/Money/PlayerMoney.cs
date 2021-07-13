using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public int money = 0;
    public Text moneyText;
    public Text moneyShopText;

    public static PlayerMoney Instance;


    //Savettaa cosmetics mitä pelaaja pitää tällähetkellä päällä. Tee bool joka savetetaan playerprefssillä, ja kun pelaaja käynnistää seuraavan kerran pelin,
    //Start methodiin checkataan booleanit läpi ja jos joku niistä matchaa savetettuun booleaniin, laitetaan se GameObject.SetActive(true); ksi :)


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
        Debug.Log("added money");
        moneyText.text = money.ToString() + "$";
        moneyShopText.text = this.money.ToString() + "$";
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
