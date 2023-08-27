using UnityEngine;

public class TimeEvent : Events<TimeEvent>
{
    float time;

    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += Time_1;
            OnExecute += Time_2;
        }
    }

    private void Time_1()
    {
        Debug.Log("Time_1");
        //Time.timeScale = 0;
    }
    private void Time_2()
    {
        Debug.Log("Time_2");
    }
    public void SaveTime(float time)
    {
        this.time = time;
    }
}
