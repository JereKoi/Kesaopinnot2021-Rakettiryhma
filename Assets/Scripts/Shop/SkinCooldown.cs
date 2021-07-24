using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinCooldown : MonoBehaviour
{
    public Button SkinButton1;
    public Button SkinButton2;
    public Button SkinButton3;
    public Button SkinButton4;
    public Button SkinButton5;
    public Button SkinButton6;
    [SerializeField]
    public GameObject SkinText1;
    [SerializeField]
    public GameObject SkinText2;
    [SerializeField]
    public GameObject SkinText3;
    [SerializeField]
    public GameObject SkinText5;
    [SerializeField]
    public GameObject SkinText6;

    public static SkinCooldown Instance;

    public bool isPurchasedSkin1;
    public bool isPurchasedSkin2;
    public bool isPurchasedSkin3;
    public bool isPurchasedSkin4;
    public bool isPurchasedSkin5;
    public bool isPurchasedSkin6;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        
    }

    private void Update()
    {
        ////if (PlayerMoney.Instance.money < 5 && isPurchasedSkin1 == false)
        ////{
        ////    SkinButton1.interactable = false;
        ////}
        ////else if (isPurchasedSkin1 == true)
        ////{
        ////    SkinButton1.interactable = true;
        ////}
        ////else
        ////{
        ////    SkinButton1.interactable = true;
        ////}
    }
}
