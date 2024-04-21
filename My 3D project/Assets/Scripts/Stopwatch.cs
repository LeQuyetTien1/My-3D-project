using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Stopwatch : MonoBehaviour
{
    public int limitTime;
    private int gameTime;
    public Text timeText;
    public UnityEvent gameOver;

    private void Start()
    {
        gameTime = limitTime;
    }
    private void CountTime()
    {
        int minute = gameTime / 60;
        int second = gameTime % 60;
        timeText.text = minute + ":" + (second < 10 ? "0" + second:second) ;
    }
    private void Update()
    {
        CountTime();
        
        if (gameTime > 0)
        {
            gameTime = limitTime - (int)Time.time;
        }
        if(gameTime==0)
        {
            gameOver.Invoke();
        }
    }
}
