using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
string gameId = "4191193";
#else
    string gameId = "4191192";
#endif
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId);
        Advertisement.AddListener(this);
        ShowBanner();
    }

    public void PlayRewardedAd()
    {
        Debug.Log("Button toimii");
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
        {
            Debug.Log("rewarded ad is not ready!");
        }
    }

    public void PlayInterstitialAd()
    {
        if (StaminaIndicator.instance.currentStamina <= 50 && Advertisement.IsReady("Interstitial_ad"))
        {
            Advertisement.Show("Interstitial_ad");
        }
        else
        {
            return;
        }
    }

    public void ShowBanner()
    {
        if (Advertisement.IsReady("Banner_ad"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("Banner_ad");
        }
        else
        {
            StartCoroutine(RepeatShowBanner());
        }
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    IEnumerator RepeatShowBanner()
    {
        yield return new WaitForSeconds(1);
        ShowBanner();
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ads are ready!");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("ERROR" + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("VIDEO STARTED");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            StaminaIndicator.instance.AddStamina(50f);
            //PlayerNiko player = new PlayerNiko(); //PlayerNiko voi korvata jollakin toisella
            //StaminaIndicator.instance.stamina = player.GetStamina();
        }
    }
}
