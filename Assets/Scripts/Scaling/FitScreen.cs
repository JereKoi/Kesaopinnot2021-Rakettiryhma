using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class FitScreen : MonoBehaviour
{
    // Initialize
    private int screenWidth;
    private int screenHeight;
    private Vector2 screenSize;

    // Update is called once per frame
    private void LateUpdate()
    {
        // Update screen width and height
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        screenSize = Camera.main.ScreenToWorldPoint(new Vector2(screenWidth * 2, screenHeight * 2));

        // Stretchy
        transform.localScale = screenSize;
    }
}