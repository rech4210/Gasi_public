using UnityEngine;

public class TimeEvent : SelectEvent
{
    float time;
    public static new TimeEvent instance;
    public TimeEvent() : base()
    {

    }

    //static SelectEvent targetEvent;
    public static SelectEvent Instance { get { return instance = new TimeEvent(); } }

    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += Time_1;
            OnExecute += Time_2;
        }
    }

    private void Time_1(SelectEvent events)
    {
        Debug.Log("Time_1");
        //Time.timeScale = 0;
    }
    private void Time_2(SelectEvent @event)
    {
        Debug.Log("Time_2");
    }
    public void SaveTime(float time)
    {
        this.time = time;
    }
}
