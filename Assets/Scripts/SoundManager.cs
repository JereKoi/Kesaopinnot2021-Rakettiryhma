using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;

    [SerializeField]
    Button myButton;

    [SerializeField]
    float cooldownDuration = 0.3f;

    public bool muted = false;

    public static SoundManager instance;

    void Start()
    {
        instance = this;
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
            UpdateButtonIcon();

        }
        else
        {
            muted = false;
            AudioListener.pause = false;
            UpdateButtonIcon();
        }
        StartCoroutine(Cooldown());
        Save();
    }

    private void UpdateButtonIcon()
    {
        if(muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ?  1 : 0);
    }

    IEnumerator Cooldown()
    {
        // Deactivate myButton
        myButton.interactable = false;
        // Wait for cooldown duration
        yield return new WaitForSeconds(cooldownDuration);
        // Reactivate myButton
        myButton.interactable = true;
    }

}
