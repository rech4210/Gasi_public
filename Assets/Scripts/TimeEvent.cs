using UnityEngine;

public class TimeEvent : Events<TimeEvent>
{
    public TimeEvent() : base( ) {}
    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += Time_1;
            OnExecute += Time_2;
        }
    }

    private void Time_1(TimeEvent events)
    {
        Debug.Log("Time_1");
        //Time.timeScale = 0.5f;
    }
    private void Time_2(TimeEvent @event)
    {
        Debug.Log("Time_2");
    }

}
