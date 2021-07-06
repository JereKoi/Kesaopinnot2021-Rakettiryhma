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

    public AdsManager ads;

    private int level;

    private float currentAmount = 0;

    private Coroutine routine;

    private void Start()
    {
        if (PlayerPrefs.HasKey ("level"))
        {
            level = PlayerPrefs.GetInt("level");
            textLevel.text = this.level.ToString();
        }
        else
        {
            level = 0;
        }
    }

    private void OnEnable()
    {
        uiFillImage.color = color;
        level = 0;
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
            //korjaa rajahdys paikka
            GameObject obj = Instantiate(effectPrefab, gameObject.transform);
            Destroy(obj, 3f);
        }

        UpdateLevel(level + 1);
        UpdateProgress(-1f, 0.2f);
        ads.PlayInterstitialAd();
        PlayerPrefs.SetInt("level", level);
    }

    private void UpdateLevel(int level)
    {
        this.level = level;
        textLevel.text = this.level.ToString();
    }
}
