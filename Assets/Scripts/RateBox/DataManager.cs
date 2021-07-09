using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private int amount = 0;

    public void CountData()
    {
        amount++;
        Debug.LogWarning(amount);
    }
}
