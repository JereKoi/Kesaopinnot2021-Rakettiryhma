using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratebox : MonoBehaviour
{
    public bool hasPlayerClickedNoThanks;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("hasPlayerClickedNoThanks"))
        {
            hasPlayerClickedNoThanks = PlayerPrefs.GetInt("hasPlayerClickedNoThanks") != 0;
            if (SkinCooldown.Instance.isPurchasedSkin1 == true)
            {
                RateManager.Instance.rateOff = true;
                gameObject.SetActive(false);
            }
        }
    }

    public void ClickNoThanks()
    {
        RateManager.Instance.rateOff = true;
        gameObject.SetActive(false);
        hasPlayerClickedNoThanks = true;
        PlayerPrefs.SetInt("hasPlayerClickedNoThanks", hasPlayerClickedNoThanks ? 1 : 0);
    }
    public void ClickLater()
    {
        gameObject.SetActive(false);
    }
    public void ClickRateNow()
    {
        Application.OpenURL("Market://details=id=com.xxxx.xx");
        gameObject.SetActive(false);
    }
}
