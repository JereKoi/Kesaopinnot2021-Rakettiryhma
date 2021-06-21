using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPScript : MonoBehaviour
{
    public Text currentXPtext, targetXPtext, levelText;
    public int currentXP, targetXP, level;

    public static XPScript instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        currentXPtext.text = currentXP.ToString();
        targetXPtext.text = targetXP.ToString();
        levelText.text = level.ToString();
    }

    public void AddXP(int xp)
    {
        currentXP += xp;

        while (currentXP >= targetXP) //aiemmin oli if
        {
            currentXP = currentXP - targetXP;
            level++;
            targetXP += targetXP / 20;

            levelText.text = level.ToString();
            targetXPtext.text = targetXP.ToString();
        }

        currentXPtext.text = currentXP.ToString();
    }
}
