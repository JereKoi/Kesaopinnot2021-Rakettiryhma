using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratebox : MonoBehaviour
{
    public void ClickNoThanks()
    {
        RateManager.Instance.rateOff = true;
        gameObject.SetActive(false);
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
