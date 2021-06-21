using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; set; }
    public savestate state;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();

        Debug.Log(Helper.Serialize<savestate>(state));
    }

    public void Save()
    {
        PlayerPrefs.SetString("save", Helper.Serialize<savestate>(state));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            state = Helper.Deserialize<savestate>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new savestate();
            Save();
            Debug.Log("No save file found, creating a new one");
        }
    }
}
