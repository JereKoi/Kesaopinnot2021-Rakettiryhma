using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPScriptV3 : MonoBehaviour
{

    [Header("UI references :")]
    [SerializeField] private Image uiFillImage;
    [SerializeField] private TMP_Text uiStartText;
    [SerializeField] private TMP_Text uiEndText;

    //[Header("Player & Endline references :")]
    //[SerializeField] private Transform playerTransform;
    //[SerializeField] private Transform endLineTransform;

    // "endLinePosition" to cache endLine's position to avoid
    // "endLineTransform.position" each time since the End line has a fixed position.
    private Vector3 endLinePosition;

    // "fullDistance" stores the default distance between the player & end line.
    private float fullDistance;

    private TMP_Text m_TextComponent;

    public static XPScriptV3 instance;

    private void Awake()
    {
        m_TextComponent = GetComponent<TMP_Text>();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    //private void Start()
    //{
    //    endLinePosition = endLineTransform.position;
    //    //fullDistance = GetDistance();
    //}


    public void SetLevelTexts(int level)
    {
        uiStartText.text = level.ToString();
        uiEndText.text = (level + 1).ToString();
    }


    //private float GetDistance()
    //{
    //    // Slow
    //    //return Vector3.Distance (playerTransform.position, endLinePosition) ;

    //    // Fast
    //    return (endLinePosition - playerTransform.position).sqrMagnitude;
    //}


    public void UpdateProgressFill(float value)
    {
        uiFillImage.fillAmount = value;
    }


    //private void Update()
    //{
    //    check if the player doesn't pass the End Line
    //    if (playerTransform.position.z <= endLinePosition.z)
    //    {
    //        float newDistance = GetDistance();
    //        float progressValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);

    //        UpdateProgressFill(progressValue);
    //    }
    //}
}
