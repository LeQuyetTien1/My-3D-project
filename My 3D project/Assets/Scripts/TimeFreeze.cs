using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimeFreeze : MonoBehaviour
{
    public Text timeText;
    public int limitTime;
    private int time;
    public GameObject clockImage, freezeTime, freezeBackground;
    private void Start()
    {
        time = limitTime;
    }
    private void CountTime()
    {
        timeText.text = time + "s";
    }
    private void Update()
    {
        CountTime();

        if (time > 0)
        {
            time = limitTime - (int)Time.time;
        }
        if (time == 0)
        {
            clockImage.SetActive(true);
            freezeTime.SetActive(false);
            freezeBackground.SetActive(false);
        }
    }
}
