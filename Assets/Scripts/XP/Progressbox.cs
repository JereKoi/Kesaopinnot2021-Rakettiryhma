using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Progressbox : MonoBehaviour
{
    [SerializeField] private TMP_Text textLevel;
    [SerializeField] private Image uiFillImage;

    [SerializeField] private Color color;

    [SerializeField] private GameObject effectPrefab;

    public GameObject hahmoLVL1;
    public GameObject hahmoLVL2;
    public GameObject reachEndBanner;

    public AdsManager ads;

    public int level;

    public static Progressbox Instance;

    private float currentAmount = 0;

    private Coroutine routine;

    private void Start()
    {
        Instance = this;
        if (PlayerPrefs.HasKey ("level"))
        {
            level = PlayerPrefs.GetInt("level");
            textLevel.text = this.level.ToString();
            if (level >= 3)
            {
                hahmoLVL2.SetActive(true);
            }
            else if (level < 3)
            {
                hahmoLVL1.SetActive(true);
            }
        }
        else
        {
            level = 0;
            hahmoLVL1.SetActive(true);
            hahmoLVL2.SetActive(false);
        }
    }

    public void CheckSpriteProgress()
    {
        if (level < 3)
        {
            hahmoLVL2.SetActive(false);
            hahmoLVL1.SetActive(true);
        }
        else if (level >= 3)
        {
            hahmoLVL1.SetActive(false);
            hahmoLVL2.SetActive(true);
        }
    }


    private void OnEnable()
    {
        uiFillImage.color = color;
        level = 0;
        currentAmount = 0;
        uiFillImage.fillAmount = currentAmount;
    }

    public void StartNewGameReset()
    {
        uiFillImage.color = color;
        level = 0;
        textLevel.text = this.level.ToString();
        currentAmount = 0;
        uiFillImage.fillAmount = currentAmount;
    }

    public void UpdateProgress(float amount, float duration = 0.1f)
    {
        if (routine != null)
        {
            StopCoroutine(routine);
        }

        float target = currentAmount + amount;
        routine = StartCoroutine(FillRoutine(target, duration));
    }

    private IEnumerator FillRoutine(float target, float duration)
    {
        float time = 0;
        float tempAmount = currentAmount;
        float diff = target - tempAmount;
        currentAmount = target;

        while (time < duration)
        {
            time += Time.deltaTime;
            float percent = time / duration;
            uiFillImage.fillAmount = tempAmount + diff * percent;
            yield return null;
        }

        if (currentAmount >= 1)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        if (effectPrefab != null)
        {
            GameObject obj = Instantiate(effectPrefab, gameObject.transform);
            Destroy(obj, 3f);
        }

        UpdateLevel(level + 1);
        UpdateProgress(-1f, 0.2f);
        //ads.PlayInterstitialAd();
        PlayerPrefs.SetInt("level", level);

        if (level >= 3)
        {
            hahmoLVL1.SetActive(false);
            hahmoLVL2.SetActive(true);
        }
        if (level == 4)
        {
            ads.PlayInterstitialAd();
        }
        //TÄSSÄ KOHDASSA MÄÄRITELLÄÄN PELIN LOPPU, MUISTA START METHODIIN TEHDÄ IF LAUSE JOSSA CHECKATAAN ONKO >= 5 LEVU NIIN CHANGEMINDBUTTON.SETACTIVE(TRUE);
        else if (level == 5)
        {
            reachEndBanner.SetActive(true);
        }
    }

    private void UpdateLevel(int level)
    {
        this.level = level;
        textLevel.text = this.level.ToString();
    }
}
