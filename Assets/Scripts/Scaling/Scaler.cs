using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    void Start()
    {
        float width = ScreenSize.GetScreenToWorldWidth;
        transform.localScale = Vector3.one * width;
        float height = ScreenSize.GetScreenToWorldHeight;
        transform.localScale = Vector3.one * height;
    }
}
