using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIController : Singleton<UIController>
{
    public static readonly string widthOfLinesStirng      = "Width of Lines: ";
    public static readonly string windSpeedString         = "Wind Speed: ";
    public static readonly string numberOfLinesString     = "Number of Lines: ";

    public TextMeshProUGUI numberOfLinesText;
    public TextMeshProUGUI windSpeedText;
    public TextMeshProUGUI widthOfLinesText;

    public Slider numberOfLineSlider;

    private void Update()
    {
        SpawnLineProp spawnLineProp = GameController.instance.spawnLineProp;
        
        UpdateNumberOfLine(spawnLineProp);
        UpdateWindSpeedText(spawnLineProp);
        UpdateWidthOfLineText(spawnLineProp);
    }

    public void AddWindSpeed(float speed)
    {
        GameController.instance.spawnLineProp.windSpeed += speed;
    }

    public void AddWidthOfLines(float width)
    {
        GameController.instance.spawnLineProp.widthLine += width;
    }

    public void UpdateNumberOfLine(in SpawnLineProp spawnLineProp)
    {
        float NOLSliderValue = numberOfLineSlider.value;
        float newNOL = Utils.Scale(0, 1, spawnLineProp.spawnLineLimitCount.x, spawnLineProp.spawnLineLimitCount.y, NOLSliderValue);

        numberOfLinesText.text = numberOfLinesString + (int)newNOL;
        GameController.instance.spawnLineProp.spawnLineCount = (int)newNOL;
    }

    public void UpdateWindSpeedText(in SpawnLineProp spawnLineProp)
    {
        windSpeedText.text = windSpeedString + spawnLineProp.windSpeed;
    }

    public void UpdateWidthOfLineText(in SpawnLineProp spawnLineProp)
    {
        widthOfLinesText.text = widthOfLinesStirng + String.Format("{0:0.00}", spawnLineProp.widthLine);
    }
}
