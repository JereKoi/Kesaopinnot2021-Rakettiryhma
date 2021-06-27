using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SaveStamina : MonoBehaviour
{
    DateTime currentDate;
    DateTime oldDate;

    public string saveLocation;
    public static SaveStamina instance;

    private void Awake()
    {
        instance = this;

        saveLocation = "LastSavedDate1";
    }

    public float CheckDate()
    {
        currentDate = System.DateTime.Now;
        string tempString = PlayerPrefs.GetString(saveLocation, "1");

        long tempLong = Convert.ToInt64(tempString);

        DateTime oldDate = DateTime.FromBinary(tempLong);
        print("oldDate : " + oldDate);

        TimeSpan difference = currentDate.Subtract(oldDate);
        print("difference :" + difference);

        return (float)difference.TotalSeconds;

    }

    public void SaveDate()
    {
        PlayerPrefs.SetString(saveLocation, System.DateTime.Now.ToBinary().ToString());
        print("saving this date to player prefs" + System.DateTime.Now);
    }
}
