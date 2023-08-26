using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTime;
    private bool timerIsRunning = false;

    private void Start()
    {
        // You can start the timer at the beginning or call the StartTimer() function later.
        StartTimer();
    }

    public void StartTimer()
    {
        startTime = Time.time;
        timerIsRunning = true;
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }

    public void ResetTimer()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            float currentTime = Time.time - startTime;

            // Calculate minutes and seconds separately.
            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime % 60f);

            // Update the timerText to display minutes and seconds.
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            if (currentTime ==15f)
            {
                
            }
        }
    }

}
