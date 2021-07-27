using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticsPrefabScript : MonoBehaviour
{
    public GameObject[] cosmetics;
    public int activeIndex = 0;
    void Start()
    {
        activeIndex = PlayerPrefs.GetInt("cosmetics");
    }
    public void SetActiveObject(int aIndex)
    {
        activeIndex = aIndex;
        for (int i = 0; i < cosmetics.Length; i++)
            cosmetics[i].SetActive(i == activeIndex);
        PlayerPrefs.SetInt("cosmetics", activeIndex);
    }
    void Update()
    {
        SetActiveObject(activeIndex);
    }
    public void UpgradeButton()
    {
        activeIndex++;
    }
}
