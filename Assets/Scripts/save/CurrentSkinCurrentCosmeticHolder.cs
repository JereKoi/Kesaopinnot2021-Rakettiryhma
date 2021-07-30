using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSkinCurrentCosmeticHolder : MonoBehaviour
{
    public int currentSkin;
    public int currentCosmetic;

    public static CurrentSkinCurrentCosmeticHolder instance;

    private void Start()
    {
        instance = this;
    }
}
