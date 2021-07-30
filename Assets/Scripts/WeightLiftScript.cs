using UnityEngine;
using UnityEngine.UI;

public class WeightLiftScript : MonoBehaviour
{
    [SerializeField]
    Progressbox progressBox;
    [SerializeField]
    GameObject floatingMoneyText;

    public AdsManager ads;
    public GameObject stamina0banner;
    public Canvas canvas;
    public GameObject staminaArrow;
    public Button ShopButton;
    public Button ShopExitButton;

    //Cosmetics
    public GameObject FurrySunglassesT1;
    public GameObject KruunuT1;
    public GameObject LippisT1;
    public GameObject SunglassesT1;
    public GameObject TreeniMyssyT1;
    public GameObject ViiksetT1;
    public GameObject FurrySunglassesT2;
    public GameObject KruunuT2;
    public GameObject LippisT2;
    public GameObject SunglassesT2;
    public GameObject TreeniMyssyT2;
    public GameObject ViiksetT2;
    public GameObject FurrySunglassesT3;
    public GameObject KruunuT3;
    public GameObject LippisT3;
    public GameObject TreeniMyssyT3;
    public GameObject ViiksetT3;
    public GameObject SunglassesT3;

    //ShopText
    public GameObject FurrySunglassesShopText;
    public GameObject KruunuShopText;
    public GameObject SunglassesText;
    public GameObject TreeniMyssyText;
    public GameObject ViiksetText;
    public GameObject LippisShopText;

    //Cosmetics bools
    public bool isPurchasedFurrySunglasses;
    public bool isPurchasedKruunu;
    public bool isPurchasedLippis;
    public bool isPurchasedSunglasses;
    public bool isPurchasedTreeniMyssy;
    public bool isPurchasedViikset;
    //public int currentCosmetic;

    //Cosmetics buttons
    public Button FurrySunglassesButton;
    public Button KruunuButton;
    public Button SunglassesButton;
    public Button TreeniMyssyButton;
    public Button ViiksetButton;
    public Button LippisButton;

    //Nosto funktion bools
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
    //Nämä alla olevat boolit lisätty Tier3. Nostofunktion jatkoksi on tehty pieni pätkä koodia
    private bool nosto14;
    private bool nosto15;
    private bool nosto16;

    private int clickCounter = 0;
    //public int currentSkin;
    private float inputTimer;

    private Animator anim;
    private SpriteRenderer rend;

    public static WeightLiftScript instance;


    //Start metodissa käydään läpi tallennetut cosmeticsit läpi
    private void Start()
    {
        instance = this;

        if (PlayerPrefs.HasKey("isPurchasedFurrySunglasses"))
        {
            isPurchasedFurrySunglasses = PlayerPrefs.GetInt("isPurchasedFurrySunglasses") != 0;
            if (isPurchasedFurrySunglasses == true)
            {
                FurrySunglassesButton.interactable = true;
                FurrySunglassesShopText.SetActive(false);
                CheckOnStartIfPlayerHasFurrySunglassesCosmeticOn();
            }
        }

        if (PlayerPrefs.HasKey("isPurchasedSkin1"))
        {
            SkinCooldown.Instance.isPurchasedSkin1 = PlayerPrefs.GetInt("isPurchasedSkin1") != 0;
            if (SkinCooldown.Instance.isPurchasedSkin1 == true)
            {
                SkinCooldown.Instance.SkinButton1.interactable = true;
                SkinCooldown.Instance.SkinText1.SetActive(false);
            }
        }
        if (PlayerPrefs.HasKey("isPurchasedSkin2"))
        {
            SkinCooldown.Instance.isPurchasedSkin2 = PlayerPrefs.GetInt("isPurchasedSkin2") != 0;
            if (SkinCooldown.Instance.isPurchasedSkin2 == true)
            {
                SkinCooldown.Instance.SkinButton2.interactable = true;
                SkinCooldown.Instance.SkinText2.SetActive(false);
            }
        }
        if (PlayerPrefs.HasKey("isPurchasedSkin3"))
        {
            SkinCooldown.Instance.isPurchasedSkin3 = PlayerPrefs.GetInt("isPurchasedSkin3") != 0;
            if (SkinCooldown.Instance.isPurchasedSkin3 == true)
            {
                SkinCooldown.Instance.SkinButton3.interactable = true;
                SkinCooldown.Instance.SkinText3.SetActive(false);
            }
        }
        if (CurrentSkinCurrentCosmeticHolder.instance.currentSkin == 4)
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
            }
        }
        if (PlayerPrefs.HasKey("isPurchasedSkin6"))
        {
            SkinCooldown.Instance.isPurchasedSkin6 = PlayerPrefs.GetInt("isPurchasedSkin6") != 0;
            if (SkinCooldown.Instance.isPurchasedSkin6 == true)
            {
                SkinCooldown.Instance.SkinButton6.interactable = true;
                SkinCooldown.Instance.SkinText6.SetActive(false);
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
        if (progressBox.hahmoLVL3 == true && progressBox.hahmoLVL1 == false && progressBox.hahmoLVL2 == false)
        {
            progressBox.hahmoLVL3.GetComponent<SpriteRenderer>();
        }
        anim = GetComponent<Animator>();
        inputTimer = 0;
        ads.ShowBanner();
    }

    //Awake metodissa käydään läpi blobfishin värit
    private void Awake()
    {
        if (PlayerPrefs.HasKey("CSkin") /*&& progressBox.hahmoLVL1 == true || progressBox.hahmoLVL2 == true*/)
        {
            CurrentSkinCurrentCosmeticHolder.instance.currentSkin = PlayerPrefs.GetInt("CSkin");
            if (CurrentSkinCurrentCosmeticHolder.instance.currentSkin == 1)
            {
                ColorChangeToOrange();
            }
            else if (CurrentSkinCurrentCosmeticHolder.instance.currentSkin == 2)
            {
                ColorChangeToBlue();
            }
            else if (CurrentSkinCurrentCosmeticHolder.instance.currentSkin == 3)
            {
                ColorChangeToPink();
            }
            else if (CurrentSkinCurrentCosmeticHolder.instance.currentSkin == 4)
            {
                ColorChangeToWhite();
            }
            else if (CurrentSkinCurrentCosmeticHolder.instance.currentSkin == 5)
            {
                ColorChangeToGreen();
            }
            else if (CurrentSkinCurrentCosmeticHolder.instance.currentSkin == 6)
            {
                ColorChangeToRed();
            }
            //TÄSSÄ KOHDASSA ALKAA COSMETICSIEN TARKISTUS
        }
        if (PlayerPrefs.HasKey("CurrentCosmetic"))
        {
            CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic = PlayerPrefs.GetInt("CurrentCosmetic");
            if (CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic == 1)
            {
                FurrySunglassesTest();
            }
            //if (CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic == 1 && CurrentSkinCurrentCosmeticHolder.instance.currentSkin == 3)
            //{
            //    FurrySunglassesTest();
            //    ColorChangeToPink();
            //}
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
        CosmeticUpdate();
    }

    //tassa vaihdetaan blobejen vareja kaupassa.
    public void ColorChangeToOrange()
    {
        if (progressBox.hahmoLVL1.activeSelf == false && progressBox.level < 5 && CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic != 1|| progressBox.hahmoLVL1.activeSelf == true)
        {
            rend = progressBox.hahmoLVL1.GetComponent<SpriteRenderer>();
            CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic = 0;
        }
        else if (progressBox.hahmoLVL2.activeSelf == false && progressBox.level >= 5 && CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic != 1 || progressBox.hahmoLVL2.activeSelf == true)
        {
            rend = progressBox.hahmoLVL2.GetComponent<SpriteRenderer>();
            CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic = 0;
        }
        else if (progressBox.hahmoLVL3.activeSelf == false && progressBox.level >= 10 && CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic != 1 || progressBox.hahmoLVL3.activeSelf == true)
        {
            rend = progressBox.hahmoLVL3.GetComponent<SpriteRenderer>();
            CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic = 0;
        }
        if (FurrySunglassesT3.activeSelf == false && CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic == 1)
        {
            rend = FurrySunglassesT3.GetComponent<SpriteRenderer>();
        }

        rend.color = new Color32(255, 245, 71, 255);
        CurrentSkinCurrentCosmeticHolder.instance.currentSkin = 1;
        PlayerPrefs.SetInt("CSkin", 1);

        if (SkinCooldown.Instance.isPurchasedSkin1 == false && PlayerMoney.Instance.money >= 10)
        {
            PlayerMoney.Instance.minusMoney(10);
            SkinCooldown.Instance.SkinText1.SetActive(false);
            PlayerMoney.Instance.moneyText.text = PlayerMoney.Instance.money.ToString() + "$";
            PlayerMoney.Instance.moneyShopText.text = PlayerMoney.Instance.money.ToString() + "$";
            rend.color = new Color32(255, 245, 71, 255);
            CurrentSkinCurrentCosmeticHolder.instance.currentSkin = 1;
            PlayerPrefs.SetInt("CSkin", 1);
            SkinCooldown.Instance.isPurchasedSkin1 = true;
            PlayerPrefs.SetInt("isPurchasedSkin1", SkinCooldown.Instance.isPurchasedSkin1 ? 1 : 0);
            if (PlayerMoney.Instance.money < 10)
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
            if (PlayerMoney.Instance.money < 20)
            {
                if (BackgroundSave.instance.isPurchasedBackground2 == false)
                {
                    BackgroundSave.instance.isPurchasedBackground2 = false;
                }
                if (BackgroundSave.instance.isPurchasedBackground3 == false)
                {
                    BackgroundSave.instance.isPurchasedBackground3 = false;
                }
            }
            if (PlayerMoney.Instance.money < 30)
            {
                if (isPurchasedFurrySunglasses == false)
                {
                    FurrySunglassesButton.interactable = false;
                }
                if (isPurchasedLippis == false)
                {
                    LippisButton.interactable = false;
                }
                if (isPurchasedSunglasses == false)
                {
                    SunglassesButton.interactable = false;
                }
                if (isPurchasedTreeniMyssy == false)
                {
                    TreeniMyssyButton.interactable = false;
                }
                if (isPurchasedViikset == false)
                {
                    ViiksetButton.interactable = false;
                }
            }
            if (PlayerMoney.Instance.money < 100)
            {
                if (isPurchasedKruunu == false)
                {
                    KruunuButton.interactable = false;
                }
            }
        }
        if (SkinCooldown.Instance.isPurchasedSkin1 == true)
        {
            SkinCooldown.Instance.SkinText1.SetActive(false);
            SkinCooldown.Instance.SkinButton1.interactable = true;
        }
    }

    //Tässä katsotaan Update metodissa että onko pelaajalla rahaa ostaa oranssi väri blobille
    public void ColorChangeOrangeUpdate()
    {
        if (SkinCooldown.Instance.isPurchasedSkin1 == false && PlayerMoney.Instance.money < 10)
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
        if (progressBox.hahmoLVL1.activeSelf == false && progressBox.level < 5 || progressBox.hahmoLVL1.activeSelf == true)
        {
            rend = progressBox.hahmoLVL1.GetComponent<SpriteRenderer>();
        }
        else if (progressBox.hahmoLVL2.activeSelf == false && progressBox.level >= 5 || progressBox.hahmoLVL2.activeSelf == true)
        {
            rend = progressBox.hahmoLVL2.GetComponent<SpriteRenderer>();
        }
        else if (progressBox.hahmoLVL3.activeSelf == false && progressBox.level >= 10 || progressBox.hahmoLVL3.activeSelf == true)
        {
            rend = progressBox.hahmoLVL3.GetComponent<SpriteRenderer>();
        }

        rend.color = new Color32(124, 252, 255, 255);
        CurrentSkinCurrentCosmeticHolder.instance.currentSkin = 2;
        PlayerPrefs.SetInt("CSkin", 2);

        if (SkinCooldown.Instance.isPurchasedSkin2 == false && PlayerMoney.Instance.money >= 10)
        {
            PlayerMoney.Instance.minusMoney(10);
            SkinCooldown.Instance.SkinText2.SetActive(false);
            PlayerMoney.Instance.moneyText.text = PlayerMoney.Instance.money.ToString() + "$";
            PlayerMoney.Instance.moneyShopText.text = PlayerMoney.Instance.money.ToString() + "$";
            rend.color = new Color32(124, 252, 255, 255);
            CurrentSkinCurrentCosmeticHolder.instance.currentSkin = 2;
            PlayerPrefs.SetInt("CSkin", 2);
            SkinCooldown.Instance.isPurchasedSkin2 = true;
            PlayerPrefs.SetInt("isPurchasedSkin2", SkinCooldown.Instance.isPurchasedSkin2 ? 1 : 0);
            if (PlayerMoney.Instance.money < 10)
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
            if (PlayerMoney.Instance.money < 30)
            {
                if (isPurchasedFurrySunglasses == false)
                {
                    FurrySunglassesButton.interactable = false;
                }
                if (isPurchasedLippis == false)
                {
                    LippisButton.interactable = false;
                }
                if (isPurchasedSunglasses == false)
                {
                    SunglassesButton.interactable = false;
                }
                if (isPurchasedTreeniMyssy == false)
                {
                    TreeniMyssyButton.interactable = false;
                }
                if (isPurchasedViikset == false)
                {
                    ViiksetButton.interactable = false;
                }
            }
            if (PlayerMoney.Instance.money < 100)
            {
                if (isPurchasedKruunu == false)
                {
                    KruunuButton.interactable = false;
                }
            }
            if (PlayerMoney.Instance.money < 20)
            {
                if (BackgroundSave.instance.isPurchasedBackground2 == false)
                {
                    BackgroundSave.instance.isPurchasedBackground2 = false;
                }
                if (BackgroundSave.instance.isPurchasedBackground3 == false)
                {
                    BackgroundSave.instance.isPurchasedBackground3 = false;
                }
            }
        }
        if (SkinCooldown.Instance.isPurchasedSkin2 == true)
        {
            SkinCooldown.Instance.SkinText2.SetActive(false);
            SkinCooldown.Instance.SkinButton2.interactable = true;
        }
    }

    //Tässä katsotaan Update metodissa että onko pelaajalla rahaa ostaa sininen väri blobille
    public void ColorChangeBlueUpdate()
    {
        if (SkinCooldown.Instance.isPurchasedSkin2 == false && PlayerMoney.Instance.money < 10)
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
        if (progressBox.hahmoLVL1.activeSelf == false && progressBox.level < 5 || progressBox.hahmoLVL1.activeSelf == true)
        {
            rend = progressBox.hahmoLVL1.GetComponent<SpriteRenderer>();
            CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic = 0;
        }
        else if (progressBox.hahmoLVL2.activeSelf == false && progressBox.level == 5 || progressBox.hahmoLVL2.activeSelf == true)
        {
            rend = progressBox.hahmoLVL2.GetComponent<SpriteRenderer>();
            CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic = 0;
        }
        else if (progressBox.hahmoLVL3.activeSelf == false && progressBox.level >= 10 && CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic != 1 || progressBox.hahmoLVL3.activeSelf == true)
        {
            rend = progressBox.hahmoLVL3.GetComponent<SpriteRenderer>();
            CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic = 0;
        }
        if (FurrySunglassesT3.activeSelf == false && CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic == 1)
        {
            rend = FurrySunglassesT3.GetComponent<SpriteRenderer>();
        }

        rend.color = new Color32(250, 172, 255, 255);
        CurrentSkinCurrentCosmeticHolder.instance.currentSkin = 3;
        PlayerPrefs.SetInt("CSkin", 3);

        if (SkinCooldown.Instance.isPurchasedSkin3 == false && PlayerMoney.Instance.money >= 10)
        {
            PlayerMoney.Instance.minusMoney(10);
            SkinCooldown.Instance.SkinText3.SetActive(false);
            PlayerMoney.Instance.moneyText.text = PlayerMoney.Instance.money.ToString() + "$";
            PlayerMoney.Instance.moneyShopText.text = PlayerMoney.Instance.money.ToString() + "$";
            rend.color = new Color32(250, 172, 255, 255);
            CurrentSkinCurrentCosmeticHolder.instance.currentSkin = 3;
            PlayerPrefs.SetInt("CSkin", 3);
            SkinCooldown.Instance.isPurchasedSkin3 = true;
            PlayerPrefs.SetInt("isPurchasedSkin3", SkinCooldown.Instance.isPurchasedSkin3 ? 1 : 0);
            if (PlayerMoney.Instance.money < 10)
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
            if (PlayerMoney.Instance.money < 30)
            {
                if (isPurchasedFurrySunglasses == false)
                {
                    FurrySunglassesButton.interactable = false;
                }
                if (isPurchasedLippis == false)
                {
                    LippisButton.interactable = false;
                }
                if (isPurchasedSunglasses == false)
                {
                    SunglassesButton.interactable = false;
                }
                if (isPurchasedTreeniMyssy == false)
                {
                    TreeniMyssyButton.interactable = false;
                }
                if (isPurchasedViikset == false)
                {
                    ViiksetButton.interactable = false;
                }
            }
            if (PlayerMoney.Instance.money < 100)
            {
                if (isPurchasedKruunu == false)
                {
                    KruunuButton.interactable = false;
                }
            }
            if (PlayerMoney.Instance.money < 20)
            {
                if (BackgroundSave.instance.isPurchasedBackground2 == false)
                {
                    BackgroundSave.instance.isPurchasedBackground2 = false;
                }
                if (BackgroundSave.instance.isPurchasedBackground3 == false)
                {
                    BackgroundSave.instance.isPurchasedBackground3 = false;
                }
            }
        }
        if (SkinCooldown.Instance.isPurchasedSkin3 == true)
        {
            SkinCooldown.Instance.SkinText3.SetActive(false);
            SkinCooldown.Instance.SkinButton3.interactable = true;
        }
    }

    //Tässä katsotaan Update metodissa että onko pelaajalla rahaa ostaa pinkki väri blobille
    public void ColorChangeToPinkUpdate()
    {
        if (SkinCooldown.Instance.isPurchasedSkin3 == false && PlayerMoney.Instance.money < 10)
        {
            SkinCooldown.Instance.SkinButton3.interactable = false;
        }
        else
        {
            SkinCooldown.Instance.SkinButton3.interactable = true;
        }
    }

    //Tässä katsotaan onko pelaajalla pelkästään valkoinen skini päällä
    public void ColorChangeToWhite()
    {
        CurrentSkinCurrentCosmeticHolder.instance.currentSkin = 4;
        PlayerPrefs.SetInt("CSkin", 4);

        if (progressBox.hahmoLVL1.activeSelf == false && progressBox.level < 5 || progressBox.hahmoLVL1.activeSelf == true)
        {
            rend = progressBox.hahmoLVL1.GetComponent<SpriteRenderer>();
        }
        else if (progressBox.hahmoLVL2.activeSelf == false && progressBox.level >= 5 || progressBox.hahmoLVL2.activeSelf == true)
        {
            rend = progressBox.hahmoLVL2.GetComponent<SpriteRenderer>();
        }
        else if (progressBox.hahmoLVL3.activeSelf == false && progressBox.level >= 10 || progressBox.hahmoLVL3.activeSelf == true)
        {
            rend = progressBox.hahmoLVL3.GetComponent<SpriteRenderer>();
        }
        if (CurrentSkinCurrentCosmeticHolder.instance.currentSkin == 4 && CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic == 1)
        {
            if (progressBox.level < 5)
            {
                rend = FurrySunglassesT1.GetComponent<SpriteRenderer>();
                rend.color = new Color32(255, 255, 255, 255);
            }
            if (progressBox.level > 5 && progressBox.level < 10)
            {
                rend = FurrySunglassesT2.GetComponent<SpriteRenderer>();
                rend.color = new Color32(255, 255, 255, 255);
            }
            if (progressBox.level >= 10)
            {
                rend = FurrySunglassesT3.GetComponent<SpriteRenderer>();
                rend.color = new Color32(255, 255, 255, 255);
            }
        }
        rend.color = new Color32(255, 255, 255, 255);
        SkinCooldown.Instance.isPurchasedSkin4 = true;
    }
    public void ColorChangeToGreen()
    {
        if (progressBox.hahmoLVL1.activeSelf == false && progressBox.level < 5 || progressBox.hahmoLVL1.activeSelf == true)
        {
            rend = progressBox.hahmoLVL1.GetComponent<SpriteRenderer>();
        }
        else if (progressBox.hahmoLVL2.activeSelf == false && progressBox.level >= 5 || progressBox.hahmoLVL2.activeSelf == true)
        {
            rend = progressBox.hahmoLVL2.GetComponent<SpriteRenderer>();
        }
        else if (progressBox.hahmoLVL3.activeSelf == false && progressBox.level >= 10 || progressBox.hahmoLVL3.activeSelf == true)
        {
            rend = progressBox.hahmoLVL3.GetComponent<SpriteRenderer>();
        }

        rend.color = new Color32(138, 255, 152, 255);
        CurrentSkinCurrentCosmeticHolder.instance.currentSkin = 5;
        PlayerPrefs.SetInt("CSkin", 5);

        if (SkinCooldown.Instance.isPurchasedSkin5 == false && PlayerMoney.Instance.money >= 10)
        {
            PlayerMoney.Instance.minusMoney(10);
            SkinCooldown.Instance.SkinText5.SetActive(false);
            PlayerMoney.Instance.moneyText.text = PlayerMoney.Instance.money.ToString() + "$";
            PlayerMoney.Instance.moneyShopText.text = PlayerMoney.Instance.money.ToString() + "$";
            rend.color = new Color32(138, 255, 152, 255);
            CurrentSkinCurrentCosmeticHolder.instance.currentSkin = 5;
            PlayerPrefs.SetInt("CSkin", 5);
            SkinCooldown.Instance.isPurchasedSkin5 = true;
            PlayerPrefs.SetInt("isPurchasedSkin5", SkinCooldown.Instance.isPurchasedSkin5 ? 1 : 0);
            if (PlayerMoney.Instance.money < 10)
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
            if (PlayerMoney.Instance.money < 30)
            {
                if (isPurchasedFurrySunglasses == false)
                {
                    FurrySunglassesButton.interactable = false;
                }
                if (isPurchasedLippis == false)
                {
                    LippisButton.interactable = false;
                }
                if (isPurchasedSunglasses == false)
                {
                    SunglassesButton.interactable = false;
                }
                if (isPurchasedTreeniMyssy == false)
                {
                    TreeniMyssyButton.interactable = false;
                }
                if (isPurchasedViikset == false)
                {
                    ViiksetButton.interactable = false;
                }
            }
            if (PlayerMoney.Instance.money < 100)
            {
                if (isPurchasedKruunu == false)
                {
                    KruunuButton.interactable = false;
                }
            }
            if (PlayerMoney.Instance.money < 20)
            {
                if (BackgroundSave.instance.isPurchasedBackground2 == false)
                {
                    BackgroundSave.instance.isPurchasedBackground2 = false;
                }
                if (BackgroundSave.instance.isPurchasedBackground3 == false)
                {
                    BackgroundSave.instance.isPurchasedBackground3 = false;
                }
            }
        }
        if (SkinCooldown.Instance.isPurchasedSkin5 == true)
        {
            SkinCooldown.Instance.SkinText5.SetActive(false);
            SkinCooldown.Instance.SkinButton5.interactable = true;
        }
    }

    //Tässä katsotaan Update metodissa että onko pelaajalla rahaa ostaa vihreä väri blobille
    public void ColorChangeToGreenUpdate()
    {
        if (SkinCooldown.Instance.isPurchasedSkin5 == false && PlayerMoney.Instance.money < 10)
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
        if (progressBox.hahmoLVL1.activeSelf == false && progressBox.level < 5 || progressBox.hahmoLVL1.activeSelf == true)
        {
            rend = progressBox.hahmoLVL1.GetComponent<SpriteRenderer>();
        }
        else if (progressBox.hahmoLVL2.activeSelf == false && progressBox.level >= 5 || progressBox.hahmoLVL2.activeSelf == true)
        {
            rend = progressBox.hahmoLVL2.GetComponent<SpriteRenderer>();
        }
        else if (progressBox.hahmoLVL3.activeSelf == false && progressBox.level >= 10 || progressBox.hahmoLVL3.activeSelf == true)
        {
            rend = progressBox.hahmoLVL3.GetComponent<SpriteRenderer>();
        }
        rend.color = new Color32(255, 161, 129, 255);
        CurrentSkinCurrentCosmeticHolder.instance.currentSkin = 6;
        PlayerPrefs.SetInt("CSkin", 6);

        if (SkinCooldown.Instance.isPurchasedSkin6 == false && PlayerMoney.Instance.money >= 10)
        {
            PlayerMoney.Instance.minusMoney(10);
            SkinCooldown.Instance.SkinText6.SetActive(false);
            PlayerMoney.Instance.moneyText.text = PlayerMoney.Instance.money.ToString() + "$";
            PlayerMoney.Instance.moneyShopText.text = PlayerMoney.Instance.money.ToString() + "$";
            rend.color = new Color32(255, 161, 129, 255);
            CurrentSkinCurrentCosmeticHolder.instance.currentSkin = 6;
            PlayerPrefs.SetInt("CSkin", 6);
            SkinCooldown.Instance.isPurchasedSkin6 = true;
            PlayerPrefs.SetInt("isPurchasedSkin6", SkinCooldown.Instance.isPurchasedSkin6 ? 1 : 0);
            if (PlayerMoney.Instance.money < 10)
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
            if (PlayerMoney.Instance.money < 30)
            {
                if (isPurchasedFurrySunglasses == false)
                {
                    FurrySunglassesButton.interactable = false;
                }
                if (isPurchasedLippis == false)
                {
                    LippisButton.interactable = false;
                }
                if (isPurchasedSunglasses == false)
                {
                    SunglassesButton.interactable = false;
                }
                if (isPurchasedTreeniMyssy == false)
                {
                    TreeniMyssyButton.interactable = false;
                }
                if (isPurchasedViikset == false)
                {
                    ViiksetButton.interactable = false;
                }
            }
            if (PlayerMoney.Instance.money < 100)
            {
                if (isPurchasedKruunu == false)
                {
                    KruunuButton.interactable = false;
                }
            }
            if (PlayerMoney.Instance.money < 20)
            {
                if (BackgroundSave.instance.isPurchasedBackground2 == false)
                {
                    BackgroundSave.instance.isPurchasedBackground2 = false;
                }
                if (BackgroundSave.instance.isPurchasedBackground3 == false)
                {
                    BackgroundSave.instance.isPurchasedBackground3 = false;
                }
            }
        }
        if (SkinCooldown.Instance.isPurchasedSkin6 == true && CurrentSkinCurrentCosmeticHolder.instance.currentSkin == 6)
        {
            SkinCooldown.Instance.SkinText6.SetActive(false);
            SkinCooldown.Instance.SkinButton6.interactable = true;
        }
    }

    //Tässä katsotaan Update metodissa että onko pelaajalla rahaa ostaa punainen väri blobille
    public void ColorChangeToRedUpdate()
    {
        if (SkinCooldown.Instance.isPurchasedSkin6 == false && PlayerMoney.Instance.money < 10)
        {
            SkinCooldown.Instance.SkinButton6.interactable = false;
        }
        else
        {
            SkinCooldown.Instance.SkinButton6.interactable = true;
        }
    }

    //Tässä katsotaan Start metodissa onko pelaajalla päällään cosmetics
    public void CheckOnStartIfPlayerHasFurrySunglassesCosmeticOn()
    {
        if (CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic == 1)
        {
            if (progressBox.level < 5)
            {
                FurrySunglassesT1.SetActive(true);
                FurrySunglassesT2.SetActive(false);
                FurrySunglassesT3.SetActive(false);
                progressBox.hahmoLVL1.SetActive(false);
            }
            else if (progressBox.level < 10)
            {
                FurrySunglassesT1.SetActive(false);
                FurrySunglassesT2.SetActive(true);
                FurrySunglassesT3.SetActive(false);
                progressBox.hahmoLVL2.SetActive(false);
            }
            else if (progressBox.level >= 10)
            {
                FurrySunglassesT1.SetActive(false);
                FurrySunglassesT2.SetActive(false);
                FurrySunglassesT3.SetActive(true);
                progressBox.hahmoLVL3.SetActive(false);
            }
        }
        if (CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic != 1)
        {
            FurrySunglassesT1.SetActive(false);
            FurrySunglassesT2.SetActive(false);
            FurrySunglassesT3.SetActive(false);
        }
    }

    //FurrySunglasses cosmetic metodi
    public void FurrySunglassesCosmetic()
    {
        CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic = 1;
        PlayerPrefs.SetInt("CurrentCosmetic", 1);

        if (isPurchasedFurrySunglasses == true && CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic == 1)
        {
            if (progressBox.level < 5)
            {
                FurrySunglassesT1.SetActive(true);
                progressBox.hahmoLVL1.SetActive(false);
                progressBox.hahmoLVL2.SetActive(false);
                progressBox.hahmoLVL3.SetActive(false);
            }
            else if (progressBox.level >= 5 && progressBox.level < 10)
            {
                FurrySunglassesT2.SetActive(true);
                progressBox.hahmoLVL1.SetActive(false);
                progressBox.hahmoLVL2.SetActive(false);
                progressBox.hahmoLVL3.SetActive(false);
            }
            else if (progressBox.level >= 10)
            {
                FurrySunglassesT3.SetActive(true);
                progressBox.hahmoLVL1.SetActive(false);
                progressBox.hahmoLVL2.SetActive(false);
                progressBox.hahmoLVL3.SetActive(false);
            }
        }

        if (isPurchasedFurrySunglasses == false && PlayerMoney.Instance.money >= 30)
        {
            PlayerMoney.Instance.minusMoney(30);
            FurrySunglassesShopText.SetActive(false);
            PlayerMoney.Instance.moneyText.text = PlayerMoney.Instance.money.ToString() + "$";
            PlayerMoney.Instance.moneyShopText.text = PlayerMoney.Instance.money.ToString() + "$";

            CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic = 1;
            PlayerPrefs.SetInt("CurrentCosmetic", 1);
            isPurchasedFurrySunglasses = true;
            PlayerPrefs.SetInt("isPurchasedFurrySunglasses", isPurchasedFurrySunglasses ? 1 : 0);
            if (PlayerMoney.Instance.money < 10)
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
            if (PlayerMoney.Instance.money < 30)
            {
                if (isPurchasedFurrySunglasses == false)
                {
                    FurrySunglassesButton.interactable = false;
                }
                if (isPurchasedLippis == false)
                {
                    LippisButton.interactable = false;
                }
                if (isPurchasedSunglasses == false)
                {
                    SunglassesButton.interactable = false;
                }
                if (isPurchasedTreeniMyssy == false)
                {
                    TreeniMyssyButton.interactable = false;
                }
                if (isPurchasedViikset == false)
                {
                    ViiksetButton.interactable = false;
                }
            }
            if (PlayerMoney.Instance.money < 100)
            {
                if (isPurchasedKruunu == false)
                {
                    KruunuButton.interactable = false;
                }
            }
            if (PlayerMoney.Instance.money < 20)
            {
                if (BackgroundSave.instance.isPurchasedBackground2 == false)
                {
                    BackgroundSave.instance.isPurchasedBackground2 = false;
                }
                if (BackgroundSave.instance.isPurchasedBackground3 == false)
                {
                    BackgroundSave.instance.isPurchasedBackground3 = false;
                }
            }
        }
        if (isPurchasedFurrySunglasses == true && CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic == 1)
        {
            FurrySunglassesShopText.SetActive(false);
            FurrySunglassesButton.interactable = true;
        }
    }

    public void FurrySunglassesTest()
    {
        if (progressBox.level < 5)
        {
            FurrySunglassesT1.SetActive(true);
        }
        if (progressBox.level > 5 && progressBox.level < 10)
        {
            FurrySunglassesT2.SetActive(true);
        }
        if (progressBox.level >= 10)
        {
            FurrySunglassesT3.SetActive(true);
        }
        if (CurrentSkinCurrentCosmeticHolder.instance.currentSkin == 1 && CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic == 1)
        {
            if (progressBox.level < 5)
            {
                FurrySunglassesT1.SetActive(true);
                rend = FurrySunglassesT1.GetComponent<SpriteRenderer>();
                rend.color = new Color32(255, 245, 71, 255);
            }
            if (progressBox.level > 5 && progressBox.level < 10)
            {
                FurrySunglassesT2.SetActive(true);
                rend = FurrySunglassesT2.GetComponent<SpriteRenderer>();
                rend.color = new Color32(255, 245, 71, 255);
            }
            if (progressBox.level >= 10)
            {
                FurrySunglassesT3.SetActive(true);
                rend = FurrySunglassesT3.GetComponent<SpriteRenderer>();
                rend.color = new Color32(255, 245, 71, 255);
            }
        }
        if (CurrentSkinCurrentCosmeticHolder.instance.currentSkin == 3 && CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic == 1)
        {
            if (progressBox.level < 5)
            {
                FurrySunglassesT1.SetActive(true);
                rend = FurrySunglassesT1.GetComponent<SpriteRenderer>();
                rend.color = new Color32(250, 172, 255, 255);
            }
            if (progressBox.level > 5 && progressBox.level < 10)
            {
                FurrySunglassesT2.SetActive(true);
                rend = FurrySunglassesT2.GetComponent<SpriteRenderer>();
                rend.color = new Color32(250, 172, 255, 255);
            }
            if (progressBox.level >= 10)
            {
                FurrySunglassesT3.SetActive(true);
                rend = FurrySunglassesT3.GetComponent<SpriteRenderer>();
                rend.color = new Color32(250, 172, 255, 255);
            }
        }
        if (CurrentSkinCurrentCosmeticHolder.instance.currentSkin == 4 && CurrentSkinCurrentCosmeticHolder.instance.currentCosmetic == 1)
        {
            if (progressBox.level < 5)
            {
                FurrySunglassesT1.SetActive(true);
                rend = FurrySunglassesT1.GetComponent<SpriteRenderer>();
                rend.color = new Color32(255, 255, 255, 255);
            }
            if (progressBox.level > 5 && progressBox.level < 10)
            {
                FurrySunglassesT2.SetActive(true);
                rend = FurrySunglassesT2.GetComponent<SpriteRenderer>();
                rend.color = new Color32(255, 255, 255, 255);
            }
            if (progressBox.level >= 10)
            {
                FurrySunglassesT3.SetActive(true);
                rend = FurrySunglassesT3.GetComponent<SpriteRenderer>();
                rend.color = new Color32(255, 255, 255, 255);
            }
        }
    }

    //Tässä katsotaan onko cosmetics päällä kun shopin laittaa kiinni
    public void CheckOnShopExistIfPlayerHasColorOrSkinAndProgress()
    {
        if (progressBox.level < 5)
        {
            progressBox.hahmoLVL2.SetActive(false);
            progressBox.hahmoLVL1.SetActive(true);
        }
        else if (progressBox.level >= 10)
        {
            progressBox.hahmoLVL1.SetActive(false);
            progressBox.hahmoLVL2.SetActive(true);
        }

        if (CurrentSkinCurrentCosmeticHolder.instance.currentSkin == 7)
        {
            if (progressBox.level < 5)
            {
                FurrySunglassesT1.SetActive(true);
                FurrySunglassesT2.SetActive(false);
                FurrySunglassesT3.SetActive(false);
            }
            else if (progressBox.level > 5 && progressBox.level < 15)
            {
                FurrySunglassesT1.SetActive(false);
                FurrySunglassesT2.SetActive(true);
                FurrySunglassesT3.SetActive(false);
            }
            else if (progressBox.level >= 15)
            {
                FurrySunglassesT3.SetActive(true);
            }
        }

    }

    //Tässä käydään Updatessa läpi että onko pelaajalla rahaa ostaa cosmetics
    public void CosmeticUpdate()
    {
        if (isPurchasedFurrySunglasses == false && PlayerMoney.Instance.money < 30)
        {
            FurrySunglassesButton.interactable = false;
        }
        else
        {
            FurrySunglassesButton.interactable = true;
        }

        if (isPurchasedKruunu == false && PlayerMoney.Instance.money < 100)
        {
            KruunuButton.interactable = false;
        }
        else
        {
            KruunuButton.interactable = true;
        }

        if (isPurchasedSunglasses == false && PlayerMoney.Instance.money < 30)
        {
            SunglassesButton.interactable = false;
        }
        else
        {
            SunglassesButton.interactable = true;
        }

        if (isPurchasedTreeniMyssy == false && PlayerMoney.Instance.money < 30)
        {
            TreeniMyssyButton.interactable = false;
        }
        else
        {
            TreeniMyssyButton.interactable = true;
        }

        if (isPurchasedViikset == false && PlayerMoney.Instance.money < 30)
        {
            ViiksetButton.interactable = false;
        }
        else
        {
            ViiksetButton.interactable = true;
        }

        if (isPurchasedLippis == false && PlayerMoney.Instance.money < 30)
        {
            LippisButton.interactable = false;
        }
        else
        {
            LippisButton.interactable = true;
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
        if (progressBox.hahmoLVL3.activeSelf || FurrySunglassesT3.activeSelf || KruunuT3.activeSelf || LippisT3.activeSelf || TreeniMyssyT3.activeSelf || ViiksetT3.activeSelf || SunglassesT3.activeSelf)
        {
            anim.SetBool("nosto14", nosto14);
            anim.SetBool("nosto15", nosto15);
            anim.SetBool("nosto16", nosto16);
        }
        //anim.SetBool("nosto14", nosto14);
        //anim.SetBool("nosto15", nosto15);
        //anim.SetBool("nosto16", nosto16);

        //if (progressBox.level >= 10 && clickCounter >= 15 && progressBox.hahmoLVL3.activeSelf)
        //{

        //}
    }

    private void CheckInput()
    {
        if (Input.GetButtonDown("Nosto"))
        {
            inputTimer = 0;
            NostoFunction();
            clickCounter++;
            // Jos level on yhtäsuuri tai suurempi kuin 10 niin tarvii 19 clickiä että saa finashattua yhen setin painon nostoa, muuten eli else lauseessa normi 17 tarvii clickiä
            if (progressBox.level >= 10 && clickCounter >= 19 && progressBox.hahmoLVL3.activeSelf || FurrySunglassesT3.activeSelf && clickCounter >= 19)
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
                nosto16 = false;
                idle = true;
            }
            else if (clickCounter >= 16 && progressBox.hahmoLVL1.activeSelf || clickCounter >= 16 && progressBox.hahmoLVL2.activeSelf)
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

        if (clickCounter == 1 || clickCounter == 0 || StaminaIndicator.instance.currentStamina < 5)
        {
            ShopButton.interactable = true;
        }
        else
        {
            ShopButton.interactable = false;
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
            else if (clickCounter <= 15)
            {
                idle = false;
                nosto12 = false;
                nosto13 = true;
                nosto14 = false;
                clickCounter--;
            }
            else if (clickCounter <= 16)
            {
                idle = false;
                nosto13 = false;
                nosto14 = true;
                nosto15 = false;
                clickCounter--;
            }
            else if (clickCounter <= 17)
            {
                idle = false;
                nosto14 = false;
                nosto15 = true;
                nosto16 = false;
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
        else if (clickCounter <= 2)
        {
            idle = false;
            nosto0 = false;
            nosto1 = true;
        }
        else if (clickCounter <= 3)
        {
            idle = false;
            nosto0 = false;
            nosto1 = false;
            nosto2 = true;
        }
        else if (clickCounter <= 4)
        {
            idle = false;
            nosto1 = false;
            nosto2 = false;
            nosto3 = true;
        }
        else if (clickCounter <= 5)
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
        else if (clickCounter <= 15)
        {
            idle = false;
            nosto12 = false;
            nosto13 = false;
            nosto14 = true;
        }
        else if (clickCounter <= 16)
        {
            idle = false;
            nosto16 = false;
            nosto14 = false;
            nosto15 = true;
        }
        else if (clickCounter <= 17)
        {
            idle = false;
            nosto14 = false;
            nosto15 = false;
            nosto16 = true;
        }
    }
}
