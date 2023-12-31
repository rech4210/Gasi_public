using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TimeEvent : Events<TimeEvent>
{
    float time;

    List<ITimeEvent> timeEvents;

    Task timeWorkTask;

    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += Time_1;
            OnExecute += Time_2;
        }
    }

    private void Start()
    {
        timeWorkTask = Task.Run(() => { SendMessagePerSecond();});
    }

    public void StoreTimeEventObj(ITimeEvent @event)
    {
        timeEvents.Add(@event);
    }

    private void SendMessagePerSecond()
    {
        for (int i = 0; i < timeEvents.Count; i++)
        {
            timeEvents[i].TimeEvent();
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
