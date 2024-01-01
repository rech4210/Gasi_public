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
        StartTimer();
        StartCoroutine(TimeDelay());
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

            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        }
    }


    IEnumerator TimeDelay()
    {
        while (true) 
        {
            yield return new WaitForSeconds(5f);
            TimeEvent.Instance.SendMessagePerSecond();
        };

    }
}
