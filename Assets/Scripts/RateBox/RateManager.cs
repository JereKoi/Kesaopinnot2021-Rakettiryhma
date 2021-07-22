using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_IOS
using UnityEngine.iOS;
#endif

public class RateManager : Singleton<RateManager>
{
    [SerializeField]
    private Ratebox rateBox;

    public int countToRate = 0;

    [HideInInspector]
    public int PlayCount;

    [HideInInspector]
    public bool rateOff = false;

    public void ClickPlay()
    {
        PlayCount++;

        if (PlayCount % countToRate == 0 && !rateOff)
        {
#if UNITY_IOS
Debug.LogWarning("IOS");
Device.RequestStoreReview();
#else
            rateBox.gameObject.SetActive(true);
#endif
        }
    }
}
