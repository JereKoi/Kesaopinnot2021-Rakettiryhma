using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSave : MonoBehaviour
{
    public GameObject Background1;
    public GameObject Background2;
    public GameObject Background3;

    public int currentBackground;

    private void Start()
    {
        //Background1.SetActive(true);

        if (PlayerPrefs.HasKey("Background"))
        {
            currentBackground = PlayerPrefs.GetInt("Background");
            if (currentBackground == 1)
            {
                Background1.SetActive(true);
                Background2.SetActive(false);
                Background3.SetActive(false);
            }
            else if (currentBackground == 2)
            {
                Background2.SetActive(true);
                Background1.SetActive(false);
                Background3.SetActive(false);
            }
            else if (currentBackground == 3)
            {
                Background3.SetActive(true);
                Background2.SetActive(false);
                Background1.SetActive(false);
            }
        }
        else
        {
            Background1.SetActive(true);
        }
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Background"))
        {
            if (currentBackground == 1)
            {
                Background1.SetActive(true);
                Background2.SetActive(false);
                Background3.SetActive(false);
            }
            else if (currentBackground == 2)
            {
                Background2.SetActive(true);
                Background1.SetActive(false);
                Background3.SetActive(false);
            }
            else if (currentBackground == 3)
            {
                Background3.SetActive(true);
                Background2.SetActive(false);
                Background1.SetActive(false);
            }
        }
        else
        {
            Background1.SetActive(true);
        }
    }

    public void SelectBackground1()
    {
        Background1.SetActive(true);
        Background2.SetActive(false);
        Background3.SetActive(false);
        currentBackground = 1;
        PlayerPrefs.SetInt("Background", 1);
    }
    public void SelectBackground2()
    {
        Background2.SetActive(true);
        Background1.SetActive(false);
        Background3.SetActive(false);
        currentBackground = 3;
        PlayerPrefs.SetInt("Background", 3);
    }
    public void SelectBackground3()
    {
        Background3.SetActive(true);
        Background1.SetActive(false);
        Background2.SetActive(false);
        currentBackground = 3;
        PlayerPrefs.SetInt("Background", 3);
    }
}
