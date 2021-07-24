using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightLiftScript : MonoBehaviour
{
    [SerializeField]
    Progressbox progressBox;
    [SerializeField]
    GameObject floatingMoneyText;

    public GameObject Hahmo;
    public AdsManager ads;
    public GameObject stamina0banner;
    public Canvas canvas;
    public GameObject staminaArrow;


    private bool idle = true;
    private bool nosto0;
    private bool nosto1;
    private bool nosto2;
    private bool nosto3;
    private bool nosto4;
    private bool nosto5;
    private bool nosto6;
    private bool nosto7;
    private bool nosto8;
    private bool nosto9;
    private bool nosto10;
    private bool nosto11;
    private bool nosto12;
    private bool nosto13;

    private int clickCounter = 0;
    public int currentSkin;
    private float inputTimer;

    private Animator anim;
    private SpriteRenderer rend;

    public static WeightLiftScript instance;

    private void Start()
    {
        instance = this;

        if (PlayerPrefs.HasKey("isPurchasedSkin1"))
        {
            SkinCooldown.Instance.isPurchasedSkin1 = PlayerPrefs.GetInt("isPurchasedSkin1") != 0;
            if (SkinCooldown.Instance.isPurchasedSkin1 == true)
            {
                SkinCooldown.Instance.SkinButton1.interactable = true;
                SkinCooldown.Instance.SkinText1.SetActive(false);
                //ColorChangeToOrange();
            }
        }
        if (PlayerPrefs.HasKey("isPurchasedSkin2"))
        {
            SkinCooldown.Instance.isPurchasedSkin2 = PlayerPrefs.GetInt("isPurchasedSkin2") != 0;
            if (SkinCooldown.Instance.isPurchasedSkin2 == true)
            {
                SkinCooldown.Instance.SkinButton2.interactable = true;
                SkinCooldown.Instance.SkinText2.SetActive(false);
                //ColorChangeToBlue();
            }
        }
        if (PlayerPrefs.HasKey("isPurchasedSkin3"))
        {
            SkinCooldown.Instance.isPurchasedSkin3 = PlayerPrefs.GetInt("isPurchasedSkin3") != 0;
            if (SkinCooldown.Instance.isPurchasedSkin3 == true)
            {
                SkinCooldown.Instance.SkinButton3.interactable = true;
                SkinCooldown.Instance.SkinText3.SetActive(false);
                //ColorChangeToPink();
            }
        }
        if (currentSkin == 4)
        {
            ColorChangeToWhite();
        }
        if (PlayerPrefs.HasKey("isPurchasedSkin5"))
        {
            SkinCooldown.Instance.isPurchasedSkin5 = PlayerPrefs.GetInt("isPurchasedSkin5") != 0;
            if (SkinCooldown.Instance.isPurchasedSkin5 == true)
            {
                SkinCooldown.Instance.SkinButton5.interactable = true;
                SkinCooldown.Instance.SkinText5.SetActive(false);
                //ColorChangeToGreen();
            }
        }
        if (PlayerPrefs.HasKey("isPurchasedSkin6"))
        {
            SkinCooldown.Instance.isPurchasedSkin6 = PlayerPrefs.GetInt("isPurchasedSkin6") != 0;
            if (SkinCooldown.Instance.isPurchasedSkin6 == true)
            {
                SkinCooldown.Instance.SkinButton6.interactable = true;
                SkinCooldown.Instance.SkinText6.SetActive(false);
                //ColorChangeToRed();
            }
        }        

        if (progressBox.hahmoLVL1 == true && progressBox.hahmoLVL2 == false)
        {
            progressBox.hahmoLVL1.GetComponent<SpriteRenderer>();
        }
        if (progressBox.hahmoLVL2 == true && progressBox.hahmoLVL1 == false)
        {
            progressBox.hahmoLVL2.GetComponent<SpriteRenderer>();
        }
        anim = GetComponent<Animator>();
        inputTimer = 0;
        ads.ShowBanner();        
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("CSkin") && progressBox.hahmoLVL1 == true || progressBox.hahmoLVL2 == true)
        {
            currentSkin = PlayerPrefs.GetInt("CSkin");
            if (currentSkin == 1)
            {
                ColorChangeToOrange();
            }
            else if (currentSkin == 2)
            {
                ColorChangeToBlue();
            }
            else if (currentSkin == 3)
            {
                ColorChangeToPink();
            }
            else if (currentSkin == 4)
            {
                ColorChangeToWhite();
            }
            else if (currentSkin == 5)
            {
                ColorChangeToGreen();
            }
            else if (currentSkin == 6)
            {
                ColorChangeToRed();
            }
        }
        else
        {
            return;
        }
    }

    private void Update()
    {
        inputTimer += Time.deltaTime;
        CheckInput();
        UpdateAnimations();
        ColorChangeOrangeUpdate();
        ColorChangeBlueUpdate();
        ColorChangeToPinkUpdate();
        ColorChangeToGreenUpdate();
        ColorChangeToRedUpdate();
    }

    //tassa vaihdetaan blobejen vareja kaupassa.
    public void ColorChangeToOrange()
    {
        if (progressBox.hahmoLVL1.activeSelf == false && progressBox.level < 3 || progressBox.hahmoLVL1.activeSelf == true)
        {
            rend = progressBox.hahmoLVL1.GetComponent<SpriteRenderer>();
        }
        else if (progressBox.hahmoLVL2.activeSelf == false && progressBox.level >= 3 || progressBox.hahmoLVL2.activeSelf == true)
        {
            rend = progressBox.hahmoLVL2.GetComponent<SpriteRenderer>();
        }

        rend.color = new Color32(255, 245, 71, 255);
        currentSkin = 1;
        PlayerPrefs.SetInt("CSkin", 1);

        if (SkinCooldown.Instance.isPurchasedSkin1 == false && PlayerMoney.Instance.money >= 5)
        {
            PlayerMoney.Instance.minusMoney(5);
            SkinCooldown.Instance.SkinText1.SetActive(false);
            PlayerMoney.Instance.moneyText.text = PlayerMoney.Instance.money.ToString() + "$";
            PlayerMoney.Instance.moneyShopText.text = PlayerMoney.Instance.money.ToString() + "$";
            rend.color = new Color32(255, 245, 71, 255);
            currentSkin = 1;
            PlayerPrefs.SetInt("CSkin", 1);
            SkinCooldown.Instance.isPurchasedSkin1 = true;
            PlayerPrefs.SetInt("isPurchasedSkin1", SkinCooldown.Instance.isPurchasedSkin1 ? 1 : 0);
            if (PlayerMoney.Instance.money < 5)
            {
                if (SkinCooldown.Instance.isPurchasedSkin2 == false)
                {
                    SkinCooldown.Instance.SkinButton2.interactable = false;
                }
                if (SkinCooldown.Instance.isPurchasedSkin3 == false)
                {
                    SkinCooldown.Instance.SkinButton3.interactable = false;
                }
                if (SkinCooldown.Instance.isPurchasedSkin5 == false)
                {
                    SkinCooldown.Instance.SkinButton5.interactable = false;
                }
                if (SkinCooldown.Instance.isPurchasedSkin6 == false)
                {
                    SkinCooldown.Instance.SkinButton6.interactable = false;
                }
            }
        }
        if (SkinCooldown.Instance.isPurchasedSkin1 == true)
        {
            SkinCooldown.Instance.SkinText1.SetActive(false);
            SkinCooldown.Instance.SkinButton1.interactable = true;
        }
    }

    public void ColorChangeOrangeUpdate()
    {
        if (SkinCooldown.Instance.isPurchasedSkin1 == false && PlayerMoney.Instance.money < 5)
        {
            SkinCooldown.Instance.SkinButton1.interactable = false;
        }
        else
        {
            SkinCooldown.Instance.SkinButton1.interactable = true;
        }
    }

    public void ColorChangeToBlue()
    {
        if (progressBox.hahmoLVL1.activeSelf == false && progressBox.level < 3 || progressBox.hahmoLVL1.activeSelf == true)
        {
            rend = progressBox.hahmoLVL1.GetComponent<SpriteRenderer>();
        }
        else if (progressBox.hahmoLVL2.activeSelf == false && progressBox.level >= 3 || progressBox.hahmoLVL2.activeSelf == true)
        {
            rend = progressBox.hahmoLVL2.GetComponent<SpriteRenderer>();
        }

        rend.color = new Color32(124, 252, 255, 255);
        currentSkin = 2;
        PlayerPrefs.SetInt("CSkin", 2);

        if (SkinCooldown.Instance.isPurchasedSkin2 == false && PlayerMoney.Instance.money >= 5)
        {
            PlayerMoney.Instance.minusMoney(5);
            SkinCooldown.Instance.SkinText2.SetActive(false);
            PlayerMoney.Instance.moneyText.text = PlayerMoney.Instance.money.ToString() + "$";
            PlayerMoney.Instance.moneyShopText.text = PlayerMoney.Instance.money.ToString() + "$";
            rend.color = new Color32(124, 252, 255, 255);
            currentSkin = 2;
            PlayerPrefs.SetInt("CSkin", 2);
            SkinCooldown.Instance.isPurchasedSkin2 = true;
            PlayerPrefs.SetInt("isPurchasedSkin2", SkinCooldown.Instance.isPurchasedSkin2 ? 1 : 0);
            if (PlayerMoney.Instance.money < 5)
            {
                if (SkinCooldown.Instance.isPurchasedSkin1 == false)
                {
                    SkinCooldown.Instance.SkinButton1.interactable = false;
                }
                if (SkinCooldown.Instance.isPurchasedSkin3 == false)
                {
                    SkinCooldown.Instance.SkinButton3.interactable = false;
                }
                if (SkinCooldown.Instance.isPurchasedSkin5 == false)
                {
                    SkinCooldown.Instance.SkinButton5.interactable = false;
                }
                if (SkinCooldown.Instance.isPurchasedSkin6 == false)
                {
                    SkinCooldown.Instance.SkinButton6.interactable = false;
                }
            }
        }
        if (SkinCooldown.Instance.isPurchasedSkin2 == true)
        {
            SkinCooldown.Instance.SkinText2.SetActive(false);
            SkinCooldown.Instance.SkinButton2.interactable = true;     
        }
    }

    public void ColorChangeBlueUpdate()
    {
        if (SkinCooldown.Instance.isPurchasedSkin2 == false && PlayerMoney.Instance.money < 5)
        {
            SkinCooldown.Instance.SkinButton2.interactable = false;
        }
        else
        {
            SkinCooldown.Instance.SkinButton2.interactable = true;
        }
    }

    public void ColorChangeToPink()
    {
        if (progressBox.hahmoLVL1.activeSelf == false && progressBox.level < 3 || progressBox.hahmoLVL1.activeSelf == true)
        {
            rend = progressBox.hahmoLVL1.GetComponent<SpriteRenderer>();
        }
        else if (progressBox.hahmoLVL2.activeSelf == false && progressBox.level >= 3 || progressBox.hahmoLVL2.activeSelf == true)
        {
            rend = progressBox.hahmoLVL2.GetComponent<SpriteRenderer>();
        }

        rend.color = new Color32(250, 172, 255, 255);
        currentSkin = 3;
        PlayerPrefs.SetInt("CSkin", 3);

        if (SkinCooldown.Instance.isPurchasedSkin3 == false && PlayerMoney.Instance.money >= 5)
        {
            PlayerMoney.Instance.minusMoney(5);
            SkinCooldown.Instance.SkinText3.SetActive(false);
            PlayerMoney.Instance.moneyText.text = PlayerMoney.Instance.money.ToString() + "$";
            PlayerMoney.Instance.moneyShopText.text = PlayerMoney.Instance.money.ToString() + "$";
            rend.color = new Color32(250, 172, 255, 255);
            currentSkin = 3;
            PlayerPrefs.SetInt("CSkin", 3);
            SkinCooldown.Instance.isPurchasedSkin3 = true;
            PlayerPrefs.SetInt("isPurchasedSkin3", SkinCooldown.Instance.isPurchasedSkin3 ? 1 : 0);
            if (PlayerMoney.Instance.money < 5)
            {
                if (SkinCooldown.Instance.isPurchasedSkin1 == false)
                {
                    SkinCooldown.Instance.SkinButton1.interactable = false;
                }
                if (SkinCooldown.Instance.isPurchasedSkin2 == false)
                {
                    SkinCooldown.Instance.SkinButton2.interactable = false;
                }
                if (SkinCooldown.Instance.isPurchasedSkin5 == false)
                {
                    SkinCooldown.Instance.SkinButton5.interactable = false;
                }
                if (SkinCooldown.Instance.isPurchasedSkin6 == false)
                {
                    SkinCooldown.Instance.SkinButton6.interactable = false;
                }
            }
        }
        if (SkinCooldown.Instance.isPurchasedSkin3 == true)
        {
            SkinCooldown.Instance.SkinText3.SetActive(false);
            SkinCooldown.Instance.SkinButton3.interactable = true;
        }
    }

    public void ColorChangeToPinkUpdate()
    {
        if (SkinCooldown.Instance.isPurchasedSkin3 == false && PlayerMoney.Instance.money < 5)
        {
            SkinCooldown.Instance.SkinButton3.interactable = false;
        }
        else
        {
            SkinCooldown.Instance.SkinButton3.interactable = true;
        }
    }

    public void ColorChangeToWhite()
    {
        if (progressBox.hahmoLVL1.activeSelf == false && progressBox.level < 3 || progressBox.hahmoLVL1.activeSelf == true)
        {
            rend = progressBox.hahmoLVL1.GetComponent<SpriteRenderer>();
        }
        else if (progressBox.hahmoLVL2.activeSelf == false && progressBox.level >= 3 || progressBox.hahmoLVL2.activeSelf == true)
        {
            rend = progressBox.hahmoLVL2.GetComponent<SpriteRenderer>();
        }
        rend.color = new Color32(255, 255, 255, 255);
        currentSkin = 4;
        PlayerPrefs.SetInt("CSkin", 4);
        SkinCooldown.Instance.isPurchasedSkin4 = true;
    }
    public void ColorChangeToGreen()
    {
        if (progressBox.hahmoLVL1.activeSelf == false && progressBox.level < 3 || progressBox.hahmoLVL1.activeSelf == true)
        {
            rend = progressBox.hahmoLVL1.GetComponent<SpriteRenderer>();
        }
        else if (progressBox.hahmoLVL2.activeSelf == false && progressBox.level >= 3 || progressBox.hahmoLVL2.activeSelf == true)
        {
            rend = progressBox.hahmoLVL2.GetComponent<SpriteRenderer>();
        }

        rend.color = new Color32(138, 255, 152, 255);
        currentSkin = 5;
        PlayerPrefs.SetInt("CSkin", 5);

        if (SkinCooldown.Instance.isPurchasedSkin5 == false && PlayerMoney.Instance.money >= 5)
        {
            PlayerMoney.Instance.minusMoney(5);
            SkinCooldown.Instance.SkinText5.SetActive(false);
            PlayerMoney.Instance.moneyText.text = PlayerMoney.Instance.money.ToString() + "$";
            PlayerMoney.Instance.moneyShopText.text = PlayerMoney.Instance.money.ToString() + "$";
            rend.color = new Color32(138, 255, 152, 255);
            currentSkin = 5;
            PlayerPrefs.SetInt("CSkin", 5);
            SkinCooldown.Instance.isPurchasedSkin5 = true;
            PlayerPrefs.SetInt("isPurchasedSkin5", SkinCooldown.Instance.isPurchasedSkin5 ? 1 : 0);
            if (PlayerMoney.Instance.money < 5)
            {
                if (SkinCooldown.Instance.isPurchasedSkin1 == false)
                {
                    SkinCooldown.Instance.SkinButton1.interactable = false;
                }
                if (SkinCooldown.Instance.isPurchasedSkin2 == false)
                {
                    SkinCooldown.Instance.SkinButton2.interactable = false;
                }
                if (SkinCooldown.Instance.isPurchasedSkin3 == false)
                {
                    SkinCooldown.Instance.SkinButton3.interactable = false;
                }
                if (SkinCooldown.Instance.isPurchasedSkin6 == false)
                {
                    SkinCooldown.Instance.SkinButton6.interactable = false;
                }
            }
        }
        if (SkinCooldown.Instance.isPurchasedSkin5 == true)
        {
            SkinCooldown.Instance.SkinText5.SetActive(false);
            SkinCooldown.Instance.SkinButton5.interactable = true;
        }
    }

    public void ColorChangeToGreenUpdate()
    {
        if (SkinCooldown.Instance.isPurchasedSkin5 == false && PlayerMoney.Instance.money < 5)
        {
            SkinCooldown.Instance.SkinButton5.interactable = false;
        }
        else
        {
            SkinCooldown.Instance.SkinButton5.interactable = true;
        }
    }

    public void ColorChangeToRed()
    {
        if (progressBox.hahmoLVL1.activeSelf == false && progressBox.level < 3 || progressBox.hahmoLVL1.activeSelf == true)
        {
            rend = progressBox.hahmoLVL1.GetComponent<SpriteRenderer>();
        }
        else if (progressBox.hahmoLVL2.activeSelf == false && progressBox.level >= 3 || progressBox.hahmoLVL2.activeSelf == true)
        {
            rend = progressBox.hahmoLVL2.GetComponent<SpriteRenderer>();
        }
        rend.color = new Color32(255, 161, 129, 255);
        currentSkin = 6;
        PlayerPrefs.SetInt("CSkin", 6);

        if (SkinCooldown.Instance.isPurchasedSkin6 == false && PlayerMoney.Instance.money >= 5)
        {
            PlayerMoney.Instance.minusMoney(5);
            SkinCooldown.Instance.SkinText6.SetActive(false);
            PlayerMoney.Instance.moneyText.text = PlayerMoney.Instance.money.ToString() + "$";
            PlayerMoney.Instance.moneyShopText.text = PlayerMoney.Instance.money.ToString() + "$";
            rend.color = new Color32(255, 161, 129, 255);
            currentSkin = 6;
            PlayerPrefs.SetInt("CSkin", 6);
            SkinCooldown.Instance.isPurchasedSkin6 = true;
            PlayerPrefs.SetInt("isPurchasedSkin6", SkinCooldown.Instance.isPurchasedSkin6 ? 1 : 0);
            if (PlayerMoney.Instance.money < 5)
            {
                if (SkinCooldown.Instance.isPurchasedSkin1 == false)
                {
                    SkinCooldown.Instance.SkinButton1.interactable = false;
                }
                if (SkinCooldown.Instance.isPurchasedSkin2 == false)
                {
                    SkinCooldown.Instance.SkinButton2.interactable = false;
                }
                if (SkinCooldown.Instance.isPurchasedSkin3 == false)
                {
                    SkinCooldown.Instance.SkinButton3.interactable = false;
                }
                if (SkinCooldown.Instance.isPurchasedSkin5 == false)
                {
                    SkinCooldown.Instance.SkinButton5.interactable = false;
                }
            }
        }
        if (SkinCooldown.Instance.isPurchasedSkin6 == true && currentSkin == 6)
        {
            SkinCooldown.Instance.SkinText6.SetActive(false);
            SkinCooldown.Instance.SkinButton6.interactable = true;
        }
    }

    public void ColorChangeToRedUpdate()
    {
        if (SkinCooldown.Instance.isPurchasedSkin6 == false && PlayerMoney.Instance.money < 5)
        {
            SkinCooldown.Instance.SkinButton6.interactable = false;
        }
        else
        {
            SkinCooldown.Instance.SkinButton6.interactable = true;
        }
    }

    private void UpdateAnimations()
    {
        anim.SetBool("idle", idle);
        anim.SetBool("nosto0", nosto0);
        anim.SetBool("nosto1", nosto1);
        anim.SetBool("nosto2", nosto2);
        anim.SetBool("nosto3", nosto3);
        anim.SetBool("nosto4", nosto4);
        anim.SetBool("nosto5", nosto5);
        anim.SetBool("nosto6", nosto6);
        anim.SetBool("nosto7", nosto7);
        anim.SetBool("nosto8", nosto8);
        anim.SetBool("nosto9", nosto9);
        anim.SetBool("nosto10", nosto10);
        anim.SetBool("nosto11", nosto11);
        anim.SetBool("nosto12", nosto12);
        anim.SetBool("nosto13", nosto13);
    }

    private void CheckInput()
    {
        if (Input.GetButtonDown("Nosto"))
        {
            inputTimer = 0;
            NostoFunction();
            clickCounter++;
            if (clickCounter >= 18)
            {
                clickCounter = 0;
                if (progressBox.level < 2)
                {
                    progressBox.UpdateProgress(0.2f);
                }
                else
                {
                    progressBox.UpdateProgress(0.1f);
                }
                StaminaIndicator.instance.UseStamina(5);
                GameObject prefab = Instantiate(floatingMoneyText, transform.position, Quaternion.identity) as GameObject;
                prefab.transform.SetParent(canvas.transform, false);
                Destroy(prefab, 1f);
                PlayerMoney.Instance.addMoney(1);
                RateManager.Instance.ClickPlay();
                nosto13 = false;
                idle = true;
            }
            
        }
        if (StaminaIndicator.instance.currentStamina < 5)
        {
            idle = true;
            stamina0banner.SetActive(true);
            staminaArrow.SetActive(true);
        }

        if (StaminaIndicator.instance.currentStamina > 5)
        {
            stamina0banner.SetActive(false);
            staminaArrow.SetActive(false);
        }

        if (inputTimer >= 0.2f)
        {
            inputTimer = 0;
            if (clickCounter <= 0)
            {
                idle = true;
                nosto0 = false;
            }
            else if (clickCounter <= 2)
            {
                idle = false;
                nosto0 = true;
                nosto1 = false;
                clickCounter--;
            }
            else if (clickCounter <= 3)
            {
                idle = false;
                nosto0 = false;
                nosto1 = true;
                nosto2 = false;
                clickCounter--;
            }
            else if (clickCounter <= 4)
            {
                idle = false;
                nosto1 = false;
                nosto2 = true;
                nosto3 = false;
                clickCounter--;
            }
            else if (clickCounter <= 5)
            {
                idle = false;
                nosto2 = false;
                nosto3 = true;
                nosto4 = false;
                clickCounter--;
            }
            else if (clickCounter <= 6)
            {
                idle = false;
                nosto3 = false;
                nosto4 = true;
                nosto5 = false;
                clickCounter--;
            }
            else if (clickCounter <= 7)
            {
                idle = false;
                nosto4 = false;
                nosto5 = true;
                nosto6 = false;
                clickCounter--;
            }
            else if (clickCounter <= 8)
            {
                idle = false;
                nosto5 = false;
                nosto6 = true;
                nosto7 = false;
                clickCounter--;
            }
            else if (clickCounter <= 9)
            {
                idle = false;
                nosto6 = false;
                nosto7 = true;
                nosto8 = false;
                clickCounter--;
            }
            else if (clickCounter <= 10)
            {
                idle = false;
                nosto7 = false;
                nosto8 = true;
                nosto9 = false;
                clickCounter--;
            }
            else if (clickCounter <= 11)
            {
                idle = false;
                nosto8 = false;
                nosto9 = true;
                nosto10 = false;
                clickCounter--;
            }
            else if (clickCounter <= 12)
            {
                idle = false;
                nosto9 = false;
                nosto10 = true;
                nosto11 = false;
                clickCounter--;
            }
            else if (clickCounter <= 13)
            {
                idle = false;
                nosto10 = false;
                nosto11 = true;
                nosto12 = false;
                clickCounter--;
            }
            else if (clickCounter <= 14)
            {
                idle = false;
                nosto11 = false;
                nosto12 = true;
                nosto13 = false;
                clickCounter--;
            }
        }
    }
    private void NostoFunction()
    {
        if (clickCounter <= 1)
        {
            idle = false;
            nosto0 = true;
        }
        else if(clickCounter <= 2)
        {
            idle = false;
            nosto0 = false;
            nosto1 = true;
        }
        else if(clickCounter <= 3)
        {
            idle = false;
            nosto0 = false;
            nosto1 = false;
            nosto2 = true;
        }
        else if(clickCounter <= 4)
        {
            idle = false;
            nosto1 = false;
            nosto2 = false;
            nosto3 = true;
        }
        else if(clickCounter <= 5)
        {
            idle = false;
            nosto2 = false;
            nosto3 = false;
            nosto4 = true;
        }
        else if (clickCounter <= 6)
        {
            idle = false;
            nosto3 = false;
            nosto4 = false;
            nosto5 = true;
        }
        else if (clickCounter <= 7)
        {
            idle = false;
            nosto4 = false;
            nosto5 = false;
            nosto6 = true;
        }
        else if (clickCounter <= 8)
        {
            idle = false;
            nosto5 = false;
            nosto6 = false;
            nosto7 = true;
        }
        else if (clickCounter <= 9)
        {
            idle = false;
            nosto6 = false;
            nosto7 = false;
            nosto8 = true;
        }
        else if (clickCounter <= 10)
        {
            idle = false;
            nosto7 = false;
            nosto8 = false;
            nosto9 = true;
        }
        else if (clickCounter <= 11)
        {
            idle = false;
            nosto8 = false;
            nosto9 = false;
            nosto10 = true;
        }
        else if (clickCounter <= 12)
        {
            idle = false;
            nosto9 = false;
            nosto10 = false;
            nosto11 = true;
        }
        else if (clickCounter <= 13)
        {
            idle = false;
            nosto10 = false;
            nosto11 = false;
            nosto12 = true;
        }
        else if (clickCounter <= 14)
        {
            idle = false;
            nosto11 = false;
            nosto12 = false;
            nosto13 = true;
        }
    }
}
