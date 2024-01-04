using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTime;
    private bool timerIsRunning = false;
    private float clearTime = 7f;

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

            //이 부분 수정해야함 Clear 발생 조건을 execute에 action형식으로 부착할까?
            if ((currentTime > clearTime) && (ClearEvent.Instance.clearFlag == ClearFlag.notClear))
            {
                ClearEvent.Instance.ExecuteEvent();
            }
        }
    }

    IEnumerator TimeDelay()
    {
        while (true) 
        {
            yield return new WaitForSeconds(1f);
            TimeEvent.Instance.SendMessagePerSecond(Time.time - startTime);
        };

    }
}
